using AutoMapper;
using projectcars.DTO.Brand;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Interfaces.Services;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Models;
using projectcars.Repositories;

namespace projectcars.Services
{
    public class BrandsService
    {
        private readonly IBrandImageUOW _brandImageUOW;
        private readonly IImagesService _imagesService;
        private readonly IMapper _mapper;

        public BrandsService(IBrandImageUOW brandImageUOW, IImagesService imagesService, IMapper mapper)
        {
            _brandImageUOW = brandImageUOW;
            _imagesService = imagesService;
            _mapper = mapper;
        }

        public async Task Create(string brandName, IFormFile image)
        {
            var brand = Brand.Create(Guid.NewGuid(), brandName);

            var newImage = await _imagesService.UploadImage(image, null, brand.BrandId, null);
            var uploadedImagePath = newImage.ImagePath;
            try 
            {
                using (var transaction = await _brandImageUOW.BeginTransactionAsync()) 
                {
                    await _brandImageUOW.Brands.Create(brand);

                    await _brandImageUOW.Images.Create(newImage, null, brand.BrandId, null);

                    await _brandImageUOW.SaveChangesAsync();
                    await _brandImageUOW.CommitAsync();
                }
            }
            catch
            {
                await _brandImageUOW.RollbackAsync();

                if (!string.IsNullOrEmpty(uploadedImagePath))
                {
                    _imagesService.DeleteImage(uploadedImagePath);
                }
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
                    _imagesService.DeleteImage(brandEntity.ImageEntity.ImagePath);

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
            var brandEntities = await _brandImageUOW.Brands.GetBrands();
            return await _imagesService.ConvertBrandImagesToBase64<BrandDTO, BrandEntity>(brandEntities);
        }
    }
}
