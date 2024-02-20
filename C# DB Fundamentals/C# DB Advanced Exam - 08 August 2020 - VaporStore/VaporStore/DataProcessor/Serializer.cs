namespace VaporStore.DataProcessor;

using Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.ExportDto;

public static class Serializer
{
    public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
    {
        var genres = context.Genres
            .Where(g => genreNames.Contains(g.Name))
            .Where(g => g.Games.Any(g => g.Purchases.Any()))
            .ToArray()
            .Select(g => new
            {
                g.Id,
                Genre = g.Name,
                Games = g.Games
                .Where(game => game.Purchases.Any())
                .Select(game => new
                {
                    game.Id,
                    Title = game.Name,
                    Developer = game.Developer.Name,
                    Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                    Players = game.Purchases.Count
                })
                .OrderByDescending(game => game.Players)
                .ThenBy(game => game.Id)
                .ToArray(),
                TotalPlayers = g.Games.Sum(g => g.Purchases.Count)
            })
            .OrderByDescending(g => g.TotalPlayers)
            .ThenBy(g => g.Id)
            .ToArray();

        return JsonConvert.SerializeObject(genres, Formatting.Indented);
    }

    public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter writer = new StringWriter(sb);

        XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), xmlRoot);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        PurchaseType type = Enum.Parse<PurchaseType>(purchaseType);

        var users = context
            .Users
            .ToArray()
            .Where(u => u.Cards.Any(c => c.Purchases.Any()))
            .Select(u => new ExportUserDto()
            {
                Username = u.Username,
                Purchases = context
                    .Purchases
                    .ToArray()
                    .Where(p => p.Card.User.Username == u.Username && p.Type == type)
                    .OrderBy(p => p.Date)
                    .Select(p => new ExportPurchaseDto()
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto()
                        {
                            Name = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .ToArray(),
                TotalSpent = context
                    .Purchases
                    .ToArray()
                    .Where(p => p.Card.User.Username == u.Username && p.Type == type)
                    .Sum(p => p.Game.Price)
            })
            .Where(u => u.Purchases.Length > 0)
            .OrderByDescending(u => u.TotalSpent)
            .ThenBy(u => u.Username)
            .ToArray();

        xmlSerializer.Serialize(writer, users, namespaces);
        return sb.ToString().Trim();

    }
}