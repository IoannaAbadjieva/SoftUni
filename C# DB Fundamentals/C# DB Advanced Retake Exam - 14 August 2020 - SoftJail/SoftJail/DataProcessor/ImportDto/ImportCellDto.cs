namespace SoftJail.DataProcessor.ImportDto;

using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

public class ImportCellDto
{
    [Required]
    [Range(ValidationConstants.CellNumberMinValue, ValidationConstants.CellNumberMaxValue)]
    public int CellNumber { get; set; }

    [Required]
    public bool HasWindow { get; set; }
}
