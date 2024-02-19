namespace SoftUniBazar.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using SoftUniBazar.Data.Models;

	public class AdConfiguration : IEntityTypeConfiguration<Ad>
	{
		public void Configure(EntityTypeBuilder<Ad> builder)
		{
			builder
				.Property(p => p.Price)
				.HasPrecision(18, 2);
		}
	}
}
