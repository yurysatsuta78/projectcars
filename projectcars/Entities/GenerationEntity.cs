namespace projectcars.Entities
{
    public class GenerationEntity
    {
        public Guid GenerationId { get; set; }
        public string GenerationName { get; set; } = String.Empty;
        public bool Restyling { get; set; }
        public string StartYear { get; set; } = String.Empty;
        public string EndYear { get; set; } = String.Empty;
        public ModelEntity? ModelEntity { get; set; }
        public Guid ModelId { get; set; }
        public ICollection<CarEntity>? CarEntities { get; set; }
        public ImageEntity? ImageEntity { get; }
    }
}
