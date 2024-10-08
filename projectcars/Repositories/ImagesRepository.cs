﻿using Microsoft.EntityFrameworkCore;
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

        public async Task Create(Image image, Guid? brandId, Guid? generationId)
        {
            if (brandId != null)
            {
                var imageEntity = new ImageEntity
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    BrandId = brandId
                };
                await _context.Images.AddAsync(imageEntity);
            }
            if (generationId != null)
            {
                var imageEntity = new ImageEntity
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    GenerationId = generationId
                };
                await _context.Images.AddAsync(imageEntity);
            }
        }

        public async Task CreateList(List<Image> images, Guid carId) 
        {
            foreach (var image in images) 
            {
                var imageEntity = new ImageEntity
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    CarId = carId
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
