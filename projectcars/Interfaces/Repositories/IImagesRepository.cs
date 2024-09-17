using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface IImagesRepository
    {
        Task Create(Image image, Guid? carId, Guid? brandId, Guid? generationId);
        Task<List<ImageEntity>> GetBrandImages(Guid brandId);
        Task<List<ImageEntity>> GetCarImages(Guid carId);
        Task<List<ImageEntity>> GetGenerationImages(Guid generationId);
    }
}