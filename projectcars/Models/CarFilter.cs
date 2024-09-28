namespace projectcars.Models
{
    public class CarFilter
    {
        private CarFilter(double minPrice, double? maxPrice, double minEngineVolume, double? maxEngineVolume, string? transmissionType, string? bodyType, string? engineType, string? driveTrain, int minEnginePower, int? maxEnginePower, int minMileage, int? maxMileage, string? color, bool? abs, bool? esp, bool? asr, bool? immobilizer, bool? signaling) 
        {
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            MinEngineVolume = minEngineVolume;
            MaxEngineVolume = maxEngineVolume;
            TransmissionType = transmissionType;
            BodyType = bodyType;
            EngineType = engineType;
            DriveTrain = driveTrain;
            MinEnginePower = minEnginePower;
            MaxEnginePower = maxEnginePower;
            MinMileage = minMileage;
            MaxMileage = maxMileage;
            Color = color;
            Abs = abs;
            Esp = esp;
            Asr = asr;
            Immobilizer = immobilizer;
            Signaling = signaling;
        }

        public double MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public double MinEngineVolume { get; set; }
        public double? MaxEngineVolume { get; set; }
        public string? TransmissionType { get; set; }
        public string? BodyType { get; set; }
        public string? EngineType { get; set; }
        public string? DriveTrain { get; set; }
        public int MinEnginePower { get; set; }
        public int? MaxEnginePower { get; set; }
        public int MinMileage { get; set; }
        public int? MaxMileage { get; set; }
        public string? Color { get; set; }
        public bool? Abs { get; set; }
        public bool? Esp { get; set; }
        public bool? Asr { get; set; }
        public bool? Immobilizer { get; set; }
        public bool? Signaling { get; set; }

        public static CarFilter Create(double minPrice, double? maxPrice, double minEngineVolume, double? maxEngineVolume, string? transmissionType, string? bodyType, string? engineType, string? driveTrain, int minEnginePower, int? maxEnginePower, int minMileage, int? maxMileage, string? color, bool? abs, bool? esp, bool? asr, bool? immobilizer, bool? signaling)
        {
            return new CarFilter(minPrice, maxPrice, minEngineVolume, maxEngineVolume, transmissionType, bodyType, engineType, driveTrain, minEnginePower, maxEnginePower, minMileage, maxMileage, color, abs, esp, asr, immobilizer, signaling);
        }
    }
}
