namespace VaporStore.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ImportCardDto
{
    [Required]
    [RegularExpression(ValidationConstants.CardNumberRegEx)]
    public string Number { get; set; } = null!;

    [Required]
    [RegularExpression(ValidationConstants.CardCvcRegEx)]
    public string Cvc { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;
}
