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

            builder.HasMany(a => a.GenerationEntities)
                .WithOne(a => a.ModelEntity)
                .HasForeignKey(a => a.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.ModelName)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(p => p.ModelName)
                .IsUnique();
        }
    }
}
