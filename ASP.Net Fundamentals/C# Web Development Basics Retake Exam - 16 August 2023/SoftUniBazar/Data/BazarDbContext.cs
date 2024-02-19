namespace SoftUniBazar.Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using Configurations;
	using Models;

	public class BazarDbContext : IdentityDbContext
	{
		public BazarDbContext(DbContextOptions<BazarDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new AdConfiguration());
			modelBuilder.ApplyConfiguration(new AdBuyerConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Ad> Ads { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<AdBuyer> AdsBuyers { get; set; }
	}
}