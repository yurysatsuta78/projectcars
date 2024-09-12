namespace projectcars.Entities
{
    public class ModelEntity
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; } = String.Empty;
        public BrandEntity? BrandEntity { get; set; }
        public int BrandId { get; set; }
        public ICollection<GenerationEntity>? GenerationEntities { get; set; }
    }
}
