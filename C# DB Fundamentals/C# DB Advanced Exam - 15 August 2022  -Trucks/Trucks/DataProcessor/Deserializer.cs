namespace Trucks.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Castle.Components.DictionaryAdapter;
using Data;
using Newtonsoft.Json;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedDespatcher
        = "Successfully imported despatcher - {0} with {1} trucks.";

    private const string SuccessfullyImportedClient
        = "Successfully imported client - {0} with {1} trucks.";

    public static string ImportDespatcher(TrucksContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        ImportDespatcherDto[] despatcherDtos = Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

        ICollection<Despatcher> validDespathers = new HashSet<Despatcher>();

        foreach (var despatcherDto in despatcherDtos)
        {
            if (!IsValid(despatcherDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Despatcher despatcher = new Despatcher()
            {
                Name = despatcherDto.Name,
                Position = despatcherDto.Position
            };

            ICollection<Truck> validTrucks = new HashSet<Truck>();
            foreach (var truckDto in despatcherDto.Trucks)
            {
                if (!IsValid(truckDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Truck truck = new Truck()
                {
                    RegistrationNumber = truckDto.RegistrationNumber,
                    VinNumber = truckDto.VinNumber,
                    TankCapacity = truckDto.TankCapacity,
                    CargoCapacity = truckDto.CargoCapacity,
                    CategoryType = (CategoryType)truckDto.CategoryType,
                    MakeType = (MakeType)truckDto.MakeType
                };

                despatcher.Trucks.Add(truck);
            }

            validDespathers.Add(despatcher);
            sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
        }

        context.Despatchers.AddRange(validDespathers);
        context.SaveChanges();

        return sb.ToString().Trim();
    }
    public static string ImportClient(TrucksContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();
        ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

        ICollection<Client>validClients = new HashSet<Client>();
        foreach (var clientDto in clientDtos)
        {
            if (!IsValid(clientDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (clientDto.Type == "usual")
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Client client = new Client()
            {
                Name = clientDto.Name,
                Nationality = clientDto.Nationality,
                Type = clientDto.Type
            };

            foreach (var truckId in clientDto.Trucks.Distinct())
            {
                if (context.Trucks.Find(truckId) == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                client.ClientsTrucks.Add(new ClientTruck()
                {
                    Client = client,
                    TruckId = truckId,
                });
            }

            validClients.Add(client);
            sb.AppendLine(string.Format(SuccessfullyImportedClient,client.Name,client.ClientsTrucks.Count));
        }

        context.Clients.AddRange(validClients);
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