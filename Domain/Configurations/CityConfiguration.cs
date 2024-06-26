using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Population).IsRequired();
            builder.Property(m => m.CountryId).IsRequired();
        }
    }
}
