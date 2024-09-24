namespace projectcars.Models
{
    public class Brand
    {
        private Brand(Guid brandId, string brandName)
        {
            BrandName = brandName;
            BrandId = brandId;
        }

        public static Brand Create(Guid brandId, string brandName)
        {
            return new Brand(brandId, brandName);
        }

        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
