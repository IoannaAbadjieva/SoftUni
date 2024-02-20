namespace SoftJail.DataProcessor.ImportDto;

using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

public class ImportMailDto
{

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string Sender { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.mailAddressRegEx)]
    public string Address { get; set; } = null!;
}
