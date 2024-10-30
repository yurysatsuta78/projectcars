using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly ApplicationDbContext _context;

        public RegionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Region region)
        {
            var regionEntity = new RegionEntity
            {
                RegionId = region.RegionId,
                RegionName = region.RegionName,
            };

            await _context.Regions.AddAsync(regionEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<RegionEntity> GetById(Guid id)
        {
            var regionEntity = await _context.Regions.FirstOrDefaultAsync(m => m.RegionId == id);

            if (regionEntity != null)
            {
                return regionEntity;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Update(RegionEntity regionEntity, Region region)
        {
            if (regionEntity != null && region != null)
            {
                regionEntity.RegionName = region.RegionName;

                _context.Regions.Update(regionEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Remove(RegionEntity regionEntity)
        {
            if (regionEntity != null)
            {
                _context.Regions.Remove(regionEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<RegionEntity>> GetRegions()
        {
            return await _context.Regions
                .OrderBy(b => b.RegionName)
                .ToListAsync();
        }
    }
}
