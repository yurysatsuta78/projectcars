namespace projectcars.Entities
{
    public class BrandEntity
    {
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }
        public ICollection<ModelEntity>? ModelEntities { get; }
        public ImageEntity? ImageEntity { get; }
    }
}
