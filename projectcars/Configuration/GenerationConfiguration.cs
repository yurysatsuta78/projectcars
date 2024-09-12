using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class GenerationConfiguration : IEntityTypeConfiguration<GenerationEntity>
    {
        public void Configure(EntityTypeBuilder<GenerationEntity> builder)
        {
            builder.HasKey(k => k.GenerationId);

            builder.HasOne(a => a.ModelEntity)
                .WithMany(a => a.GenerationEntities)
                .HasForeignKey(a => a.ModelId);

            builder.Property(p => p.GenerationName)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(p => p.GenerationName)
                .IsUnique();

            builder.Property(p => p.Restyling)
                .IsRequired();

            builder.Property(p => p.StartYear)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(p => p.EndYear)
                .IsRequired()
                .HasMaxLength(5);
        }
    }
}
