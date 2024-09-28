using projectcars.DTO.Image;

namespace projectcars.DTO.Car
{
    public class CarDTO
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public double EngineVolume { get; set; }
        public string? TransmissionType { get; set; }
        public string? BodyType { get; set; }
        public string? EngineType { get; set; }
        public string? DriveTrain { get; set; }
        public int EnginePower { get; set; }
        public int Mileage { get; set; }
        public string? Color { get; set; }
        public CarGenerationDTO? Generation { get; set; }
        public bool Abs { get; set; }
        public bool Esp { get; set; }
        public bool Asr { get; set; }
        public bool Immobilizer { get; set; }
        public bool Signaling { get; set; }
        public List<ImageDTO>? Images { get; set; }
    }
}
