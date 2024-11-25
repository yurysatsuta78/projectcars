using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder) 
        {
            builder.HasKey(k => k.CityId);

            builder.HasMany(a => a.CarEntities)
                .WithOne(a => a.CityEntity)
                .HasForeignKey(a => a.CityId);

            builder.Property(p => p.CityName)
                .IsRequired()
                .HasMaxLength(80);
            builder.HasIndex(p => p.CityName)
                .IsUnique();
        }
    }
}
