using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly ApplicationDbContext _context;

        public ImagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Image image, Guid? carId, Guid? brandId, Guid? generationId)
        {
            if (carId != null)
            {
                var imageEntity = new ImageEntity
                {
                    Id = image.Id,
                    ImagePath = image.ImagePath,
                    CarId = carId
                };

                await _context.Images.AddAsync(imageEntity);
            }
            if (brandId != null)
            {
                var imageEntity = new ImageEntity
                {
                    Id = image.Id,
                    ImagePath = image.ImagePath,
                    BrandId = brandId
                };
                await _context.Images.AddAsync(imageEntity);
            }
            if (generationId != null)
            {
                var imageEntity = new ImageEntity
                {
                    Id = image.Id,
                    ImagePath = image.ImagePath,
                    GenerationId = generationId
                };
                await _context.Images.AddAsync(imageEntity);
            }
        }

        public async Task<ImageEntity> GetById(Guid id) 
        {
            var imageEntity = await _context.Images.FirstOrDefaultAsync(m => m.Id == id);

            if (imageEntity != null)
            {
                return imageEntity;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<ImageEntity>> GetBrandImages(Guid brandId)
        {
            var imageEntities = await _context.Images
               .Where(m => m.BrandId == brandId)
               .ToListAsync();

            if (imageEntities != null) 
            {
                return imageEntities;
            }
            else 
            {
                throw new Exception();
            }
        }

        public async Task<List<ImageEntity>> GetGenerationImages(Guid generationId) 
        {
            var imageEntities = await _context.Images
                .Where(m => m.GenerationId == generationId)
                .ToListAsync();

            if (imageEntities != null)
            {
                return imageEntities;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<ImageEntity>> GetCarImages(Guid carId) 
        {
            var imageEntities = await _context.Images
                .Where(m => m.CarId == carId)
                .ToListAsync();

            if (imageEntities != null)
            {
                return imageEntities;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Remove(ImageEntity imageEntity) 
        {
            if(imageEntity != null) 
            {
                _context.Images.Remove(imageEntity);
                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new Exception();
            }
        }
    }
}
