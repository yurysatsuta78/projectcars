using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class UserAdConfiguration : IEntityTypeConfiguration<UserAdEntity>
    {
        public void Configure(EntityTypeBuilder<UserAdEntity> builder)
        {
            builder.HasKey(k => new { k.UserId, k.CarId });

            builder.HasOne(a => a.UserEntity)
                .WithMany(a => a.UserAds)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(a => a.CarEntity)
                .WithMany(a => a.UserAds)
                .HasForeignKey(a => a.CarId);
        }
    }
}
