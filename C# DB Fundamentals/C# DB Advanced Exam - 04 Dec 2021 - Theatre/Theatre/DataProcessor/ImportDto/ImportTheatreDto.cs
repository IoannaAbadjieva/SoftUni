namespace Theatre.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ImportTheatreDto
{

    [Required]

    [MinLength(ValidatioConstants.TheatreNameMinLength)]
    [MaxLength(ValidatioConstants.TheatreNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(typeof(sbyte),ValidatioConstants.TheatreNumberOfHallsMinValue,
        ValidatioConstants.TheatreNumberOfHallsMaxValue)]
    public sbyte NumberOfHalls { get; set; }

    [Required]
    [MinLength(ValidatioConstants.TheatreDirectorMinLength)]
    [MaxLength(ValidatioConstants.TheatreDirectorMaxLength)]
    public string Director { get; set; } = null!;

    public ImportTicketDto[] Tickets { get; set; } = null!;
}
