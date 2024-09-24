namespace projectcars.DTO.Car
{
    public class CarGenerationDTO
    {
        public string GenerationName { get; set; } = string.Empty;
        public CarModelDTO? Model { get; set; }
    }
}
