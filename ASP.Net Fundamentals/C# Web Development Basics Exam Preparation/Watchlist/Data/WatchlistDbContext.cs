namespace Watchlist.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Configurations;
    using Models;

    public class WatchlistDbContext : IdentityDbContext
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new GenreConfiguration());

            builder
                .ApplyConfiguration(new MovieConfiguration());

            builder.Entity<UserMovie>()
                      .HasKey(um => new { um.UserId, um.MovieId });

            base.OnModelCreating(builder);
        }
    }
}