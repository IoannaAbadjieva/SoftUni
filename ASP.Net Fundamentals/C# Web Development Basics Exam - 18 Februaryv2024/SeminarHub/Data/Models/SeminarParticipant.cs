namespace SeminarHub.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Microsoft.AspNetCore.Identity;

	public class SeminarParticipant
	{
		[Required]
		[ForeignKey(nameof(Seminar))]
		public int SeminarId {  get; set; }

		public Seminar Seminar { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Participant))]
		public string ParticipantId {  get; set; } = string.Empty;

		public IdentityUser Participant { get; set; } = null!;
	}
}