namespace SoftUniBazar.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class AdBuyerConfiguration : IEntityTypeConfiguration<AdBuyer>
	{
		public void Configure(EntityTypeBuilder<AdBuyer> builder)
		{
			builder
				.HasKey(ab => new { ab.BuyerId, ab.AdId });

			builder
				.HasOne(ab => ab.Buyer)
				.WithMany()
				.HasForeignKey(ab => ab.BuyerId)
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
