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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ModelConfiguration());
            modelBuilder.ApplyConfiguration(new GenerationConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
