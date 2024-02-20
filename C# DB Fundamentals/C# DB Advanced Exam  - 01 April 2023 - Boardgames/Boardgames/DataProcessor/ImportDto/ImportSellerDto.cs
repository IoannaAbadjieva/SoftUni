namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Boardgames.Common;
using Newtonsoft.Json;

public class ImportSellerDto
{
    [Required]
    [MinLength(ValidationConstants.SellerNameMinLength)]
    [MaxLength(ValidationConstants.SellerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(ValidationConstants.SellerAddressMinLength)]
    [MaxLength(ValidationConstants.SellerAddressMaxLength)]
    public string Address { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.SellerWebiteRegEx)]
    public string Website { get; set; } = null!;

    [JsonProperty("Boardgames")]
    public int[] BoardgamesIds { get; set; } = null!;
}
