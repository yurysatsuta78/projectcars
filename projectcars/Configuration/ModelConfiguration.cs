using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class ModelConfiguration : IEntityTypeConfiguration<ModelEntity>
    {
        public void Configure(EntityTypeBuilder<ModelEntity> builder)
        {
            builder.HasKey(k => k.ModelId);

            builder.HasOne(a => a.BrandEntity)
                .WithMany(a => a.ModelEntities)
                .HasForeignKey(a => a.BrandId);

            builder.Property(p => p.ModelName)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(p => p.ModelName)
                .IsUnique();
        }
    }
}
