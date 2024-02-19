namespace SoftUniBazar.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		private readonly Category[] initial = new Category[]
		{
			new Category()
				{
					Id = 1,
					Name = "Books"
				},
				new Category()
				{
					Id = 2,
					Name = "Cars"
				},
				new Category()
				{
					Id = 3,
					Name = "Clothes"
				},
				new Category()
				{
					Id = 4,
					Name = "Home"
				},
				new Category()
				{
					Id = 5,
					Name = "Technology"
				}
		};

		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder
				.HasData(initial);
		}
	}
}
