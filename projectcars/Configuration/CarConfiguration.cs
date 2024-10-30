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

            builder.HasOne(a => a.CityEntity)
                .WithMany(a => a.CarEntities)
                .HasForeignKey(a => a.CityId);

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

            builder.Property(p => p.ProdYear)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.InteriorColor)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.InteriorMaterial)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(350);

            builder.Property(p => p.CarState)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.RegistrationCountry)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.TowBar)
                .IsRequired();

            builder.Property(p => p.RoofRails)
                .IsRequired();

            builder.Property(p => p.SunRoof)
                .IsRequired();

            builder.Property(p => p.PanoramicRoof)
                .IsRequired();

            builder.Property(p => p.RainSensor)
                .IsRequired();

            builder.Property(p => p.RearViewCamera)
                .IsRequired();

            builder.Property(p => p.ParkingSensors)
                .IsRequired();

            builder.Property(p => p.BlindSpotSensor)
                .IsRequired();

            builder.Property(p => p.HeatedSeats)
                .IsRequired();

            builder.Property(p => p.HeatedWindshield)
                .IsRequired();

            builder.Property(p => p.HeatedMirrors)
                .IsRequired();

            builder.Property(p => p.HeatedSteeringWheel)
                .IsRequired();

            builder.Property(p => p.AutonomousHeater)
                .IsRequired();

            builder.Property(p => p.ClimateControl)
                .IsRequired();

            builder.Property(p => p.AirConditioner)
                .IsRequired();

            builder.Property(p => p.CruiseControl)
                .IsRequired();

            builder.Property(p => p.SteeringWheelMultimedia)
                .IsRequired();

            builder.Property(p => p.ElectricSeats)
                .IsRequired();

            builder.Property(p => p.FrontElectroWindows)
                .IsRequired();

            builder.Property(p => p.RearElectroWindows)
                .IsRequired();

            builder.Property(p => p.AirBags)
                .IsRequired();

            builder.Property(p => p.IsTradable)
                .IsRequired();

            builder.Property(p => p.IsRegistred)
                .IsRequired();

            builder.Property(p => p.IsHidden)
                .IsRequired();

            builder.Property(p => p.Abs)
                .IsRequired();

            builder.Property(p => p.Esp)
                .IsRequired();

            builder.Property(p => p.Asr)
                .IsRequired();

            builder.Property(p => p.Immobilizer)
                .IsRequired();

            builder.Property(p => p.Signaling)
                .IsRequired();
        }
    }
}
