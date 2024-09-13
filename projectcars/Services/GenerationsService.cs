using AutoMapper;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;
using projectcars.Repositories;

namespace projectcars.Services
{
    public class GenerationsService
    {
        private readonly IGenerationsRepository _generationsRepository;
        private readonly IMapper _mapper;

        public GenerationsService(IGenerationsRepository generationsRepository, IMapper mapper)
        {
            _generationsRepository = generationsRepository;
            _mapper = mapper;
        }

        #region Create method
        public async Task Create
            (
                string generationName,
                bool restyling,
                string startYear,
                string endYear,
                int modelId
            )
        {
            var generation = Generation.Create
                (
                    generationName,
                    restyling,
                    startYear,
                    endYear
                );

            await _generationsRepository.Create(generation, modelId);
        }
        #endregion

        public async Task Update(Generation generation)
        {
            var generationEntity = await _generationsRepository.GetById(generation.GenerationId);
            await _generationsRepository.Update(generationEntity, generation);
        }

        public async Task Remove(Generation generation) 
        {
            var generationEntity = await _generationsRepository.GetById(generation.GenerationId);
            await _generationsRepository.Remove(generationEntity);
        }

        public async Task<List<Generation>> GetGenerations() 
        {
            return _mapper.Map<List<Generation>>(await _generationsRepository.GetGenerations());
        }
    }
}
