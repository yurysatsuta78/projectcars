using projectcars.DTO.Image;

namespace projectcars.DTO.Generation
{
    public class GenerationDTO
    {
        public Guid GenerationId { get; set; }
        public string GenerationName { get; set; } = String.Empty;
        public bool Restyling { get; set; }
        public string StartYear { get; set; } = String.Empty;
        public string EndYear { get; set; } = String.Empty;
        public ImageDTO? Image { get; set; }
    }
}
