using projectcars.Entities;

namespace projectcars.Models
{
    public class Model
    {
        private Model(Guid modelId, string modelName)
        {
            ModelId = modelId;
            ModelName = modelName;
        }

        public static Model Create(Guid modelId, string modelName)
        {
            return new Model(modelId, modelName);
        }

        public Guid ModelId { get; set; }
        public string ModelName { get; set; }
        public Brand? Brand { get; set; }
    }
}
