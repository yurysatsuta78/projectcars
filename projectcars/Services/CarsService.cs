using AutoMapper;
using projectcars.DTO.Car;
using projectcars.Interfaces.Services;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Models;

namespace projectcars.Services
{
    public class CarsService
    {
        private readonly ICarsImageUOW _carsImageUOW;
        private readonly IGoogleDriveService _googleDriveService;
        private readonly IMapper _mapper;

        public CarsService(ICarsImageUOW carsImageUOW, IGoogleDriveService googleDriveService, IMapper mapper)
        {
            _carsImageUOW = carsImageUOW;
            _googleDriveService = googleDriveService;
            _mapper = mapper;
        }

        #region Create method
        public async Task Create(Car car)
        {
            var uploadedImagePath = String.Empty;
            List<Models.Image> carImages = new List<Models.Image>();

            try 
            {
                foreach (var image in car.Images)
                {
                    var newImage = await _googleDriveService.UploadImageToFolder(image, car.Id, null, null);
                    carImages.Add(newImage);
                }
            }
            catch 
            {
                throw;
            }
            finally 
            {
                try
                {
                    using (var transaction = await _carsImageUOW.BeginTransactionAsync())
                    {
                        await _carsImageUOW.Cars.Create(car);

                        await _carsImageUOW.Images.CreateList(carImages, car.Id);

                        await _carsImageUOW.SaveChangesAsync();
                        await _carsImageUOW.CommitAsync();
                    }
                }
                catch
                {
                    await _carsImageUOW.RollbackAsync();
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

        public async Task Remove(Guid id) 
        {
            var carEntity = await _carsImageUOW.Cars.GetById(id);

            if (carEntity != null && carEntity.ImageEntities != null && carEntity.ImageEntities.Count > 0)
            {
                try
                {
                    using (var transaction = await _carsImageUOW.BeginTransactionAsync()) 
                    {
                        foreach (var image in carEntity.ImageEntities) 
                        {
                            await _carsImageUOW.Images.Remove(image);
                        }

                        await _carsImageUOW.Cars.Remove(carEntity);

                        await _carsImageUOW.CommitAsync();
                    }
                }
                catch 
                {
                    await _carsImageUOW.RollbackAsync();
                    throw;
                }
            }
            else 
            {
                throw new Exception();
            }
        }

        public async Task<List<CarDTO>> GetActiveCars() 
        {
            return _mapper.Map<List<CarDTO>>(await _carsImageUOW.Cars.GetActiveCars());
        }

        public async Task<int> CountActiveCars() 
        {
            return await _carsImageUOW.Cars.CountActiveCars();
        }

        public async Task<List<CarDTO>> GetFiltredCars(CarFilter filter, int take, int skip) 
        {
            return _mapper.Map<List<CarDTO>>(await _carsImageUOW.Cars.GetFiltredCars(filter, take, skip));
        }
    }
}
