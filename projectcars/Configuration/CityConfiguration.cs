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

            builder.HasOne(a => a.RegionEntity)
                .WithMany(a => a.CityEntities)
                .HasForeignKey(a => a.RegionId);

            builder.Property(p => p.CityName)
                .IsRequired()
                .HasMaxLength(80);
            builder.HasIndex(p => p.CityName)
                .IsUnique();
        }
    }
}
