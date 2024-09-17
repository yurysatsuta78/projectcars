using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface IBrandsRepository
    {
        Task Create(Brand brand);
        Task<List<BrandEntity>> GetBrands();
        Task<BrandEntity> GetById(Guid id);
        Task Remove(BrandEntity brandEntity);
        Task Update(BrandEntity brandEntity, Brand brand);
    }
}