namespace projectcars.Entities
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }

        public Guid? CarId { get; set; }
        public CarEntity? CarEntity { get; }

        public Guid? BrandId { get; set; }
        public BrandEntity? BrandEntity { get; }

        public Guid? GenerationId { get; set; }
        public GenerationEntity? GenerationEntity { get; }
    }
}
