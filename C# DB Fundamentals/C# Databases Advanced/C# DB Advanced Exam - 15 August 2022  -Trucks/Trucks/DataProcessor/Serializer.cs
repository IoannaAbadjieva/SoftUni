namespace Trucks.DataProcessor;

using Data;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ExportDto;
using Trucks.DataProcessor.ImportDto;

public class Serializer
{
    public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
    {
        ExportDespatcherDto[] despatchers = context.Despatchers
            .Where(d => d.Trucks.Any())
            .Select(d => new ExportDespatcherDto()
            {
                TrucksCount = d.Trucks.Count,
                Name = d.Name,
                Trucks = d.Trucks
                .Select(t => new ExportTruckDto()
                {
                    RegistrationNumber = t.RegistrationNumber,
                    MakeType = t.MakeType.ToString()
                })
                .OrderBy(t => t.RegistrationNumber)
                .ToArray()
            })
            .OrderByDescending(d => d.TrucksCount)
            .ThenBy(d => d.Name)
            .ToArray();

        return Serialize(despatchers, "Despatchers");
    }

    public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
    {
        var clients = context.Clients
            .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
            .ToArray()
            .Select(c => new
            {
                Name = c.Name,
                Trucks = c.ClientsTrucks
                .Where(ct => ct.Truck.TankCapacity >= capacity)
                .Select(ct => new
                {
                    TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                    VinNumber = ct.Truck.VinNumber,
                    TankCapacity = ct.Truck.TankCapacity,
                    CargoCapacity = ct.Truck.CargoCapacity,
                    CategoryType = ct.Truck.CategoryType.ToString(),
                    MakeType = ct.Truck.MakeType.ToString()
                })
                .OrderBy(ct => ct.MakeType)
                .ThenByDescending(ct => ct.CargoCapacity)
                .ToArray()
            })
            .OrderByDescending(c => c.Trucks.Length)
            .ThenBy(c => c.Name)
            .Take(10)
            .ToArray();

        return JsonConvert.SerializeObject(clients, Formatting.Indented);
    }

    private static string Serialize<T>(T obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(); ;
        namespaces.Add(string.Empty, string.Empty);

        StringWriter writer = new StringWriter(sb);
        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().Trim();
    }
}
