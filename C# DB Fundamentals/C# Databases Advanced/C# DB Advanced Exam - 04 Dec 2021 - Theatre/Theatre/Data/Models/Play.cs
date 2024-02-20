namespace Theatre.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;
using Enums;

public class Play
{
    public Play()
    {
        this.Casts = new HashSet<Cast>();
        this.Tickets = new HashSet<Ticket>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidatioConstants.PlayTitleMaxLength)]
    public string Title { get; set; } = null!;

    public TimeSpan Duration { get; set; }

    public float Rating { get; set; }

    public Genre Genre { get; set; }

    [Required]
    [MaxLength(ValidatioConstants.PlayDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(ValidatioConstants.PlayScreenwriterMaxLength)]
    public string Screenwriter { get; set; } = null!;

    public virtual ICollection<Cast> Casts { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; }
}
