namespace SeminarHub.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class SeminarParticipantConfiguration : IEntityTypeConfiguration<SeminarParticipant>
	{
		public void Configure(EntityTypeBuilder<SeminarParticipant> builder)
		{
			builder
				.HasKey(sp => new { sp.SeminarId, sp.ParticipantId });

			builder
				.HasOne(sp => sp.Seminar)
				.WithMany(s => s.SeminarsParticipants)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
