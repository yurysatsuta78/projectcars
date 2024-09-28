using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Car car, Guid generationId)
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
                Color = car.Color,
                IsHidden = false,
                Abs = car.Abs,
                Esp = car.Esp,
                Asr = car.Asr,
                Immobilizer = car.Immobilizer,
                Signaling = car.Signaling,
                GenerationId = generationId
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
                .ToListAsync();
        }

        public async Task<List<CarEntity>> GetFiltredCars(CarFilter filter) 
        {
            var filtredCars = _context.Cars.Where(b => b.Price >= filter.MinPrice && 
            b.EngineVolume >= filter.MinEngineVolume && 
            b.EnginePower >= filter.MinEnginePower && 
            b.Mileage >= filter.MinMileage);

            if (filter.MaxPrice != null) 
            {
                filtredCars = filtredCars.Where(b => b.Price <= filter.MaxPrice);
            }
            if (filter.MaxEngineVolume != null) 
            {
                filtredCars = filtredCars.Where(b => b.EngineVolume <= filter.MaxEngineVolume);
            }
            if (filter.TransmissionType != null) 
            {
                filtredCars = filtredCars.Where(b => b.TransmissionType == filter.TransmissionType);
            }
            if (filter.BodyType != null) 
            {
                filtredCars = filtredCars.Where(b => b.BodyType == filter.BodyType);
            }
            if (filter.EngineType != null) 
            {
                filtredCars = filtredCars.Where(b => b.EngineType == filter.EngineType);
            }
            if (filter.DriveTrain != null) 
            {
                filtredCars = filtredCars.Where(b => b.DriveTrain == filter.DriveTrain);
            }
            if (filter.MaxEnginePower != null)
            {
                filtredCars = filtredCars.Where(b => b.EnginePower <= filter.MaxEnginePower);
            }
            if (filter.MaxMileage != null)
            {
                filtredCars = filtredCars.Where(b => b.Mileage <= filter.MaxMileage);
            }
            if (filter.Color != null)
            {
                filtredCars = filtredCars.Where(b => b.Color == filter.Color);
            }
            if (filter.Abs != null)
            {
                filtredCars = filtredCars.Where(b => b.Abs == filter.Abs);
            }
            if (filter.Esp != null)
            {
                filtredCars = filtredCars.Where(b => b.Esp == filter.Esp);
            }
            if (filter.Asr != null)
            {
                filtredCars = filtredCars.Where(b => b.Asr == filter.Asr);
            }
            if (filter.Immobilizer != null)
            {
                filtredCars = filtredCars.Where(b => b.Immobilizer == filter.Immobilizer);
            }
            if (filter.Signaling != null)
            {
                filtredCars = filtredCars.Where(b => b.Signaling == filter.Signaling);
            }

            return await filtredCars.ToListAsync();
        }
    }
}
