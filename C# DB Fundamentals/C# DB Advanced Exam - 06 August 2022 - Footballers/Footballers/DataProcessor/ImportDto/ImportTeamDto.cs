namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Footballers.Common;

public class ImportTeamDto
{
    [Required]
    [MinLength(ValidationConstants.TeamNameMinLength)]
    [MaxLength(ValidationConstants.TeamNameMaxLength)]
    [RegularExpression(ValidationConstants.TeamNameRegEx)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.TeamNationalityMinLength)]
    [MaxLength(ValidationConstants.TeamNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    [Range(ValidationConstants.TeamTrophiesMinValue,int.MaxValue)]
    public int Trophies { get; set; }

    public int[] Footballers { get; set; } = null!;
}
