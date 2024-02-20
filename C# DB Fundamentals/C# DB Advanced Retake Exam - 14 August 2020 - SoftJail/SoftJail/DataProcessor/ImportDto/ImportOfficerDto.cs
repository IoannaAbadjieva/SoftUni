namespace SoftJail.DataProcessor.ImportDto;

using SoftJail.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Officer")]
public class ImportOfficerDto
{
    [XmlElement("Name")]
    [Required]
    [MinLength(ValidationConstants.OfficerFullNameMinLength)]
    [MaxLength(ValidationConstants.OfficerFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [XmlElement("Money")]
    [Range(typeof(decimal),ValidationConstants.OfficerSalaryMinValue,ValidationConstants.OfficerSalaryMaxValue)]
    [Required]
    public decimal Salary { get; set; }

    [XmlElement("Position")]
    [Required]
    public string Position { get; set; } = null!;

    [XmlElement("Weapon")]
    [Required]
    public string Weapon { get; set; } = null!;

    [Required]
    public int DepartmentId { get; set; }

    [XmlArray("Prisoners")]
    public ImportOfficerPrisonerDto[] Prisoners { get; set; } = null!;
}
