using AutoMapper;
using projectcars.Interfaces.Repositories;
using projectcars.Models;
using projectcars.Repositories;

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

        public async Task Create(string modelName, int brandId)
        {
            var model = Model.Create(modelName);

            await _modelsRepository.Create(model, brandId);
        }

        public async Task Update(Model model)
        {
            var modelEntity = await _modelsRepository.GetById(model.ModelId);
            await _modelsRepository.Update(modelEntity, model);
        }

        public async Task Remove(Model model)
        {
            var modelEntity = await _modelsRepository.GetById(model.ModelId);
            await _modelsRepository.Remove(modelEntity);
        }

        public async Task<List<Model>> GetGenerations()
        {
            return _mapper.Map<List<Model>>(await _modelsRepository.GetModels());
        }
    }
}
