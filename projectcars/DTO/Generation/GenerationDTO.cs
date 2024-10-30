using projectcars.DTO.Image;

namespace projectcars.DTO.Generation
{
    public class GenerationDTO
    {
        public Guid GenerationId { get; set; }
        public string? GenerationName { get; set; }
        public bool Restyling { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public ImageDTO? Image { get; set; }
        public Guid ModelId { get; set; }
    }
}
