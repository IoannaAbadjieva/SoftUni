namespace SoftJail.DataProcessor.ImportDto;

using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

public class ImportDepartmentDto
{
    [Required]
    [MinLength(ValidationConstants.DepartmentNameMinLength)]
    [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
    public string Name { get; set; } = null!;

    public ImportCellDto[] Cells { get; set; } = null!;

}
