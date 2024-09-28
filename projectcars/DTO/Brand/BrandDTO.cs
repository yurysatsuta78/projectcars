using projectcars.DTO.Image;

namespace projectcars.DTO.Brand
{
    public class BrandDTO
    {
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }
        public ImageDTO? Image { get; set; }
    }
}
