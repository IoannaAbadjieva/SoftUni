namespace SoftJail.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Data;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

public class Deserializer
{
    private const string ErrorMessage = "Invalid Data";

    private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

    private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

    private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

    public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ImportDepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

        ICollection<Department> validDepartments = new HashSet<Department>();

        foreach (var departmentDto in departmentDtos)
        {
            if (!IsValid(departmentDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (!departmentDto.Cells.Any())
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (departmentDto.Cells.Any(c => !IsValid(c)))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }
            ICollection<Cell> validCells = new HashSet<Cell>();
            foreach (var cellDto in departmentDto.Cells)
            {
                validCells.Add(new Cell()
                {
                    CellNumber = cellDto.CellNumber,
                    HasWindow = cellDto.HasWindow
                });
            }

            Department department = new Department()
            {
                Name = departmentDto.Name,
                Cells = validCells
            };

            validDepartments.Add(department);
            sb.AppendLine(string.Format(SuccessfullyImportedDepartment, department.Name, validCells.Count));
        }

        context.Departments.AddRange(validDepartments);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ImportPrisonerDto[] prisonerDtos =
            JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

        ICollection<Prisoner> validPrisoners = new HashSet<Prisoner>();

        foreach (var prisonerDto in prisonerDtos)
        {
            if (!IsValid(prisonerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

            if (!isIncarcerationDateValid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            DateTime? releaseDate = null;

            if (!string.IsNullOrEmpty(prisonerDto.ReleaseDate))
            {
                bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateParsed);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                releaseDate = releaseDateParsed;
            }

            if (prisonerDto.Mails.Any(m => !IsValid(m)))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            ICollection<Mail> validMails = new HashSet<Mail>();
            foreach (var mailDto in prisonerDto.Mails)
            {
                validMails.Add(new Mail()
                {
                    Description = mailDto.Description,
                    Sender = mailDto.Sender,
                    Address = mailDto.Address
                });
            }

            Prisoner prisoner = new Prisoner()
            {
                FullName = prisonerDto.FullName,
                Nickname = prisonerDto.Nickname,
                Age = prisonerDto.Age,
                IncarcerationDate = incarcerationDate,
                ReleaseDate = releaseDate,
                Bail = prisonerDto.Bail,
                CellId = prisonerDto.CellId,
                Mails = validMails
            };

            validPrisoners.Add(prisoner);
            sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
        }
        context.Prisoners.AddRange(validPrisoners);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        ImportOfficerDto[] officerDtos = Deserialize<ImportOfficerDto[]>(xmlString, "Officers");

        ICollection<Officer> validOfficers = new HashSet<Officer>();

        foreach (var officerDto in officerDtos)
        {
            if (!IsValid(officerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isPositionValid = Enum.TryParse<Position>(officerDto.Position,
                out Position position);
            if (!isPositionValid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isWeaponValid = Enum.TryParse<Weapon>(officerDto.Weapon,
               out Weapon weapon);
            if (!isWeaponValid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }
          

            Officer officer = new Officer()
            {
                FullName = officerDto.FullName,
                Salary = officerDto.Salary,
                Position = position,
                Weapon = weapon,
                DepartmentId = officerDto.DepartmentId
            };

            foreach (var prisonerDto in officerDto.Prisoners)
            {
                officer.OfficerPrisoners.Add(new OfficerPrisoner
                {
                    PrisonerId = prisonerDto.Id,
                });
            }

            validOfficers.Add(officer);
            sb.AppendLine(string.Format(SuccessfullyImportedOfficer, 
                officer.FullName, officer.OfficerPrisoners.Count));
        }
        context.Officers.AddRange(validOfficers);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    private static bool IsValid(object obj)
    {
        var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
        var validationResult = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
        return isValid;
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