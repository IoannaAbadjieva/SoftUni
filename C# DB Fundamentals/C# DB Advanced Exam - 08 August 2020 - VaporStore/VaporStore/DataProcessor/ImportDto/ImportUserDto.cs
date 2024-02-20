namespace VaporStore.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

public class ImportUserDto
{
    [Required]
    [RegularExpression(ValidationConstants.UserFullNameRegEx)]
    public string FullName { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.UsernameMinLength)]
    [MaxLength(ValidationConstants.UsernameMaxLength)]
    public string Username { get; set; } = null!;

    [Required]
    //[EmailAddress]
    public string Email { get; set; } = null!;

    [Range(ValidationConstants.UserAgeMinValue, ValidationConstants.UserAgeMaxValue)]
    public int Age { get; set; }

    public ImportCardDto[] Cards { get; set; } = null!;

}
