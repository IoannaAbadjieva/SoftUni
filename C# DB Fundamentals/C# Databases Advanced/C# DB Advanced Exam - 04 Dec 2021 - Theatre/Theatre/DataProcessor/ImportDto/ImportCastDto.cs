namespace Theatre.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Common;

[XmlType("Cast")]
public class ImportCastDto
{
    [XmlElement("FullName")]
    [Required]
    [MinLength(ValidatioConstants.CastFullNameMinLength)]
    [MaxLength(ValidatioConstants.CastFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [XmlElement("IsMainCharacter")]
    [Required]
    public string IsMainCharacter { get; set; } = null!;

    [XmlElement("PhoneNumber")]
    [Required]
    [RegularExpression(ValidatioConstants.CastPhoneNumberRegEx)]
    public string PhoneNumber { get; set; } = null!;

    [XmlElement("PlayId")]
    [Required]
    public int PlayId { get; set; }
}
