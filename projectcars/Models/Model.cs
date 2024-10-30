namespace projectcars.Models
{
    public class Model
    {
        private Model(Guid modelId, string modelName, Guid brandId)
        {
            ModelId = modelId;
            ModelName = modelName;
            BrandId = brandId;
        }

        public static Model Create(Guid modelId, string modelName, Guid brandId)
        {
            return new Model(modelId, modelName, brandId);
        }

        public Guid ModelId { get; }
        public string ModelName { get; }
        public Guid BrandId { get; }
    }
}
