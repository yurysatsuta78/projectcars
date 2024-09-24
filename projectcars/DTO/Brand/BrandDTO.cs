namespace projectcars.DTO.Brand
{
    public class BrandDTO
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; } = String.Empty;
        public string? ImageBase64 { get; set; }
    }
}
