using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder) 
        {
            builder.HasKey(k => k.Id);

            //builder.HasMany(a => a.Ads)
            //    .WithOne(a => a.UserEntity)
            //    .HasForeignKey(a => a.Id);

            //builder.HasMany(a => a.Featured)
            //    .WithOne(a => a.UserEntity)
            //    .HasForeignKey(a => a.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.SurName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13);
            builder.HasIndex(p => p.PhoneNumber)
                .IsUnique();

            builder.Property(p => p.PasswordHash)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
