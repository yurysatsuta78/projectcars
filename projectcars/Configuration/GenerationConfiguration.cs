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

            builder.HasMany(a => a.CarEntities)
                .WithOne(a => a.GenerationEntity)
                .HasForeignKey(a => a.GenerationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.GenerationName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Restyling)
                .IsRequired();

            builder.Property(p => p.StartYear)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(p => p.EndYear)
                .IsRequired()
                .HasMaxLength(5);

            builder.HasIndex(p => new { p.GenerationName, p.ModelId })
                .IsUnique();
        }
    }
}
