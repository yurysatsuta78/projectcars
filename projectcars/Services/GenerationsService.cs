using AutoMapper;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Interfaces.Services;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Models;
using projectcars.Repositories;
using projectcars.UnitsOfWork;

namespace projectcars.Services
{
    public class GenerationsService
    {
        private readonly IGenerationImageUOW _generationImageUOW;
        private readonly IImagesService _imagesService;
        private readonly IMapper _mapper;

        public GenerationsService(IGenerationImageUOW generationImageUOW, IImagesService imagesService, IMapper mapper)
        {
            _generationImageUOW = generationImageUOW;
            _imagesService = imagesService;
            _mapper = mapper;
        }

        #region Create method
        public async Task Create(string generationName, bool restyling, string startYear, string endYear, Guid modelId, IFormFile image)
        {
            var uploadedImagePath = String.Empty;

            var generation = Generation.Create(Guid.NewGuid(), generationName, restyling, startYear, endYear);

            var newImage = await _imagesService.UploadImage(image, null, null, generation.GenerationId);
            uploadedImagePath = newImage.ImagePath;
            try
            {
                using (var transaction = await _generationImageUOW.BeginTransactionAsync()) 
                {
                    await _generationImageUOW.Generations.Create(generation, modelId);

                    await _generationImageUOW.Images.Create(newImage, null, null, generation.GenerationId);

                    await _generationImageUOW.SaveChangesAsync();
                    await _generationImageUOW.CommitAsync();
                }
            }
            catch 
            {
                await _generationImageUOW.RollbackAsync();

                if (!string.IsNullOrEmpty(uploadedImagePath))
                {
                    _imagesService.DeleteImage(uploadedImagePath);
                }
                throw;
            }
        }
        #endregion

        public async Task Update(Generation generation)
        {
            var generationEntity = await _generationImageUOW.Generations.GetById(generation.GenerationId);
            await _generationImageUOW.Generations.Update(generationEntity, generation);
        }

        public async Task Remove(Generation generation) 
        {
            var generationEntity = await _generationImageUOW.Generations.GetById(generation.GenerationId);
            await _generationImageUOW.Generations.Remove(generationEntity);
        }

        public async Task<List<Generation>> GetGenerations() 
        {
            var generationEntities = await _generationImageUOW.Generations.GetGenerations();
            return await _imagesService.ConvertBrandImagesToBase64<Generation, GenerationEntity>(generationEntities);
        }
    }
}
