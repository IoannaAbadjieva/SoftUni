namespace SeminarHub.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		private readonly Category[] categories = new Category[] 
		{
			new Category()
               {
                   Id = 1,
                   Name = "Technology & Innovation"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Business & Entrepreneurship"
               },
               new Category()
               {
                   Id = 3,
                   Name = "Science & Research"
               },
               new Category()
               {
                   Id = 4,
                   Name = "Arts & Culture"
               }
        };

		public void Configure(EntityTypeBuilder<Category> builder)
		{
            builder
                .HasData(categories);
		}
	}
}
