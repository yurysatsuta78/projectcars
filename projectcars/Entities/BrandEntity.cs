namespace projectcars.Entities
{
    public class BrandEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = String.Empty;
        public ICollection<ModelEntity>? ModelEntities { get; set; }
    }
}
