using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder) 
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(a => a.CarEntity)
                .WithMany(a => a.ImageEntities)
                .HasForeignKey(a => a.CarId);

            builder.HasOne(a => a.BrandEntity)
                .WithOne(a => a.ImageEntity)
                .HasForeignKey<ImageEntity>(a => a.BrandId);

            builder.HasOne(a => a.GenerationEntity)
                .WithOne(a => a.ImageEntity)
                .HasForeignKey<ImageEntity>(a => a.GenerationId);

            builder.Property(p => p.ImageUrl)
                .IsRequired();
            builder.HasIndex(p => p.ImageUrl)
                .IsUnique();
        }
    }
}
