using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface IRegionsRepository
    {
        Task Create(Region region);
        Task<RegionEntity> GetById(Guid id);
        Task<List<RegionEntity>> GetRegions();
        Task Remove(RegionEntity regionEntity);
        Task Update(RegionEntity regionEntity, Region region);
    }
}