namespace SoftUniBazar.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static SoftUniBazar.Validations.ValidationConstants.Category;

	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = string.Empty;

		public ICollection<Ad> Ads { get; set; } = new HashSet<Ad>();
	}
}