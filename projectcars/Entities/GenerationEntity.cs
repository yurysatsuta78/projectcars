namespace projectcars.Entities
{
    public class GenerationEntity
    {
        public Guid GenerationId { get; set; }
        public string? GenerationName { get; set; }
        public bool Restyling { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public ModelEntity? ModelEntity { get; }
        public Guid ModelId { get; set; }
        public ICollection<CarEntity>? CarEntities { get; }
        public ImageEntity? ImageEntity { get; }
    }
}
