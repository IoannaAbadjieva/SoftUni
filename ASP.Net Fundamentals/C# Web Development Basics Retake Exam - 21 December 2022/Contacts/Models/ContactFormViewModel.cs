namespace Contacts.Models
{
    using System.ComponentModel.DataAnnotations;

    using Data.Validations;

    public class ContactFormViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.ContactNameMaxLength, ErrorMessage = ErrorMessages.StringLengthErrorMessage,
            MinimumLength = DataConstants.FirstNameMinLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.ContactNameMaxLength, ErrorMessage = ErrorMessages.StringLengthErrorMessage,
           MinimumLength = DataConstants.LastNameMinLength)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [RegularExpression(DataConstants.PhoneNumberRegEx, ErrorMessage = ErrorMessages.PhoneErrorMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; }


        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [RegularExpression(DataConstants.WebsiteRegEx, ErrorMessage = ErrorMessages.WebsiteErrorMessage)]
        public string Website { get; set; } = string.Empty;
    }
}
