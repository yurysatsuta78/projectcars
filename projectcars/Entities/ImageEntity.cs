namespace projectcars.Entities
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;

        public Guid? CarId { get; set; }
        public CarEntity? CarEntity { get; set; }

        public Guid? BrandId { get; set; }
        public BrandEntity? BrandEntity { get; set; }

        public Guid? GenerationId { get; set; }
        public GenerationEntity? GenerationEntity { get; set; }
    }
}
