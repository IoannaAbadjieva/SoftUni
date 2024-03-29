﻿namespace SoftJail.Data.Models;

using SoftJail.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Prisoner
{
    public Prisoner()
    {
        this.Mails = new HashSet<Mail>();
        this.PrisonerOfficers = new HashSet<OfficerPrisoner>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PrisonerFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    public string Nickname { get; set; } = null!;

    public int Age { get; set; }

    public DateTime IncarcerationDate { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public decimal? Bail { get; set; }

    [ForeignKey(nameof(Cell))]
    public int? CellId { get; set; }
    public virtual Cell? Cell { get; set; }

    public virtual ICollection<Mail> Mails { get; set; }

    public virtual ICollection<OfficerPrisoner> PrisonerOfficers  { get; set; }
}
