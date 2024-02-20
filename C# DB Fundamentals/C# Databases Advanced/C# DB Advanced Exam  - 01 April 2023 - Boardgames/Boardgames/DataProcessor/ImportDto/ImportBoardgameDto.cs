namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Boardgames.Common;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [XmlElement("Name")]
    [Required]
    [MinLength(ValidationConstants.BoardgameNameMinLength)]
    [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement("Rating")]
    [Range(ValidationConstants.BoardgameRatingMinValue, 
        ValidationConstants.BoardgameRatingMaxValue)]
    [Required]
    public double Rating { get; set; }

    [XmlElement("YearPublished")]
    [Range(ValidationConstants.BoardgameYearPublishedMinValue,
        ValidationConstants.BoardgameYearPublishedMaxValue)]
    [Required]
    public int YearPublished { get; set; }

    [XmlElement("CategoryType")]
    [Range(ValidationConstants.BoardgameCategoryTypeMinValue,
        ValidationConstants.BoardgameCategoryTypeMaxValue)]
    [Required]
    public int CategoryType { get; set; }

    [Required]
    public string Mechanics { get; set; } = null!;
}
