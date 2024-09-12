using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Brand brand)
        {
            var brandEntity = new BrandEntity
            {
                BrandName = brand.BrandName
            };

            await _context.Brands.AddAsync(brandEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<BrandEntity> GetById(int id)
        {
            var brandEntity = await _context.Brands.FirstOrDefaultAsync(m => m.BrandId == id);

            if (brandEntity != null)
            {
                return brandEntity;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Update(BrandEntity brandEntity, Brand brand)
        {
            if (brandEntity != null && brand != null)
            {
                brandEntity.BrandName = brand.BrandName;

                _context.Brands.Update(brandEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Remove(BrandEntity brandEntity)
        {
            if (brandEntity != null)
            {
                _context.Brands.Remove(brandEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<BrandEntity>> GetBrands()
        {
            var brandEntities = await _context.Brands
                .ToListAsync();

            return brandEntities;
        }
    }
}
