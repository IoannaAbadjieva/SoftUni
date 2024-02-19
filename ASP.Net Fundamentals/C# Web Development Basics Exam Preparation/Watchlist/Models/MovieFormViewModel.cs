namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;

    using Data.Validations;

    public class MovieFormViewModel
    {
        [Required]
        [StringLength(DataConstants.Movie.TitleMaxLength, MinimumLength = DataConstants.Movie.TitleMinLength,
            ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstants.Movie.DirectorMaxLength, MinimumLength = DataConstants.Movie.DirectorMinLength,
            ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range(typeof(Decimal), DataConstants.Movie.RatingMinValue, DataConstants.Movie.RatingMaxValue,
            ErrorMessage = ErrorMessages.RatingErrorMessage)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres = new GenreViewModel[] { };
    }
}
