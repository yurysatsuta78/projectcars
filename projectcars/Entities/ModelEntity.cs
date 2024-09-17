namespace projectcars.Entities
{
    public class ModelEntity
    {
        public Guid ModelId { get; set; }
        public string ModelName { get; set; } = String.Empty;
        public BrandEntity? BrandEntity { get; set; }
        public Guid BrandId { get; set; }
        public ICollection<GenerationEntity>? GenerationEntities { get; set; }
    }
}
