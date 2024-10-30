using AutoMapper;
using projectcars.DTO.City;
using projectcars.DTO.Model;
using projectcars.Interfaces.Repositories;
using projectcars.Models;
using projectcars.Repositories;

namespace projectcars.Services
{
    public class CitiesService
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IMapper _mapper;

        public CitiesService(ICitiesRepository citiesRepository, IMapper mapper) 
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }

        public async Task Create(City city)
        {
            await _citiesRepository.Create(city);
        }

        public async Task Update(City city)
        {
            var cityEntity = await _citiesRepository.GetById(city.CityId);
            await _citiesRepository.Update(cityEntity, city);
        }

        public async Task Remove(Guid id)
        {
            var cityEntity = await _citiesRepository.GetById(id);
            await _citiesRepository.Remove(cityEntity);
        }

        public async Task<List<CityDTO>> GetCities()
        {
            return _mapper.Map<List<CityDTO>>(await _citiesRepository.GetCities());
        }
    }
}
