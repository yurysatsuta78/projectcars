using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projectcars.Entities;
using projectcars.Enums;

namespace projectcars.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder) 
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(p => p.UserAds)
                .WithOne(p => p.UserEntity)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.FavouriteCars)
                .WithMany(p => p.UsersByFavourites)
                .UsingEntity<UserFavouriteCarEntity>(
                    l => l.HasOne(b => b.CarEntity).WithMany().HasForeignKey(r => r.CarId).OnDelete(DeleteBehavior.Restrict),
                    r => r.HasOne<UserEntity>().WithMany().HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.Restrict));

            builder.HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity<UserRoleEntity>(
                    l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId).OnDelete(DeleteBehavior.Restrict),
                    r => r.HasOne<UserEntity>().WithMany().HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.Restrict));

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.SurName)
                .IsRequired()
                .HasMaxLength(50);

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
