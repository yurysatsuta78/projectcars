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
            var carEntity = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<List<CarEntity>> GetActiveCars()
        {
            return await _context.Cars
                .Where(b => b.IsHidden == false)
                .Include(b => b.ImageEntities)
                .ToListAsync();
        }
    }
}
