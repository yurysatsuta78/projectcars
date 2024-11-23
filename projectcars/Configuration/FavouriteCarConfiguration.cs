using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projectcars.Entities;

namespace projectcars.Configuration
{
    public class FavouriteCarConfiguration : IEntityTypeConfiguration<FavouriteCarEntity>
    {
        public void Configure(EntityTypeBuilder<FavouriteCarEntity> builder) 
        {
            builder.HasKey(k => new { k.UserId, k.CarId });

            builder.HasOne(a => a.UserEntity)
                .WithMany(a => a.FavouriteCars)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(a => a.CarEntity)
                .WithMany(a => a.FavouriteCars)
                .HasForeignKey(a => a.CarId);
        }
    }
}
