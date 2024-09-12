namespace projectcars.Models
{
    public class Brand
    {
        private Brand
            (
                string brandName
            )
        {
            BrandName = brandName;
        }

        public static Brand Create
            (
                string brandName
            )
        {
            return new Brand(brandName);
        }

        public string BrandName { get; set; } = String.Empty;
    }
}
