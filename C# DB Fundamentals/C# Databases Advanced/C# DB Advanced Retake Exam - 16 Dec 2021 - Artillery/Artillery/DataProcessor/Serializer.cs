
namespace Artillery.DataProcessor;

using Artillery.Data;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ExportDto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Serialization;

public class Serializer
{
    public static string ExportShells(ArtilleryContext context, double shellWeight)
    {
        var shells = context.Shells
            .Where(sh => sh.ShellWeight > shellWeight)
            .OrderBy(sh => sh.ShellWeight)
            .ToArray()
            .Select(sh => new
            {
                ShellWeight = sh.ShellWeight,
                Caliber = sh.Caliber,
                Guns = sh.Guns
                .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                .Select(g => new
                {
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range > 3000 ? "Long-range" : "Regular range",
                })
                .OrderByDescending(g => g.GunWeight)
                .ToArray()
            });

        return JsonConvert.SerializeObject(shells, Formatting.Indented);

    }

    public static string ExportGuns(ArtilleryContext context, string manufacturer)
    {
       
        ExportGunDto[] gunDtos = context.Guns
            .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
            .Select(g => new ExportGunDto()
            {
                ManufacturerName = g.Manufacturer.ManufacturerName,
                GunType = g.GunType.ToString(),
                GunWeight = g.GunWeight,
                BarrelLength = g.BarrelLength,
                Range = g.Range,
                Countries = g.CountriesGuns
                .Where(cg => cg.Country.ArmySize > 4500000)
                .Select(cg => new ExportGunCountryDto
                {
                    CountryName = cg.Country.CountryName,
                    ArmySize = cg.Country.ArmySize
                })
                .OrderBy(c => c.ArmySize)
                .ToArray()
            })
            .OrderBy(g => g.BarrelLength)
            .ToArray();

        return Serialize<ExportGunDto[]>(gunDtos, "Guns");

    }

    private static string Serialize<T>(T obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter(sb);
        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }

    private static IMapper InitializeMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ArtilleryProfile>();
        }));
    }
}
