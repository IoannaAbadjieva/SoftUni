namespace VaporStore.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Data;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.ImportDto;

public static class Deserializer
{
    public const string ErrorMessage = "Invalid Data";

    public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

    public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

    public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

    public static string ImportGames(VaporStoreDbContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

        ICollection<Game> validGames = new HashSet<Game>();
        ICollection<Developer> developers = new HashSet<Developer>();
        ICollection<Genre> genres = new HashSet<Genre>();
        ICollection<Tag> tags = new HashSet<Tag>();

        foreach (var gameDto in gameDtos)
        {
            if (!IsValid(gameDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate,
                "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (!gameDto.Tags.Any())
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Developer developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);
            if (developer == null)
            {
                developer = new Developer() { Name = gameDto.Developer };
                developers.Add(developer);
            }

            Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);
            if (genre == null)
            {
                genre = new Genre() { Name = gameDto.Genre };
                genres.Add(genre);
            }

            Game game = new Game()
            {
                Name = gameDto.Name,
                Price = gameDto.Price,
                ReleaseDate = releaseDate,
                Developer = developer,
                Genre = genre
            };

            foreach (var tagName in gameDto.Tags)
            {
                Tag tag = tags.FirstOrDefault(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = new Tag() { Name = tagName };
                    tags.Add(tag);
                }

                game.GameTags.Add(new GameTag()
                {
                    Tag = tag
                });
            }

            validGames.Add(game);
            sb.AppendLine(string.Format(SuccessfullyImportedGame,
                game.Name, game.Genre.Name, game.GameTags.Count));
        }

        context.Games.AddRange(validGames);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportUsers(VaporStoreDbContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

        ICollection<User> validUsers = new HashSet<User>();

        foreach (var userDto in userDtos)
        {
            if (!IsValid(userDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (!userDto.Cards.Any())
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            ICollection<Card> validCards = new HashSet<Card>();
            bool isCardsValid = true;

            foreach (var cardDto in userDto.Cards)
            {
                if (!IsValid(cardDto))
                {
                    sb.AppendLine(ErrorMessage);
                    isCardsValid = false;
                    break;
                }

                bool isCardTypeValid = Enum.TryParse(cardDto.Type, out CardType type);
                if (!isCardTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    isCardsValid = false;
                    break;
                }

                Card card = new Card()
                {
                    Number = cardDto.Number,
                    Cvc = cardDto.Cvc,
                    Type = type
                };

                validCards.Add(card);
            }

            if (!isCardsValid || !validCards.Any())
            {
                continue;
            }

            User user = new User()
            {
                Username = userDto.Username,
                FullName = userDto.FullName,
                Email = userDto.Email,
                Age = userDto.Age,
                Cards = validCards
            };

            validUsers.Add(user);
            sb.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, validCards.Count));
        }

        context.Users.AddRange(validUsers);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

        ImportPurchaseDto[] purchaseDtos =
            (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

        ICollection<Purchase> validPurchases = new HashSet<Purchase>();

        foreach (var purchaseDto in purchaseDtos)
        {
            if (!IsValid(purchaseDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isTypeValid = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType type);
            if (!isTypeValid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
            if (!isDateValid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);
            if (card == null)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Game);
            if (game == null)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Purchase purchase = new Purchase()
            {
                Type = type,
                ProductKey = purchaseDto.ProductKey,
                Date = date,
                Card = card,
                Game = game
            };
            validPurchases.Add(purchase);
            sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User.Username));
        }

        context.Purchases.AddRange(validPurchases);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}