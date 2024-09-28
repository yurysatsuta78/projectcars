using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface ICarsRepository
    {
        Task Create(Car car, Guid generationId);
        Task<List<CarEntity>> GetActiveCars();
        Task<CarEntity> GetById(Guid id);
        Task<List<CarEntity>> GetFiltredCars(CarFilter filter);
        Task Hide(CarEntity carEntity);
        Task Remove(CarEntity carEntity);
        Task Update(CarEntity carEntity, Car car);
    }
}