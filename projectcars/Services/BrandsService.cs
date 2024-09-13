using AutoMapper;
using projectcars.Interfaces.Repositories;
using projectcars.Models;
using projectcars.Repositories;

namespace projectcars.Services
{
    public class BrandsService
    {
        private readonly IBrandsRepository _brandsRepository;
        private readonly IMapper _mapper;

        public BrandsService(IBrandsRepository brandsRepository, IMapper mapper)
        {
            _brandsRepository = brandsRepository;
            _mapper = mapper;
        }

        public async Task Create(string brandName)
        {
            var brand = Brand.Create(brandName);

            await _brandsRepository.Create(brand);
        }

        public async Task Update(Brand brand)
        {
            var brandEntity = await _brandsRepository.GetById(brand.BrandId);
            await _brandsRepository.Update(brandEntity, brand);
        }

        public async Task Remove(Brand brand)
        {
            var brandEntity = await _brandsRepository.GetById(brand.BrandId);
            await _brandsRepository.Remove(brandEntity);
        }

        public async Task<List<Brand>> GetGenerations()
        {
            return _mapper.Map<List<Brand>>(await _brandsRepository.GetBrands());
        }
    }
}
