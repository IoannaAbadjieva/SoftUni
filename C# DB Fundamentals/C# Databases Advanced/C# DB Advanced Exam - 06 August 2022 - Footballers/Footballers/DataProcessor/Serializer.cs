namespace Footballers.DataProcessor;

using System.Globalization;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Data;
using Footballers.DataProcessor.ExportDto;

public class Serializer
{
    public static string ExportCoachesWithTheirFootballers(FootballersContext context)
    {
        ExportCoachDto[] coaches = context.Coaches
            .Where(c => c.Footballers.Any())
            .Select(c => new ExportCoachDto()
            {
                FootballersCount = c.Footballers.Count,
                Name = c.Name,
                Footballers = c.Footballers
                .Select(f => new ExportFootballerDto()
                {
                    Name = f.Name,
                    PositionType = f.PositionType.ToString()
                })
                .OrderBy(f => f.Name)
                .ToArray()
            })
            .OrderByDescending(c => c.Footballers.Length)
            .ThenBy(c => c.Name)
            .ToArray();

        return Serialize(coaches, "Coaches");
    }

    public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
    {
        var teams = context.Teams
            .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
            .Select(t => new
            {
                Name = t.Name,
                Footballers = t.TeamsFootballers
                .Where(tf => tf.Footballer.ContractStartDate >= date)
                .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                .ThenBy(tf => tf.Footballer.Name)
                //.ToArray()
                .Select(tf => new
                {
                    FootballerName = tf.Footballer.Name,
                    ContractStartDate = tf.Footballer.ContractStartDate
                                        .ToString("d", CultureInfo.InvariantCulture),
                    ContractEndDate = tf.Footballer.ContractEndDate
                                        .ToString("d", CultureInfo.InvariantCulture),
                    BestSkillType = tf.Footballer.BestSkillType.ToString(),
                    PositionType = tf.Footballer.PositionType.ToString(),
                })
                .ToArray()
            })
            .OrderByDescending(t => t.Footballers.Length)
            .ThenBy(t => t.Name)
            .Take(5)
            .ToArray();

        return JsonConvert.SerializeObject(teams, Formatting.Indented);
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
