using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface ICarsRepository
    {
        Task<int> CountActiveCars();
        Task Create(Car car);
        Task<List<CarEntity>> GetActiveCars();
        Task<CarEntity> GetById(Guid id);
        //Task<List<CarEntity>> GetFiltredCars(CarFilter filter);
        Task<List<CarEntity>> GetFiltredCars(CarFilter filter, int take, int skip);
        Task Hide(CarEntity carEntity);
        Task Remove(CarEntity carEntity);
        Task Update(CarEntity carEntity, Car car);
    }
}