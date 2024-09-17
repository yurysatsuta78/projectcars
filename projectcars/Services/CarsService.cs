using AutoMapper;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Interfaces.Services;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Models;
using projectcars.UnitsOfWork;
using static System.Net.Mime.MediaTypeNames;

namespace projectcars.Services
{
    public class CarsService
    {
        private readonly ICarsImageUOW _carsImageUOW;
        private readonly IImagesService _imagesService;
        private readonly IMapper _mapper;

        public CarsService(ICarsImageUOW carsImageUOW, IImagesService imagesService, IMapper mapper)
        {
            _carsImageUOW = carsImageUOW;
            _imagesService = imagesService;
            _mapper = mapper;
        }

        #region Create method
        public async Task Create(List<IFormFile> images, double price, double engineVolume, string transmissionType, string bodyType, string engineType, string driveTrain, int enginePower, int mileage, string color, bool abs, bool esp, bool asr, bool immobilazer, bool signaling, Guid generationId)
        {
            var uploadedImagePath = String.Empty;
            List<string> imagePaths = new List<string>();
            List<Models.Image> carImages = new List<Models.Image>();

            var car = Car.Create(Guid.NewGuid(), price, engineVolume, transmissionType, bodyType, engineType, driveTrain, enginePower, mileage, color, abs, esp, asr, immobilazer, signaling);

            try 
            {
                foreach (var image in images)
                {
                    var newImage = await _imagesService.UploadImage(image, car.Id, null, null);
                    carImages.Add(newImage);
                    imagePaths.Add(newImage.ImagePath);
                }
            }
            catch 
            {
                if (imagePaths.Count > 0)
                {
                    foreach (var imagePath in imagePaths)
                    {
                        _imagesService.DeleteImage(imagePath);
                    }
                    throw;
                }
            }
            finally 
            {
                try
                {
                    using (var transaction = await _carsImageUOW.BeginTransactionAsync())
                    {
                        await _carsImageUOW.Cars.Create(car, generationId);

                        foreach (var image in carImages)
                        {
                            await _carsImageUOW.Images.Create(image, car.Id, null, null);
                        }

                        await _carsImageUOW.SaveChangesAsync();
                        await _carsImageUOW.CommitAsync();
                    }
                }
                catch
                {
                    await _carsImageUOW.RollbackAsync();

                    if (imagePaths.Count > 0)
                    {
                        foreach (var imagePath in imagePaths)
                        {
                            _imagesService.DeleteImage(imagePath);
                        }
                    }
                    throw;
                }
            }
        }
        #endregion

        public async Task Hide(Guid id) 
        {
            var carEntity = await _carsImageUOW.Cars.GetById(id);
            await _carsImageUOW.Cars.Hide(carEntity);
        }

        public async Task Update(Car car) 
        {
            var carEntity = await _carsImageUOW.Cars.GetById(car.Id);
            await _carsImageUOW.Cars.Update(carEntity, car);
        }

        public async Task<List<Car>> GetActiveCars() 
        {
            var carEntities = await _carsImageUOW.Cars.GetActiveCars();
            return await _imagesService.ConvertBrandImageCollectionToBase64<Car, CarEntity>(carEntities);
        }
    }
}
