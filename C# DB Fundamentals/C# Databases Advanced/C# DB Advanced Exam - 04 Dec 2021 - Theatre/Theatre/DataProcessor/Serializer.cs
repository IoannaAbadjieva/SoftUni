namespace Theatre.DataProcessor;

using System;
using System.Text;
using System.Xml.Serialization;
using Data;
using Newtonsoft.Json;
using Theatre.Data.Models;
using Theatre.DataProcessor.ExportDto;

public class Serializer
{
    public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
    {
        var theatres = context.Theatres
            .ToArray()
            .Where(th => th.NumberOfHalls >= numbersOfHalls && th.Tickets.Count >= 20)
            .Select(th => new
            {
                Name = th.Name,
                Halls = th.NumberOfHalls,
                TotalIncome = th.Tickets
                                .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                                .Sum(t => t.Price),
                Tickets = th.Tickets
                .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                .Select(t => new
                {
                    Price = t.Price,
                    RowNumber = t.RowNumber
                })
                .OrderByDescending(t => t.Price)
                .ToArray()
            })
            .OrderByDescending(th => th.Halls)
            .ThenBy(th => th.Name);


        return JsonConvert.SerializeObject(theatres, Formatting.Indented);
    }

    public static string ExportPlays(TheatreContext context, double raiting)
    {
        ExportPlayDto[] playDtos = context.Plays
            .Where(p => p.Rating <= raiting)
            .OrderBy(p => p.Title)
            .ThenByDescending(p => p.Genre)
            .Select(p => new ExportPlayDto()
            {
                Title = p.Title,
                Duration = p.Duration.ToString("c"),
                Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                Genre = p.Genre.ToString(),
                Actors = p.Casts
                .Where(c => c.IsMainCharacter)
                .Select(c => new ExportCastDto()
                {
                    FullName = c.FullName,
                    MainCharacter = $"Plays main character in '{p.Title}'."
                })
                .OrderByDescending(c => c.FullName)
                .ToArray()
            })
            .ToArray();

        return Serialize(playDtos, "Plays");
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
