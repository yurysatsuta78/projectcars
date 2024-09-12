using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface ICarsRepository
    {
        Task Create(Car car, int generationId);
        Task<List<CarEntity>> GetActiveCars();
        Task<CarEntity> GetById(Guid id);
        Task Hide(CarEntity carEntity);
        Task Update(CarEntity carEntity, Car car);
    }
}