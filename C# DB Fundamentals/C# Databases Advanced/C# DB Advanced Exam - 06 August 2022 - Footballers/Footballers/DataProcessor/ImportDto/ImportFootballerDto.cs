namespace Footballers.DataProcessor.ImportDto;

using Footballers.Common;
using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Footballer")]
public class ImportFootballerDto
{
    [XmlElement("Name")]
    [Required]
    [MinLength(ValidationConstants.FootballerNameMinLength)]
    [MaxLength(ValidationConstants.FootballerNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement("ContractStartDate")]
    [Required]
    public string ContractStartDate { get; set; } = null!;

    [XmlElement("ContractEndDate")]
    [Required]
    public string ContractEndDate { get; set; } = null!;

    [XmlElement("PositionType")]
    [Required]
    [Range(ValidationConstants.FootballerPositionTypeMinValue,
        ValidationConstants.FootballerPositionTypeMaxValue)]
    public int PositionType { get; set; }

    [XmlElement("BestSkillType")]
    [Required]
    [Range(ValidationConstants.FootballerBestSkillTypeMinValue,
        ValidationConstants.FootballerBestSkillTypeMaxValue)]
    public int BestSkillType { get; set; }

}
