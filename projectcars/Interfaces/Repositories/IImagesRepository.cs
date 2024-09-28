using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface IImagesRepository
    {
        Task Create(Image image, Guid? brandId, Guid? generationId);
        Task CreateList(List<Image> images, Guid carId);
        Task<ImageEntity> GetById(Guid id);
        Task Remove(ImageEntity imageEntity);
    }
}