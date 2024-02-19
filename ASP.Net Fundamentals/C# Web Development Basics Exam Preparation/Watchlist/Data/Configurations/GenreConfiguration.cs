namespace Watchlist.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        private Genre[] initial = new Genre[]
        {
                 new Genre()
                 {
                     Id = 1,
                     Name = "Action"
                 },
                 new Genre()
                 {
                     Id = 2,
                     Name = "Comedy"
                 },
                 new Genre()
                 {
                     Id = 3,
                     Name = "Drama"
                 },
                 new Genre()
                 {
                     Id = 4,
                     Name = "Horror"
                 },
                 new Genre()
                 {
                     Id = 5,
                     Name = "Romantic"
                 }
        };

        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                 .HasData(initial);
        }
    }
}
