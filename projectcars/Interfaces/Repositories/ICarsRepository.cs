using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface ICarsRepository
    {
        Task AddCarToFavourites(Guid userId, Guid carId);
        Task<int> CountActiveCars();
        Task Create(Car car);
        Task<List<CarEntity>> GetActiveCars();
        Task<CarEntity> GetById(Guid id);
        Task<List<CarEntity>> GetFiltredCars(CarFilter filter, int take, int skip);
        Task<List<CarEntity>> GetUserFavourites(Guid userId);
        Task Hide(CarEntity carEntity);
        Task Remove(CarEntity carEntity);
        Task RemoveCarFromFavourites(Guid userId, Guid carId);
        Task Update(CarEntity carEntity, Car car);
    }
}