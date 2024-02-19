namespace SoftUniBazar.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.AspNetCore.Identity;

	using static SoftUniBazar.Validations.ValidationConstants.Ad;

	public class Ad
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = string.Empty;

		[Required]
		public decimal Price { get; set; }

		[Required]
		public string OwnerId { get; set; } = string.Empty;

		public IdentityUser Owner { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = string.Empty;

		[Required]
		public DateTime CreatedOn { get; set; }

		[Required]
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }

		public Category Category { get; set; } = null!;
	}

}
