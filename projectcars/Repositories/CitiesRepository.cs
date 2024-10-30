using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly ApplicationDbContext _context;

        public CitiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(City city)
        {
            var cityEntity = new CityEntity
            {
                CityId = city.CityId,
                CityName = city.CityName,
                RegionId = city.RegionId,
            };

            await _context.Cities.AddAsync(cityEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<CityEntity> GetById(Guid id)
        {
            var cityEntity = await _context.Cities.FirstOrDefaultAsync(m => m.CityId == id);

            if (cityEntity != null)
            {
                return cityEntity;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Update(CityEntity cityEntity, City city)
        {
            if (cityEntity != null && city != null)
            {
                cityEntity.CityName = city.CityName;
                cityEntity.RegionId = city.RegionId;

                _context.Cities.Update(cityEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Remove(CityEntity cityEntity)
        {
            if (cityEntity != null)
            {
                _context.Cities.Remove(cityEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<CityEntity>> GetCities()
        {
            return await _context.Cities
                .OrderBy(b => b.CityName)
                .ToListAsync();
        }
    }
}
