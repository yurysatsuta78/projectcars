using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projectcars.Configuration;
using projectcars.Entities;

namespace projectcars
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<ModelEntity> Models { get; set; }
        public DbSet<GenerationEntity> Generations { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<RegionEntity> Regions { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FavouriteCarEntity> FavouriteCars { get; set; }
        public DbSet<UserAdEntity> UserAds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ModelConfiguration());
            modelBuilder.ApplyConfiguration(new GenerationConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FavouriteCarConfiguration());
            modelBuilder.ApplyConfiguration(new UserAdConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
