using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface IModelsRepository
    {
        Task Create(Model model, Guid brandId);
        Task<ModelEntity> GetById(Guid id);
        Task<List<ModelEntity>> GetModels();
        Task Remove(ModelEntity modelEntity);
        Task Update(ModelEntity modelEntity, Model model);
    }
}