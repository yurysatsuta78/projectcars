namespace projectcars.Entities
{
    public class ModelEntity
    {
        public Guid ModelId { get; set; }
        public string? ModelName { get; set; }
        public BrandEntity? BrandEntity { get; }
        public Guid BrandId { get; set; }
        public ICollection<GenerationEntity>? GenerationEntities { get; }
    }
}
