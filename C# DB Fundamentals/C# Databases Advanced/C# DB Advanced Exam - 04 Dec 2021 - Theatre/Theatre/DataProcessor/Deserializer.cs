namespace Theatre.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

using Data;
using Data.Models;
using Data.Models.Enums;
using ImportDto;
using Newtonsoft.Json;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfulImportPlay
        = "Successfully imported {0} with genre {1} and a rating of {2}!";

    private const string SuccessfulImportActor
        = "Successfully imported actor {0} as a {1} character!";

    private const string SuccessfulImportTheatre
        = "Successfully imported theatre {0} with #{1} tickets!";



    public static string ImportPlays(TheatreContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();
        TimeSpan minPlayDuration = new TimeSpan(1, 0, 0);

        ImportPlayDto[] playDtos = Deserialize<ImportPlayDto[]>(xmlString, "Plays");
        ICollection<Play> validPlays = new HashSet<Play>();

        foreach (var playDto in playDtos)
        {
            if (!IsValid(playDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (!Enum.TryParse<Genre>(playDto.Genre, out Genre genre))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (!TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, out TimeSpan duration))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (duration < minPlayDuration)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Play play = new Play()
            {
                Title = playDto.Title,
                Duration = duration,
                Rating = playDto.Rating,
                Genre = genre,
                Description = playDto.Description,
                Screenwriter = playDto.Screenwriter
            };

            validPlays.Add(play);
            sb.AppendLine(string.Format(SuccessfulImportPlay,
                play.Title, play.Genre.ToString(), play.Rating));
        }

        context.Plays.AddRange(validPlays);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportCasts(TheatreContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        ImportCastDto[] castDtos = Deserialize<ImportCastDto[]>(xmlString, "Casts");

        ICollection<Cast> validCasts = new HashSet<Cast>();

        foreach (var castDto in castDtos)
        {
            if (!IsValid(castDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (!bool.TryParse(castDto.IsMainCharacter, out bool isMainCharacter))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Cast cast = new Cast()
            {
                FullName = castDto.FullName,
                IsMainCharacter = isMainCharacter,
                PhoneNumber = castDto.PhoneNumber,
                PlayId = castDto.PlayId
            };

            validCasts.Add(cast);
            sb.AppendLine(string.Format(SuccessfulImportActor,
                cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
        }
        context.Casts.AddRange(validCasts);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ImportTheatreDto[] theatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

        ICollection<Theatre> validTheatres = new HashSet<Theatre>();

        foreach (var theatreDto in theatreDtos)
        {
            if (!IsValid(theatreDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var theatre = new Theatre()
            {
                Name = theatreDto.Name,
                NumberOfHalls = theatreDto.NumberOfHalls,
                Director = theatreDto.Director

            };

            ICollection<Ticket> validTickets = new HashSet<Ticket>();

            foreach (var ticketDto in theatreDto.Tickets)
            {
                if (!IsValid(ticketDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Ticket ticket = new Ticket()
                {
                    Price = ticketDto.Price,
                    RowNumber = ticketDto.RowNumber,
                    PlayId = ticketDto.PlayId

                };
                validTickets.Add(ticket);
            }

            theatre.Tickets = validTickets;
            validTheatres.Add(theatre);

            sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, validTickets.Count));
        }
        context.Theatres.AddRange(validTheatres);
        context.SaveChanges();

        return sb.ToString().Trim();
    }


    private static bool IsValid(object obj)
    {
        var validator = new ValidationContext(obj);
        var validationRes = new List<ValidationResult>();

        var result = Validator.TryValidateObject(obj, validator, validationRes, true);
        return result;
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
