using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder) 
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(a => a.GenerationEntity)
                .WithMany(a => a.CarEntities)
                .HasForeignKey(a => a.GenerationId);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.EngineVolume)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.TransmissionType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.BodyType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.EngineType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.DriveTrain)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.EnginePower)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.Mileage)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.IsHidden)
                .IsRequired();

            builder.Property(p => p.Abs)
                .IsRequired();

            builder.Property(p => p.Esp)
                .IsRequired();

            builder.Property(p => p.Asr)
                .IsRequired();

            builder.Property(p => p.Immobilazer)
                .IsRequired();

            builder.Property(p => p.Signaling)
                .IsRequired();
        }
    }
}
