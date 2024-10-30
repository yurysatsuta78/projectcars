using AutoMapper;
using projectcars.DTO.Brand;
using projectcars.Interfaces.Services;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Models;

namespace projectcars.Services
{
    public class BrandsService
    {
        private readonly IBrandImageUOW _brandImageUOW;
        private readonly IGoogleDriveService _googleDriveService;
        private readonly IMapper _mapper;

        public BrandsService(IBrandImageUOW brandImageUOW, IGoogleDriveService googleDriveService, IMapper mapper)
        {
            _brandImageUOW = brandImageUOW;
            _googleDriveService = googleDriveService;
            _mapper = mapper;
        }

        public async Task Create(Brand brand)
        {


            var newImage = await _googleDriveService.UploadImageToFolder(brand.Image, null, brand.BrandId, null);
            var uploadedImagePath = newImage.ImageUrl;
            try 
            {
                using (var transaction = await _brandImageUOW.BeginTransactionAsync()) 
                {
                    await _brandImageUOW.Brands.Create(brand);

                    await _brandImageUOW.Images.Create(newImage, brand.BrandId, null);

                    await _brandImageUOW.SaveChangesAsync();
                    await _brandImageUOW.CommitAsync();
                }
            }
            catch
            {
                await _brandImageUOW.RollbackAsync();
                throw;
            }
        }

        public async Task Update(Brand brand)
        {
            var brandEntity = await _brandImageUOW.Brands.GetById(brand.BrandId);
            await _brandImageUOW.Brands.Update(brandEntity, brand);
        }

        public async Task Remove(Guid brandId)
        {
            var brandEntity = await _brandImageUOW.Brands.GetById(brandId);

            if (brandEntity != null && brandEntity.ImageEntity != null)
            {
                var imageEntity = await _brandImageUOW.Images.GetById(brandEntity.ImageEntity.Id);

                try 
                {
                    using (var transaction = await _brandImageUOW.BeginTransactionAsync())
                    {
                        await _brandImageUOW.Images.Remove(imageEntity);
                        await _brandImageUOW.Brands.Remove(brandEntity);

                        await _brandImageUOW.CommitAsync();
                    }
                }
                catch 
                {
                    await _brandImageUOW.RollbackAsync();
                    throw;
                }
            }
            else 
            {
                throw new Exception();
            }
        }

        public async Task<List<BrandDTO>> GetBrands()
        {
            return _mapper.Map<List<BrandDTO>>(await _brandImageUOW.Brands.GetBrands());
        }
    }
}
