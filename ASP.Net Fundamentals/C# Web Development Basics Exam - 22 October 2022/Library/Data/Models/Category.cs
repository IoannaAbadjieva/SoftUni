namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.ValidationConstants.Category;

    public class Category
	{
	
		[Key]
		public int Id { get; set; }

		
		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public ICollection<Book> Books { get; set; } = new HashSet<Book>();
	}
}
