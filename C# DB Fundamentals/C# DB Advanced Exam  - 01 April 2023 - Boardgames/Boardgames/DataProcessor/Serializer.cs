namespace Boardgames.DataProcessor;

using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Boardgames.Data;
using Boardgames.DataProcessor.ExportDto;

public class Serializer
{
    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        ExportCreatorDto[] creatorsWithboardgames = context.Creators
            .Where(c => c.Boardgames.Any())
            .ToArray()
            .Select(c => new ExportCreatorDto()
            {
                CreatorName = $"{c.FirstName} {c.LastName}",
                BoardgamesCount = c.Boardgames.Count,
                Boardgames = c.Boardgames
                .Select(b => new ExportBoardgameDto()
                {
                    Name = b.Name,
                    YearPublished= b.YearPublished
                })
                .OrderBy(b => b.Name)
                .ToArray()
            })
            .OrderByDescending(c => c.BoardgamesCount)
            .ThenBy(c => c.CreatorName)
            .ToArray();

        return Serialize(creatorsWithboardgames, "Creators");
    }

    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
    {
        var sellersWithMostBoardgames = context.Sellers
            .Where(s => s.BoardgamesSellers.
            Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
            .Select(s => new
            {
                Name = s.Name,
                Website = s.Website,
                Boardgames = s.BoardgamesSellers
                .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                .Select(bs => new
                {
                    Name = bs.Boardgame.Name,
                    Rating = bs.Boardgame.Rating,
                    Mechanics = bs.Boardgame.Mechanics,
                    Category = bs.Boardgame.CategoryType.ToString()
                })
                .OrderByDescending(bs => bs.Rating)
                .ThenBy(bs => bs.Name)
                .ToArray()
            })
            .OrderByDescending(s => s.Boardgames.Length)
            .ThenBy(s => s.Name)
            .Take(5)
            .ToArray();

        return JsonConvert.SerializeObject(sellersWithMostBoardgames, Formatting.Indented);
    }

    private static string Serialize<T>(T obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot =
            new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(T), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using StringWriter writer = new StringWriter(sb);
        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }
}