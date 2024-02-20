namespace SoftJail.DataProcessor.ExportDto;

using SoftJail.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Prisoner")]
public class ExportPrisonerDto
{
    [XmlElement("Id")]
    public int Id { get; set; }

    [XmlElement("Name")]
    public string FullName { get; set; } = null!;

    [XmlElement("IncarcerationDate")]
    public string IncarcerationDate { get; set; } = null!;

    [XmlArray("EncryptedMessages")]
    public ExportMailDto[] Mails { get; set; } = null!;
}
