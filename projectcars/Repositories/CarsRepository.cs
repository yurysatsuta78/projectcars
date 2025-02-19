using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;
using System.ComponentModel.DataAnnotations;

namespace projectcars.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Car car)
        {
            var carEntity = new CarEntity
            {
                Id = car.Id,
                Price = car.Price,
                EngineVolume = car.EngineVolume,
                TransmissionType = car.TransmissionType,
                BodyType = car.BodyType,
                EngineType = car.EngineType,
                DriveTrain = car.DriveTrain,
                EnginePower = car.EnginePower,
                Mileage = car.Mileage,
                ProdYear = car.ProdYear,
                Color = car.Color,
                InteriorColor = car.InteriorColor,
                InteriorMaterial = car.InteriorMaterial,
                Description = car.Description,
                CarState = car.CarState,
                RegistrationCountry = car.RegistrationCountry,
                TowBar = car.TowBar,
                RoofRails = car.RoofRails,
                SunRoof = car.SunRoof,
                PanoramicRoof = car.PanoramicRoof,
                RainSensor = car.RainSensor,
                RearViewCamera = car.RearViewCamera,
                ParkingSensors = car.ParkingSensors,
                BlindSpotSensor = car.BlindSpotSensor,
                HeatedSeats = car.HeatedSeats,
                HeatedWindshield = car.HeatedWindshield,
                HeatedMirrors = car.HeatedMirrors,
                HeatedSteeringWheel = car.HeatedSteeringWheel,
                AutonomousHeater = car.AutonomousHeater,
                ClimateControl = car.ClimateControl,
                AirConditioner = car.AirConditioner,
                CruiseControl = car.CruiseControl,
                SteeringWheelMultimedia = car.SteeringWheelMultimedia,
                ElectricSeats = car.ElectricSeats,
                FrontElectroWindows = car.FrontElectroWindows,
                RearElectroWindows = car.RearElectroWindows,
                AirBags = car.AirBags,
                IsTradable = car.IsTradable,
                IsRegistred = car.IsRegistred,
                Abs = car.Abs,
                Esp = car.Esp,
                Asr = car.Asr,
                Immobilizer = car.Immobilizer,
                Signaling = car.Signaling,
                IsHidden = false,
                GenerationId = car.GenerationId,
                CityId = car.CityId,
                UserId = car.UserId,
            };

            await _context.Cars.AddAsync(carEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<CarEntity> GetById(Guid id)
        {
            var carEntity = await _context.Cars.Include(m => m.ImageEntities).FirstOrDefaultAsync(m => m.Id == id);

            if (carEntity != null)
            {
                return carEntity;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Hide(CarEntity carEntity)
        {
            if (carEntity.IsHidden != false)
            {
                carEntity.IsHidden = true;

                _context.Cars.Update(carEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Update(CarEntity carEntity, Car car)
        {
            if (carEntity != null && car != null)
            {
                carEntity.Price = car.Price;
                carEntity.EngineVolume = car.EngineVolume;
                carEntity.TransmissionType = car.TransmissionType;
                carEntity.BodyType = car.BodyType;
                carEntity.EngineType = car.EngineType;
                carEntity.DriveTrain = car.DriveTrain;
                carEntity.EnginePower = car.EnginePower;
                carEntity.Mileage = car.Mileage;
                carEntity.Color = car.Color;
                carEntity.Abs = car.Abs;
                carEntity.Esp = car.Esp;
                carEntity.Asr = car.Asr;
                carEntity.Immobilizer = car.Immobilizer;
                carEntity.Signaling = car.Signaling;

                _context.Cars.Update(carEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Remove(CarEntity carEntity)
        {
            if (carEntity != null)
            {
                _context.Cars.Remove(carEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<CarEntity>> GetActiveCars()
        {
            return await _context.Cars
                .Where(b => b.IsHidden == false)
                .Include(b => b.ImageEntities)
                .Include(b => b.GenerationEntity)
                .ThenInclude(b => b.ModelEntity)
                .ThenInclude(b => b.BrandEntity)
                .Include(b => b.CityEntity)
                .ThenInclude(b => b.RegionEntity)
                .Include(b => b.UserEntity)
                .ToListAsync();
        }

        public async Task AddCarToFavourites(Guid userId, Guid carId) 
        {
            var favoriteCarEntity = new UserFavouriteCarEntity
            {
                UserId = userId,
                CarId = carId,
            };

            await _context.FavouriteCars.AddAsync(favoriteCarEntity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCarFromFavourites(Guid userId, Guid carId) 
        {
            var favouriteCarEntity = await _context.FavouriteCars
                .FirstAsync(b => b.UserId == userId && 
                b.CarId == carId);

            _context.FavouriteCars.Remove(favouriteCarEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarEntity>> GetUserFavourites(Guid userId) 
        {
            var user = await _context.Users
                    .Where(b => b.Id == userId)
                    .Include(b => b.FavouriteCars)
                        .ThenInclude(b => b.ImageEntities)
                    .Include(b => b.FavouriteCars)
                        .ThenInclude(b => b.GenerationEntity)
                            .ThenInclude(b => b.ModelEntity)
                                .ThenInclude(b => b.BrandEntity)
                    .Include(b => b.FavouriteCars)
                        .ThenInclude(b => b.CityEntity)
                            .ThenInclude(b => b.RegionEntity)
                    .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            return user.FavouriteCars.ToList();
        }

        public async Task<int> CountActiveCars() 
        {
            return await _context.Cars.Where(b => b.IsHidden == false).CountAsync();
        }

        public async Task<List<CarEntity>> GetFiltredCars(CarFilter filter, int take, int skip)
        {
            var filtredCars = _context.Cars.Where(b =>
                    (filter.MinPrice == null || b.Price >= filter.MinPrice) &&
                    (filter.MaxPrice == null || b.Price <= filter.MaxPrice) &&
                    (filter.MinEngineVolume == null || b.EngineVolume >= filter.MinEngineVolume) &&
                    (filter.MaxEngineVolume == null || b.EngineVolume <= filter.MaxEngineVolume) &&
                    (filter.MinEnginePower == null || b.EnginePower >= filter.MinEnginePower) &&
                    (filter.MaxEnginePower == null || b.EnginePower <= filter.MaxEnginePower) &&
                    (filter.MinMileage == null || b.Mileage >= filter.MinMileage) &&
                    (filter.MaxMileage == null || b.Mileage <= filter.MaxMileage) &&
                    (filter.TransmissionType == null || b.TransmissionType == filter.TransmissionType) &&
                    (filter.BodyType == null || b.BodyType == filter.BodyType) &&
                    (filter.EngineType == null || b.EngineType == filter.EngineType) &&
                    (filter.DriveTrain == null || b.DriveTrain == filter.DriveTrain) &&
                    (filter.MinYear == null || b.ProdYear >= filter.MinYear) &&
                    (filter.MaxYear == null || b.ProdYear <= filter.MaxYear) &&
                    (filter.Color == null || b.Color == filter.Color) &&
                    (filter.InteriorColor == null || b.InteriorColor == filter.InteriorColor) &&
                    (filter.InteriorMaterial == null || b.InteriorMaterial == filter.InteriorMaterial) &&
                    (filter.Description == null || b.Description == filter.Description) &&
                    (filter.CarState == null || b.CarState == filter.CarState) &&
                    (filter.RegistrationCountry == null || b.RegistrationCountry == filter.RegistrationCountry) &&
                    (filter.TowBar == false || b.TowBar == filter.TowBar) &&
                    (filter.RoofRails == false || b.RoofRails == filter.RoofRails) &&
                    (filter.SunRoof == false || b.SunRoof == filter.SunRoof) &&
                    (filter.PanoramicRoof == false || b.PanoramicRoof == filter.PanoramicRoof) &&
                    (filter.RainSensor == false || b.RainSensor == filter.RainSensor) &&
                    (filter.RearViewCamera == false || b.RearViewCamera == filter.RearViewCamera) &&
                    (filter.ParkingSensors == false || b.ParkingSensors == filter.ParkingSensors) &&
                    (filter.BlindSpotSensor == false || b.BlindSpotSensor == filter.BlindSpotSensor) &&
                    (filter.HeatedSeats == false || b.HeatedSeats == filter.HeatedSeats) &&
                    (filter.HeatedWindshield == false || b.HeatedWindshield == filter.HeatedWindshield) &&
                    (filter.HeatedMirrors == false || b.HeatedMirrors == filter.HeatedMirrors) &&
                    (filter.HeatedSteeringWheel == false || b.HeatedSteeringWheel == filter.HeatedSteeringWheel) &&
                    (filter.AutonomousHeater == false || b.AutonomousHeater == filter.AutonomousHeater) &&
                    (filter.ClimateControl == false || b.ClimateControl == filter.ClimateControl) &&
                    (filter.AirConditioner == false || b.AirConditioner == filter.AirConditioner) &&
                    (filter.CruiseControl == false || b.CruiseControl == filter.CruiseControl) &&
                    (filter.SteeringWheelMultimedia == false || b.SteeringWheelMultimedia == filter.SteeringWheelMultimedia) &&
                    (filter.ElectricSeats == false || b.ElectricSeats == filter.ElectricSeats) &&
                    (filter.FrontElectroWindows == false || b.FrontElectroWindows == filter.FrontElectroWindows) &&
                    (filter.RearElectroWindows == false || b.RearElectroWindows == filter.RearElectroWindows) &&
                    (filter.AirBags == false || b.AirBags == filter.AirBags) &&
                    (filter.IsTradable == false || b.IsTradable == filter.IsTradable) &&
                    (filter.IsRegistred == false || b.IsRegistred == filter.IsRegistred) &&
                    (filter.Abs == false || b.Abs == filter.Abs) &&
                    (filter.Esp == false || b.Esp == filter.Esp) &&
                    (filter.Asr == false || b.Asr == filter.Asr) &&
                    (filter.Immobilizer == false || b.Immobilizer == filter.Immobilizer) &&
                    (filter.Signaling == false || b.Signaling == filter.Signaling) &&
                    (filter.GenerationId == null || b.GenerationId == filter.GenerationId) &&
                    (filter.ModelId == null || b.GenerationEntity.ModelId == filter.ModelId) &&
                    (filter.BrandId == null || b.GenerationEntity.ModelEntity.BrandId == filter.BrandId) &&
                    (filter.CityId == null || b.CityId == filter.CityId) &&
                    (b.IsHidden == false))
                .Include(b => b.ImageEntities)
                .Include(b => b.GenerationEntity)
                .ThenInclude(b => b.ModelEntity)
                .ThenInclude(b => b.BrandEntity)
                .Include(b => b.CityEntity)
                .ThenInclude(b => b.RegionEntity)
                .Include(b => b.UserEntity)
                .Skip(skip).Take(take);


            return await filtredCars.ToListAsync();
        }
    }
}
