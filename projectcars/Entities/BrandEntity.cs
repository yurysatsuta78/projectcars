namespace projectcars.Entities
{
    public class BrandEntity
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; } = String.Empty;
        public ICollection<ModelEntity>? ModelEntities { get; set; }
        public ImageEntity? ImageEntity { get; }
    }
}
