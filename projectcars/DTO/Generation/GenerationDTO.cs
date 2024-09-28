using projectcars.DTO.Image;

namespace projectcars.DTO.Generation
{
    public class GenerationDTO
    {
        public Guid GenerationId { get; set; }
        public string? GenerationName { get; set; }
        public bool Restyling { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public ImageDTO? Image { get; set; }
    }
}
