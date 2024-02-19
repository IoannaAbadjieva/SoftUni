namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Validations.DataConstants.Genre;

    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}