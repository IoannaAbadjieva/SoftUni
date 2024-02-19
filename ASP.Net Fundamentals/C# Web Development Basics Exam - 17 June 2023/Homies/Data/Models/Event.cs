namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using static DataValidations.DataConstants;

    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string OrganiserId { get; set; } = string.Empty;

        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = DateFormat)]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set;}

        [Required]
        public DateTime End { get; set;}

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public Type Type { get; set; } = null!;

        public ICollection<EventParticipant> EventsParticipants = new HashSet<EventParticipant>();
    }
}
