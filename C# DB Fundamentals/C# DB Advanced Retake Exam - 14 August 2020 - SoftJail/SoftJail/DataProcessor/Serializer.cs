namespace SoftJail.DataProcessor;

using Data;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.DataProcessor.ExportDto;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

public class Serializer
{
    public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
    {
        var prisoners = context.Prisoners
            .Where(p => ids.Contains(p.Id))
            .Select(p => new
            {
                Id = p.Id,
                Name = p.FullName,
                CellNumber = p.Cell.CellNumber,
                Officers = p.PrisonerOfficers
                .Select(po => new
                {
                    OfficerName = po.Officer.FullName,
                    Department = po.Officer.Department.Name
                })
                .OrderBy(po => po.OfficerName)
                .ToArray(),
                TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
            })
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Id)
            .ToArray();

        return JsonConvert.SerializeObject(prisoners, Formatting.Indented);

    }

    public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
    {
        string[] names = prisonersNames
            .Split(',', StringSplitOptions.RemoveEmptyEntries);

        ExportPrisonerDto[] prisoners = context.Prisoners
            .Where(p => names.Contains(p.FullName))
            .Select(p => new ExportPrisonerDto()
            {
                Id = p.Id,
                FullName = p.FullName,
                IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                Mails = p.Mails
                .Select(m => new ExportMailDto()
                {
                    Description = string.Join("",m.Description.Reverse()),
                })
                .ToArray()
            })
            .OrderBy(p => p.FullName)
            .ThenBy(p => p.Id)
            .ToArray();

        return Serialize(prisoners, "Prisoners");
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