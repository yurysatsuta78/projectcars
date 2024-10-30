using projectcars.Models;

namespace projectcars.Interfaces.Services
{
    public interface IGoogleDriveService
    {
        Task<Image> UploadImage(IFormFile image, Guid? carId, Guid? brandId, Guid? generationId);
        Task<Image> UploadImageToFolder(IFormFile image, Guid? carId, Guid? brandId, Guid? generationId);
    }
}