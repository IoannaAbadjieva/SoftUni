namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class EventParticipant
    {
        [Required]
        [ForeignKey(nameof(Helper))]
        public string HelperId {  get; set; } = string.Empty;

        public IdentityUser Helper { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Event))]
        public int EventId {  get; set; }

        public Event Event { get; set; } = null!;
    }
}