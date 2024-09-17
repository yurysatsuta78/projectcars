using AutoMapper;
using projectcars.Entities;
using projectcars.Interfaces.Interfaces;
using projectcars.Interfaces.Repositories;
using projectcars.Interfaces.Services;
using projectcars.Models;
using SixLabors.ImageSharp;

namespace projectcars.Services
{
    public class ImagesService : IImagesService
    {
        private readonly IImagesRepository _imagesRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public ImagesService(IImagesRepository imagesRepository, IWebHostEnvironment environment, IMapper mapper)
        {
            _imagesRepository = imagesRepository;
            _environment = environment;
            _mapper = mapper;
        }

        public async Task<Models.Image> UploadImage(IFormFile image, Guid? carId, Guid? brandId, Guid? generationId)
        {
            var quality = 60;

            if (image != null)
            {
                var folderName = carId != null ? "cars" : (brandId != null ? "brands" : (generationId != null ? "generations" : null));
                if (folderName == null)
                {
                    throw new ArgumentException("At least one of carId, brandId or generationId must be provided.");
                }

                var fileName = $"{Guid.NewGuid()}.jpg";
                var filePath = Path.Combine("Images\\", folderName, fileName);

                var directoryPath = Path.GetDirectoryName(filePath);
                if (directoryPath != null && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (File.Exists(filePath))
                {
                    throw new InvalidOperationException($"A file with the name '{fileName}' already exists in the '{folderName}' folder.");
                }

                using var img = SixLabors.ImageSharp.Image.Load(image.OpenReadStream());
                using var stream = new FileStream(filePath, FileMode.Create);
                await img.SaveAsJpegAsync(stream, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder { Quality = quality });
                
                var newImage = Models.Image.Create(Guid.NewGuid(), filePath);
                return newImage;
            }
            else
            {
                throw new Exception();
            }
        }

        public void DeleteImage(string filePath) 
        {
            if (File.Exists(filePath)) 
            {
                File.Delete(filePath);
            }
        }

        public async Task<List<TModel>> ConvertBrandImagesToBase64<TModel, TEntity>(List<TEntity> entities)
            where TEntity : IHasImage
        {
            var models = entities.Select(async entity =>
            {
                var model = _mapper.Map<TModel>(entity);

                if (!string.IsNullOrEmpty(entity.ImageEntity?.ImagePath))
                {
                    try
                    {
                        var imageBytes = await File.ReadAllBytesAsync(entity.ImageEntity.ImagePath);
                        var imageBase64 = Convert.ToBase64String(imageBytes);

                        typeof(TModel).GetProperty("ImageBase64")?.SetValue(model, imageBase64);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                return model;
            });

            return (await Task.WhenAll(models)).ToList();
        }

        public Task<List<Brand>> ConvertBrandImagesToBase64(List<BrandEntity> brandEntities)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TModel>> ConvertBrandImageCollectionToBase64<TModel, TEntity>(List<TEntity> entities)
    where TEntity : IHasImages
        {
            var models = entities.Select(async entity =>
            {
                var model = _mapper.Map<TModel>(entity);

                if (entity.ImageEntities?.Count > 0)
                {
                    var imageBase64List = new List<string>();

                    foreach (var image in entity.ImageEntities) 
                    {
                        try
                        {
                            var imageBytes = await File.ReadAllBytesAsync(image.ImagePath);
                            var imageBase64 = Convert.ToBase64String(imageBytes);

                            imageBase64List.Add(imageBase64);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    typeof(TModel).GetProperty("ImagesBase64")?.SetValue(model, imageBase64List);
                }
                return model;
            });

            return (await Task.WhenAll(models)).ToList();
        }
    }
}
