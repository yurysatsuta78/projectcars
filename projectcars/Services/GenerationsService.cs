using AutoMapper;
using projectcars.DTO.Generation;
using projectcars.Interfaces.Services;
using projectcars.Interfaces.UnitsOfWork;
using projectcars.Models;

namespace projectcars.Services
{
    public class GenerationsService
    {
        private readonly IGenerationImageUOW _generationImageUOW;
        private readonly IGoogleDriveService _googleDriveService;
        private readonly IMapper _mapper;

        public GenerationsService(IGenerationImageUOW generationImageUOW, IGoogleDriveService googleDriveService, IMapper mapper)
        {
            _generationImageUOW = generationImageUOW;
            _googleDriveService = googleDriveService;
            _mapper = mapper;
        }

        #region Create method
        public async Task Create(string generationName, bool restyling, string startYear, string endYear, Guid modelId, IFormFile image)
        {
            var uploadedImagePath = String.Empty;

            var generation = Generation.Create(Guid.NewGuid(), generationName, restyling, startYear, endYear);

            var newImage = await _googleDriveService.UploadImage(image, null, null, generation.GenerationId);
            uploadedImagePath = newImage.ImageUrl;
            try
            {
                using (var transaction = await _generationImageUOW.BeginTransactionAsync()) 
                {
                    await _generationImageUOW.Generations.Create(generation, modelId);

                    await _generationImageUOW.Images.Create(newImage, null, generation.GenerationId);

                    await _generationImageUOW.SaveChangesAsync();
                    await _generationImageUOW.CommitAsync();
                }
            }
            catch 
            {
                await _generationImageUOW.RollbackAsync();
                throw;
            }
        }
        #endregion

        public async Task Update(Generation generation)
        {
            var generationEntity = await _generationImageUOW.Generations.GetById(generation.GenerationId);
            await _generationImageUOW.Generations.Update(generationEntity, generation);
        }

        public async Task Remove(Guid generationId) 
        {
            var generationEntity = await _generationImageUOW.Generations.GetById(generationId);

            if(generationEntity != null && generationEntity.ImageEntity != null) 
            {
                var imageEntity = await _generationImageUOW.Images.GetById(generationEntity.ImageEntity.Id);

                try
                {
                    using (var transaction = await _generationImageUOW.BeginTransactionAsync())
                    {
                        await _generationImageUOW.Images.Remove(imageEntity);
                        await _generationImageUOW.Generations.Remove(generationEntity);

                        await _generationImageUOW.CommitAsync();
                    }
                }
                catch
                {
                    await _generationImageUOW.RollbackAsync();
                    throw;
                }
            }
            else 
            {
                throw new Exception();
            }
        }

        public async Task<List<GenerationDTO>> GetGenerations() 
        {
            return _mapper.Map<List<GenerationDTO>>(await _generationImageUOW.Generations.GetGenerations());
        }
    }
}
