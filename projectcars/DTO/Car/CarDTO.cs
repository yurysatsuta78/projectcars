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
        public int ProdYear { get; set; }
        public string? Color { get; set; }
        public string? InteriorColor { get; set; }
        public string? InteriorMaterial { get; set; }
        public string? Description { get; set; }
        public string? CarState { get; set; }
        public string? RegistrationCountry { get; set; }
        public bool TowBar { get; set; }
        public bool RoofRails { get; set; }
        public bool SunRoof { get; set; }
        public bool PanoramicRoof { get; set; }
        public bool RainSensor { get; set; }
        public bool RearViewCamera { get; set; }
        public bool ParkingSensors { get; set; }
        public bool BlindSpotSensor { get; set; }
        public bool HeatedSeats { get; set; }
        public bool HeatedWindshield { get; set; }
        public bool HeatedMirrors { get; set; }
        public bool HeatedSteeringWheel { get; set; }
        public bool AutonomousHeater { get; set; }
        public bool ClimateControl { get; set; }
        public bool AirConditioner { get; set; }
        public bool CruiseControl { get; set; }
        public bool SteeringWheelMultimedia { get; set; }
        public bool ElectricSeats { get; set; }
        public bool FrontElectroWindows { get; set; }
        public bool RearElectroWindows { get; set; }
        public bool AirBags { get; set; }
        public bool IsTradable { get; set; }
        public bool IsRegistred { get; set; }
        public bool Abs { get; set; }
        public bool Esp { get; set; }
        public bool Asr { get; set; }
        public bool Immobilizer { get; set; }
        public bool Signaling { get; set; }
        public string? GenerationName { get; set; }
        public string? ModelName { get; set; }
        public string? BrandName { get; set; }
        public string? CityName { get; set; }
        public string? RegionName { get; set; }
        public string? PhoneNumber { get; set; }
        public List<ImageDTO>? Images { get; set; }
    }
}
