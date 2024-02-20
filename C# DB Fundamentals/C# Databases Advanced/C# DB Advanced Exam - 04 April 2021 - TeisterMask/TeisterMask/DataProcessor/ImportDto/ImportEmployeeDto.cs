namespace TeisterMask.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

public class ImportEmployeeDto
{
    [Required]
    [StringLength(40),MinLength(3)]
    [RegularExpression("^[A-Za-z0-9]{3,}$")]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression("^([0-9]{3})-([0-9]{3})-([0-9]{4})$")]
    public string Phone { get; set; } = null!;

    public int[] Tasks { get; set; } = null!;
}
