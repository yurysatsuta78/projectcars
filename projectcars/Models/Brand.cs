namespace projectcars.Models
{
    public class Brand
    {
        private Brand(string brandName)
        {
            BrandName = brandName;
        }

        public static Brand Create(string brandName)
        {
            return new Brand(brandName);
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; } = String.Empty;
    }
}
