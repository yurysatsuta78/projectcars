using AutoMapper;
using projectcars.DTO.Model;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Services
{
    public class ModelsService
    {
        private readonly IModelsRepository _modelsRepository;
        private readonly IMapper _mapper;

        public ModelsService(IModelsRepository modelsRepository, IMapper mapper)
        {
            _modelsRepository = modelsRepository;
            _mapper = mapper;
        }

        public async Task Create(Model model)
        {
            await _modelsRepository.Create(model);
        }

        public async Task Update(Model model)
        {
            var modelEntity = await _modelsRepository.GetById(model.ModelId);
            await _modelsRepository.Update(modelEntity, model);
        }

        public async Task Remove(Guid id)
        {
            var modelEntity = await _modelsRepository.GetById(id);
            await _modelsRepository.Remove(modelEntity);
        }

        public async Task<List<ModelDTO>> GetModels()
        {
            return _mapper.Map<List<ModelDTO>>(await _modelsRepository.GetModels());
        }
    }
}
