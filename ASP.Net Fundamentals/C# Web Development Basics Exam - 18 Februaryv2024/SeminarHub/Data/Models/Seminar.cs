using SeminarHub.Data.DataValidation;

namespace SeminarHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using static DataConstants.Seminar;

    public class Seminar
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(TopicMaxLength)]
		public string Topic { get; set; } = string.Empty;

		[Required]
		[MaxLength(LecturerMaxLength)]
		public string Lecturer { get; set; } = string.Empty;

		[Required]
		[MaxLength(DetailsMaxLength)]
		public string Details { get; set; } = string.Empty;

		[Required]
		public string OrganizerId { get; set; } = string.Empty;

		public IdentityUser Organizer { get; set; } = null!;

		[Required]
		public DateTime DateAndTime { get; set; }

		public int? Duration { get; set; }

		[Required]
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }

		public Category Category { get; set; } = null!;

		public ICollection<SeminarParticipant> SeminarsParticipants = new HashSet<SeminarParticipant>();
	}
}
