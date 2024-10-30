using AutoMapper;
using projectcars.DTO.City;
using projectcars.DTO.Region;
using projectcars.Interfaces.Repositories;
using projectcars.Models;
using projectcars.Repositories;

namespace projectcars.Services
{
    public class RegionsService
    {
        private readonly IRegionsRepository _regionsRepository;
        private readonly IMapper _mapper;

        public RegionsService(IRegionsRepository regionsRepository, IMapper mapper) 
        {
            _regionsRepository = regionsRepository;
            _mapper = mapper;
        }

        public async Task Create(Region region)
        {
            await _regionsRepository.Create(region);
        }

        public async Task Update(Region region)
        {
            var regionEntity = await _regionsRepository.GetById(region.RegionId);
            await _regionsRepository.Update(regionEntity, region);
        }

        public async Task Remove(Guid id)
        {
            var regionEntity = await _regionsRepository.GetById(id);
            await _regionsRepository.Remove(regionEntity);
        }

        public async Task<List<RegionDTO>> GetRegions()
        {
            return _mapper.Map<List<RegionDTO>>(await _regionsRepository.GetRegions());
        }
    }
}
