namespace Theatre.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Theatre
{
    public Theatre()
    {
        this.Tickets = new HashSet<Ticket>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidatioConstants.TheatreNameMaxLength)]
    public string Name { get; set; } = null!;

    public sbyte NumberOfHalls  { get; set; }

    [Required]
    [MaxLength(ValidatioConstants.TheatreDirectorMaxLength)]
    public string Director { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; }
}

