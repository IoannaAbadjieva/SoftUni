namespace Theatre.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Common;


[XmlType("Play")]
public class ImportPlayDto
{
    [XmlElement("Title")]
    [Required]
    [MinLength(ValidatioConstants.PlayTitleMinLength)]
    [MaxLength(ValidatioConstants.PlayTitleMaxLength)]
    public string Title { get; set; } = null!;

    [XmlElement("Duration")]
    [Required]
    public string Duration { get; set; } = null!;

    [XmlElement("Raiting")]
    [Required]
    [Range(ValidatioConstants.PlayRatingMinValue, ValidatioConstants.PlayRatingMaxValue)]
    public float Rating { get; set; }

    [XmlElement("Genre")]
    [Required]
    public string Genre { get; set; } = null!;

    [XmlElement("Description")]
    [Required]
    [MaxLength(ValidatioConstants.PlayDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [XmlElement("Screenwriter")]
    [Required]
    [MinLength(ValidatioConstants.PlayScreenwriterMinLength)]
    [MaxLength(ValidatioConstants.PlayScreenwriterMaxLength)]
    public string Screenwriter { get; set; } = null!;
}
