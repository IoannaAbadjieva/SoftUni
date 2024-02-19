namespace SeminarHub.Models.Seminar
{
    using System.ComponentModel.DataAnnotations;

    using Data.DataValidation;
    using Models.Category;

    public class SeminarFormViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.Seminar.TopicMaxLength,
            MinimumLength = DataConstants.Seminar.TopicMinLength,
            ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.Seminar.LecturerMaxLength,
            MinimumLength = DataConstants.Seminar.LecturerMinLength,
        ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.Seminar.DetailsMaxLength,
            MinimumLength = DataConstants.Seminar.DetailsMinLength,
        ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
        public string Details { get; set; } = string.Empty;

        [Range(DataConstants.Seminar.DurationMinValue,
            DataConstants.Seminar.DurationMaxValue)]
        public int? Duration { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public DateTime DateAndTime { get; set; }

        public IEnumerable<CategoryViewModel> Categories = new CategoryViewModel[] { };
    }
}
