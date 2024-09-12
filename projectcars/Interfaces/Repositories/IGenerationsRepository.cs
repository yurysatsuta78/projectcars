using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface IGenerationsRepository
    {
        Task Create(Generation generation, int modelId);
        Task<GenerationEntity> GetById(int id);
        Task<List<GenerationEntity>> GetGenerations();
        Task Remove(GenerationEntity generationEntity);
        Task Update(GenerationEntity generationEntity, Generation generation);
    }
}