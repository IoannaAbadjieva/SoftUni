﻿namespace Artillery.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Country")]
public class ExportGunCountryDto
{
    [XmlAttribute("Country")]
    public string CountryName { get; set; } = null!;

    [XmlAttribute("ArmySize")]
    public int ArmySize { get; set; }
}
