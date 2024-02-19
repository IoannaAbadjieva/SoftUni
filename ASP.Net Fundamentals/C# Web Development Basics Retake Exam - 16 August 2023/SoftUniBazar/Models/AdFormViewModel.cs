namespace SoftUniBazar.Models
{
	using System.ComponentModel.DataAnnotations;

	using Validations;

	public class AdFormViewModel
	{
		[Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
		[StringLength(ValidationConstants.Ad.NameMaxLength,
			MinimumLength = ValidationConstants.Ad.NameMinLength,
			ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
		[StringLength(ValidationConstants.Ad.DescriptionMaxLength,
			MinimumLength = ValidationConstants.Ad.DescriptionMinLength,
			ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
		public string ImageUrl { get; set; } = string.Empty;

		[Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
		public decimal Price { get; set; } 

		[Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
		public int CategoryId { get; set; }

		public IEnumerable<CategoryViewModel> Categories { get; set; } = new CategoryViewModel[] { };
	}
}
