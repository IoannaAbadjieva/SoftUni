namespace Homies.Models
{
    using System.ComponentModel.DataAnnotations;

    using Data.DataValidations;

    public class EventFormViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.EventNameMaxLength, MinimumLength = DataConstants.EventNameMinLength,
            ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.EventDescriptionMaxLength, MinimumLength = DataConstants.EventDescriptionMinLength,
          ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public DateTime Start { get; set; } 

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public DateTime End { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types = new TypeViewModel[] { };
    }
}
