namespace Artillery.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

using AutoMapper;
using Newtonsoft.Json;

using Data;
using Data.Models;
using Data.Models.Enums;
using ImportDto;

public class Deserializer
{
    private const string ErrorMessage =
        "Invalid data.";
    private const string SuccessfulImportCountry =
        "Successfully import {0} with {1} army personnel.";
    private const string SuccessfulImportManufacturer =
        "Successfully import manufacturer {0} founded in {1}.";
    private const string SuccessfulImportShell =
        "Successfully import shell caliber #{0} weight {1} kg.";
    private const string SuccessfulImportGun =
        "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

    public static string ImportCountries(ArtilleryContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();
        IMapper mapper = InitializeMapper();

        ImportCountryDto[] countryDtos = Deserialize<ImportCountryDto[]>(xmlString, "Countries");

        ICollection<Country> validCountries = new HashSet<Country>();

        foreach (var countryDto in countryDtos)
        {
            if (!IsValid(countryDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Country country = mapper.Map<Country>(countryDto);

            validCountries.Add(country);
            sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
        }

        context.Countries.AddRange(validCountries);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportManufacturers(ArtilleryContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();
        IMapper mapper = InitializeMapper();

        ImportManufacturerDto[] manufacturerDtos = Deserialize<ImportManufacturerDto[]>(xmlString, "Manufacturers");

        ICollection<Manufacturer> validManufacturer = new HashSet<Manufacturer>();

        foreach (var manufacturerDto in manufacturerDtos)
        {
            if (!IsValid(manufacturerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (validManufacturer.Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Manufacturer manufacturer = mapper.Map<Manufacturer>(manufacturerDto);
            string[] manufacturerInfo = manufacturer.Founded
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .TakeLast(2)
                .ToArray();

            validManufacturer.Add(manufacturer);

            sb.AppendLine(string.Format(SuccessfulImportManufacturer,
                manufacturer.ManufacturerName, string.Join(", ", manufacturerInfo)));
        }

        context.Manufacturers.AddRange(validManufacturer);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportShells(ArtilleryContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();
        IMapper mapper = InitializeMapper();

        ImportShellDto[] shellDtos = Deserialize<ImportShellDto[]>(xmlString, "Shells");

        ICollection<Shell> validShells = new HashSet<Shell>();

        foreach (var shellDto in shellDtos)
        {
            if (!IsValid(shellDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Shell shell = mapper.Map<Shell>(shellDto);
            validShells.Add(shell);

            sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
        }

        context.Shells.AddRange(validShells);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportGuns(ArtilleryContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ImportGunDto[] gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

        ICollection<Gun> validGuns = new HashSet<Gun>();

        foreach (var gunDto in gunDtos)
        {
            if (!IsValid(gunDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (!Enum.TryParse<GunType>(gunDto.GunType, out GunType gunType))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Gun gun = new Gun()
            {
                GunWeight = gunDto.GunWeight,
                BarrelLength = gunDto.BarrelLength,
                NumberBuild = gunDto.NumberBuild,
                Range = gunDto.Range,
                GunType = gunType,
                ManufacturerId = gunDto.ManufacturerId,
                ShellId = gunDto.ShellId
            };

            foreach (var countryDto in gunDto.Countries)
            {
                gun.CountriesGuns.Add(new CountryGun
                {
                    CountryId = countryDto.Id
                });
            }

            validGuns.Add(gun);
            sb.AppendLine(string.Format(SuccessfulImportGun,
                gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));

        }

        context.Guns.AddRange(validGuns);
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

    private static IMapper InitializeMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ArtilleryProfile>();
        }));
    }
}