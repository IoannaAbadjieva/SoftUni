namespace VaporStore.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ImportGameDto
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [Range(typeof(decimal), ValidationConstants.GamePriceMinValue,
        ValidationConstants.GamePriceMaxValue)]
    public decimal Price { get; set; }

    [Required]
    public string ReleaseDate { get; set; } = null!;

    [Required]
    public string Developer { get; set; } = null!;

    [Required]
    public string Genre { get; set; } = null!;

    public string[] Tags { get; set; } = null!;
}
