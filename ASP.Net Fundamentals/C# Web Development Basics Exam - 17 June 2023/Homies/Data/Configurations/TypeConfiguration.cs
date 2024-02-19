namespace Homies.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class TypeConfiguration : IEntityTypeConfiguration<Type>
    {
        private readonly Type[] initialTypes = new Type[]
        {
            new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
            new Type()
            {
                Id = 2,
                Name = "Fun"
            },
            new Type()
            {
                Id = 3,
                Name = "Discussion"
            },
            new Type()
            {
                Id = 4,
                Name = "Work"
            }
        };

        public void Configure(EntityTypeBuilder<Type> builder)
        {

            builder
                .HasData(initialTypes);
        }
    }
}
