using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<RegionEntity>
    {
        public void Configure(EntityTypeBuilder<RegionEntity> builder) 
        {
            builder.HasKey(k => k.RegionId);

            builder.HasMany(a => a.CityEntities)
                .WithOne(a => a.RegionEntity)
                .HasForeignKey(a => a.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.RegionName)
                .IsRequired()
                .HasMaxLength(80);
            builder.HasIndex(p => p.RegionName)
                .IsUnique();
        }
    }
}
