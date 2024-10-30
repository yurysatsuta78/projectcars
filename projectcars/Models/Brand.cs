namespace projectcars.Models
{
    public class Brand
    {
        private Brand(Guid brandId, string brandName, IFormFile image)
        {
            BrandName = brandName;
            BrandId = brandId;
            Image = image;
        }

        public static Brand Create(Guid brandId, string brandName, IFormFile image)
        {
            return new Brand(brandId, brandName, image);
        }

        public Guid BrandId { get; }
        public string BrandName { get; }
        public IFormFile Image { get; }
    }
}
