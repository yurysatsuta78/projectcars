using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class GenerationsRepository : IGenerationsRepository
    {
        private readonly ApplicationDbContext _context;

        public GenerationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Generation generation, int modelId)
        {
            var generationEntity = new GenerationEntity
            {
                GenerationName = generation.GenerationName,
                Restyling = generation.Restyling,
                StartYear = generation.StartYear,
                EndYear = generation.EndYear,
                ModelId = modelId
            };

            await _context.Generations.AddAsync(generationEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<GenerationEntity> GetById(int id)
        {
            var generationEntity = await _context.Generations.FirstOrDefaultAsync(m => m.GenerationId == id);

            if (generationEntity != null)
            {
                return generationEntity;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Update(GenerationEntity generationEntity, Generation generation)
        {
            if (generationEntity != null && generation != null)
            {
                generationEntity.GenerationName = generation.GenerationName;
                generationEntity.Restyling = generation.Restyling;
                generationEntity.StartYear = generation.StartYear;
                generationEntity.EndYear = generation.EndYear;

                _context.Generations.Update(generationEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Remove(GenerationEntity generationEntity)
        {
            if (generationEntity != null)
            {
                _context.Generations.Remove(generationEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<GenerationEntity>> GetGenerations()
        {
            var generationEntities = await _context.Generations
                .ToListAsync();

            return generationEntities;
        }
    }
}
