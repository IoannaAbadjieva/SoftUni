namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;

[XmlType("Truck")]
public class ImportTruckDto
{
    [XmlElement("RegistrationNumber")]
    [Required]
    [MinLength(ValidationConstants.RegistrationNumberLength)]
    [MaxLength(ValidationConstants.RegistrationNumberLength)]
    [RegularExpression(ValidationConstants.RegistrationNumberRegEx)]
    public string RegistrationNumber { get; set; } = null!;

    [XmlElement("VinNumber")]
    [Required]
    [MinLength(ValidationConstants.VinNumberLength)]
    [MaxLength(ValidationConstants.VinNumberLength)]
    public string VinNumber { get; set; } = null!;

    [XmlElement("TankCapacity")]
    [Range(ValidationConstants.TankCapacityMinValue,ValidationConstants.TankCapacityMaxValue)]
    public int TankCapacity { get; set; }

    [XmlElement("CargoCapacity")]
    [Range(ValidationConstants.CargoCapacityMinValue,ValidationConstants.CargoCapacityMaxValue)]
    public int CargoCapacity { get; set; }

    [XmlElement("CategoryType")]
    [Required]
    [Range(ValidationConstants.CategoryTypeMinValue,ValidationConstants.CategoryTypeMaxValue)]
    public int CategoryType { get; set; }

    [XmlElement("MakeType")]
    [Range(ValidationConstants.MakeTypeMinValue, ValidationConstants.MakeTypeMaxValue)]
    public int MakeType { get; set; }
}
