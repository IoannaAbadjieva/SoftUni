namespace Theatre.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using Common;

public class ImportTicketDto
{
    [Required]
    [Range(typeof(decimal),ValidatioConstants.TicketPriceMinValue,
        ValidatioConstants.TicketPriceMaxValue)]
    public decimal Price { get; set; }
        
    [Required]
    [Range(typeof(sbyte),ValidatioConstants.TicketRowNumberMinValue, 
        ValidatioConstants.TicketRowNumberMaxValue)]
    public sbyte RowNumber { get; set; }

    [Required]
    public int PlayId { get; set; }
}
