namespace VaporStore.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Common;

[XmlType("Purchase")]
public class ImportPurchaseDto
{
    [XmlElement("Type")]
    [Required]
    public string Type { get; set; } = null!;

    [XmlElement("Key")]
    [Required]
    [RegularExpression(ValidationConstants.PurchaseProductKeyRegEx)]
    public string ProductKey { get; set; } = null!;

    [XmlElement("Date")]
    [Required]
    public string Date { get; set; } = null!;

    [XmlElement("Card")]
    [Required]
    public string Card { get; set; } = null!;

    [XmlAttribute("title")]
    [Required]
    public string Game { get; set; } = null!;
}
