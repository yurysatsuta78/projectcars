using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<BrandEntity>
    {
        public void Configure(EntityTypeBuilder<BrandEntity> builder)
        {
            builder.HasKey(k => k.BrandId);

            builder.Property(p => p.BrandName)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(p => p.BrandName)
                .IsUnique();
        }
    }
}
