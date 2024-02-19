namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.Book;

    public class AddBookViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;


        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;


        [Required]
         public string Url { get; set; } = null!;

        [Required]
        [Range(typeof(Decimal), RatingMinLength, RatingMaxLength)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public CategoryViewModel[] Categories { get; set; } = new CategoryViewModel[] { };

    }
}
