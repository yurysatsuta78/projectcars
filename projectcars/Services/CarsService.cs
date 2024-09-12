using AutoMapper;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Services
{
    public class CarsService
    {
        private readonly ICarsRepository _carsRepository;
        private readonly IMapper _mapper;

        public CarsService(ICarsRepository carsRepository, IMapper mapper)
        {
            _carsRepository = carsRepository;
            _mapper = mapper;
        }

        #region Create method
        public async Task Create
            (
                double price,
                double engineVolume,
                string transmissionType,
                string bodyType,
                string engineType,
                string driveTrain,
                int enginePower,
                int mileage,
                string color,
                bool abs,
                bool esp,
                bool asr,
                bool immobilazer,
                bool signaling,
                int generationId
            )
        {
            var car = Car.Create
                (
                    Guid.NewGuid(),
                    price,
                    engineVolume,
                    transmissionType,
                    bodyType,
                    engineType,
                    driveTrain,
                    enginePower,
                    mileage,
                    color,
                    abs,
                    esp,
                    asr,
                    immobilazer,
                    signaling
                );

            await _carsRepository.Create(car, generationId);
        }
        #endregion

        public async Task Hide(Guid id) 
        {
            var carEntity = await _carsRepository.GetById(id);
            await _carsRepository.Hide(carEntity);
        }

        public async Task Update(Car car) 
        {
            var carEntity = await _carsRepository.GetById(car.Id);
            await _carsRepository.Update(carEntity, car);
        }

        public async Task<List<Car>> GetActiveCars() 
        {
            return _mapper.Map<List<Car>>(await _carsRepository.GetActiveCars());
        }
    }
}
