using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class ModelsRepository : IModelsRepository
    {
        private readonly ApplicationDbContext _context;

        public ModelsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Model model, Guid brandId)
        {
            var modelEntity = new ModelEntity
            {
                ModelName = model.ModelName,
                BrandId = brandId,
            };

            await _context.Models.AddAsync(modelEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<ModelEntity> GetById(Guid id)
        {
            var modelEntity = await _context.Models.FirstOrDefaultAsync(m => m.ModelId == id);

            if (modelEntity != null)
            {
                return modelEntity;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Update(ModelEntity modelEntity, Model model)
        {
            if (modelEntity != null && model != null)
            {
                modelEntity.ModelName = model.ModelName;

                _context.Models.Update(modelEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Remove(ModelEntity modelEntity)
        {
            if (modelEntity != null)
            {
                _context.Models.Remove(modelEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<ModelEntity>> GetModels()
        {
            var modelEntities = await _context.Models
                .ToListAsync();

            return modelEntities;
        }
    }
}
