using projectcars.Entities;
using projectcars.Interfaces.Interfaces;
using projectcars.Models;

namespace projectcars.Interfaces.Services
{
    public interface IImagesService
    {
        Task<List<TModel>> ConvertBrandImageCollectionToBase64<TModel, TEntity>(List<TEntity> entities) where TEntity : IHasImages;
        Task<List<TModel>> ConvertBrandImagesToBase64<TModel, TEntity>(List<TEntity> entities) where TEntity : IHasImage;
        void DeleteImage(string filePath);
        Task<Image> UploadImage(IFormFile image, Guid? carId, Guid? brandId, Guid? generationId);
    }
}