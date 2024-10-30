using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface ICitiesRepository
    {
        Task Create(City city);
        Task<CityEntity> GetById(Guid id);
        Task<List<CityEntity>> GetCities();
        Task Remove(CityEntity cityEntity);
        Task Update(CityEntity cityEntity, City city);
    }
}