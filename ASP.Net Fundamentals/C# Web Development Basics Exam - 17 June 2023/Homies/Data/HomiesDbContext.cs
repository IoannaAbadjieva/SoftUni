namespace Homies.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Configurations;
    using Homies.Data.Models;

    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Type> Types { get; set; }  

        public DbSet<Event> Events { get; set; }

        public DbSet<EventParticipant> EventsParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventParticipantConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}