namespace SoftJail.DataProcessor.ImportDto;

using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

public class ImportPrisonerDto
{
    [Required]
    [MinLength(ValidationConstants.PrisonerFullNameMinLength)]
    [MaxLength(ValidationConstants.PrisonerFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.PrisonerNicknameRegEx)]
    public string Nickname { get; set; } = null!;

    [Required]
    [Range(ValidationConstants.PrisonerAgeMinValue, ValidationConstants.PrisonerAgeMaxValue)]
    public int Age { get; set; }

    [Required]
    public string IncarcerationDate { get; set; } = null!;

    public string? ReleaseDate { get; set; }

    [Range(typeof(decimal),ValidationConstants.PrisonerBailMinValue,ValidationConstants.PrisonerBailMaxValue)]
    public decimal? Bail { get; set; }

    public int? CellId { get; set; }

   public ImportMailDto[] Mails { get; set; } = null!;
}
