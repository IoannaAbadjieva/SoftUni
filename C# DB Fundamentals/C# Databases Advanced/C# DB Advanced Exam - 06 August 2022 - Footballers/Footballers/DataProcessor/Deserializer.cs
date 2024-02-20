namespace Footballers.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using Footballers.Data;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCoach
        = "Successfully imported coach - {0} with {1} footballers.";

    private const string SuccessfullyImportedTeam
        = "Successfully imported team - {0} with {1} footballers.";

    public static string ImportCoaches(FootballersContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        ImportCoachDto[] coachDtos = Deserialize<ImportCoachDto[]>(xmlString, "Coaches");

        ICollection<Coach> validCoaches = new HashSet<Coach>();

        foreach (var coachDto in coachDtos)
        {
            if (!IsValid(coachDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            ICollection<Footballer> validFootballers = new HashSet<Footballer>();
            foreach (var footballerDto in coachDto.Footballers)
            {
                if (!IsValid(footballerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractStartDate);
                if (!isStartDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate,
                   "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractEndDate);
                if (!isEndDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (contractStartDate >= contractEndDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validFootballers.Add(new Footballer()
                {
                    Name = footballerDto.Name,
                    ContractStartDate = contractStartDate,
                    ContractEndDate = contractEndDate,
                    PositionType = (PositionType)footballerDto.PositionType,
                    BestSkillType = (BestSkillType)footballerDto.BestSkillType
                });

            }

            validCoaches.Add(new Coach()
            {
                Name = coachDto.Name,
                Nationality = coachDto.Nationality,
                Footballers = validFootballers
            });
            sb.AppendLine(string.Format(SuccessfullyImportedCoach, coachDto.Name, validFootballers.Count));
        }

        context.Coaches.AddRange(validCoaches);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportTeams(FootballersContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();
        ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

        ICollection<Team> validTeams = new HashSet<Team>();

        int[] footballerIds = context.Footballers
            .AsNoTracking()
            .Select(f => f.Id)
            .ToArray();

        foreach (var teamDto in teamDtos)
        {
            if (!IsValid(teamDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Team team = new Team()
            {
                Name = teamDto.Name,
                Nationality = teamDto.Nationality,
                Trophies = teamDto.Trophies
            };

            foreach (var id in teamDto.Footballers.Distinct())
            {
                if (!footballerIds.Contains(id))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                team.TeamsFootballers.Add(new TeamFootballer()
                {
                    FootballerId = id
                });
            }

            validTeams.Add(team);
            sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
        }
        context.Teams.AddRange(validTeams);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }

    private static T Deserialize<T>(string xmlString, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
        StringReader reader = new StringReader(xmlString);

        T deserializetDtos = (T)xmlSerializer.Deserialize(reader);

        return deserializetDtos;
    }
}

