namespace projectcars.Models
{
    public class CarFilter
    {
        private CarFilter(double? minPrice, 
            double? maxPrice, 
            double? minEngineVolume, 
            double? maxEngineVolume, 
            string? transmissionType, 
            string? bodyType, 
            string? engineType, 
            string? driveTrain, 
            int? minEnginePower, 
            int? maxEnginePower, 
            int? minMileage, 
            int? maxMileage, 
            string? color,
            string? interiorColor,
            string? interiorMaterial,
            string? description,
            string? carState,
            string? registrationCountry,
            bool? towBar,
            bool? roofRails,
            bool? sunRoof,
            bool? panoramicRoof,
            bool? rainSensor,
            bool? rearViewCamera,
            bool? parkingSensors,
            bool? blindSpotSensor,
            bool? heatedSeats,
            bool? heatedWindshield,
            bool? heatedMirrors,
            bool? heatedSteeringWheel,
            bool? autonomousHeater,
            bool? climateControl,
            bool? airConditioner,
            bool? cruiseControl,
            bool? steeringWheelMultimedia,
            bool? electricSeats,
            bool? frontElectroWindows,
            bool? rearElectroWindows,
            bool? airBags,
            bool? isTradable,
            bool? isRegistred,
            bool? abs, 
            bool? esp, 
            bool? asr, 
            bool? immobilizer, 
            bool? signaling, 
            int? minYear, 
            int? maxYear, 
            Guid? generationId, 
            Guid? modelId, 
            Guid? brandId,
            Guid? cityId) 
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
            InteriorColor = interiorColor;
            InteriorMaterial = interiorMaterial;
            Description = description;
            CarState = carState;
            RegistrationCountry = registrationCountry;
            TowBar = towBar;
            RoofRails = roofRails;
            SunRoof = sunRoof;
            PanoramicRoof = panoramicRoof;
            RainSensor = rainSensor;
            RearViewCamera = rearViewCamera;
            ParkingSensors = parkingSensors;
            BlindSpotSensor = blindSpotSensor;
            HeatedSeats = heatedSeats;
            HeatedWindshield = heatedWindshield;
            HeatedMirrors = heatedMirrors;
            HeatedSteeringWheel = heatedSteeringWheel;
            AutonomousHeater = autonomousHeater;
            ClimateControl = climateControl;
            AirConditioner = airConditioner;
            CruiseControl = cruiseControl;
            SteeringWheelMultimedia = steeringWheelMultimedia;
            ElectricSeats = electricSeats;
            FrontElectroWindows = frontElectroWindows;
            RearElectroWindows = rearElectroWindows;
            AirBags = airBags;
            IsTradable = isTradable;
            IsRegistred = isRegistred;
            Abs = abs;
            Esp = esp;
            Asr = asr;
            Immobilizer = immobilizer;
            Signaling = signaling;
            MinYear = minYear;
            MaxYear = maxYear;
            GenerationId = generationId;
            ModelId = modelId;
            BrandId = brandId;
            CityId = cityId;
        }

        public double? MinPrice { get; }
        public double? MaxPrice { get; }
        public double? MinEngineVolume { get; }
        public double? MaxEngineVolume { get; }
        public string? TransmissionType { get; }
        public string? BodyType { get; }
        public string? EngineType { get; }
        public string? DriveTrain { get; }
        public int? MinEnginePower { get; }
        public int? MaxEnginePower { get; }
        public int? MinMileage { get; }
        public int? MaxMileage { get; }
        public string? Color { get; }
        public string? InteriorColor { get; set; }
        public string? InteriorMaterial { get; set; }
        public string? Description { get; set; }
        public string? CarState { get; set; }
        public string? RegistrationCountry { get; set; }
        public bool? TowBar { get; set; }
        public bool? RoofRails { get; set; }
        public bool? SunRoof { get; set; }
        public bool? PanoramicRoof { get; set; }
        public bool? RainSensor { get; set; }
        public bool? RearViewCamera { get; set; }
        public bool? ParkingSensors { get; set; }
        public bool? BlindSpotSensor { get; set; }
        public bool? HeatedSeats { get; set; }
        public bool? HeatedWindshield { get; set; }
        public bool? HeatedMirrors { get; set; }
        public bool? HeatedSteeringWheel { get; set; }
        public bool? AutonomousHeater { get; set; }
        public bool? ClimateControl { get; set; }
        public bool? AirConditioner { get; set; }
        public bool? CruiseControl { get; set; }
        public bool? SteeringWheelMultimedia { get; set; }
        public bool? ElectricSeats { get; set; }
        public bool? FrontElectroWindows { get; set; }
        public bool? RearElectroWindows { get; set; }
        public bool? AirBags { get; set; }
        public bool? IsTradable { get; set; }
        public bool? IsRegistred { get; set; }
        public bool? Abs { get; }
        public bool? Esp { get; }
        public bool? Asr { get; }
        public bool? Immobilizer { get; }
        public bool? Signaling { get; }
        public int? MinYear { get; }
        public int? MaxYear { get; }
        public Guid? GenerationId { get; }
        public Guid? ModelId { get; }
        public Guid? BrandId { get; }
        public Guid? CityId { get; }

        public static CarFilter Create(double? minPrice, 
            double? maxPrice, 
            double? minEngineVolume, 
            double? maxEngineVolume, 
            string? transmissionType, 
            string? bodyType, 
            string? engineType, 
            string? driveTrain, 
            int? minEnginePower, 
            int? maxEnginePower, 
            int? minMileage, 
            int? maxMileage, 
            string? color,
            string? interiorColor,
            string? interiorMaterial,
            string? description,
            string? carState,
            string? registrationCountry,
            bool? towBar,
            bool? roofRails,
            bool? sunRoof,
            bool? panoramicRoof,
            bool? rainSensor,
            bool? rearViewCamera,
            bool? parkingSensors,
            bool? blindSpotSensor,
            bool? heatedSeats,
            bool? heatedWindshield,
            bool? heatedMirrors,
            bool? heatedSteeringWheel,
            bool? autonomousHeater,
            bool? climateControl,
            bool? airConditioner,
            bool? cruiseControl,
            bool? steeringWheelMultimedia,
            bool? electricSeats,
            bool? frontElectroWindows,
            bool? rearElectroWindows,
            bool? airBags,
            bool? isTradable,
            bool? isRegistred,
            bool? abs, 
            bool? esp, 
            bool? asr, 
            bool? immobilizer, 
            bool? signaling, 
            int? minYear, 
            int? maxYear, 
            Guid? generationId, 
            Guid? modelId, 
            Guid? brandId,
            Guid? cityId)
        {
            return new CarFilter(minPrice, 
                maxPrice, 
                minEngineVolume, 
                maxEngineVolume, 
                transmissionType, 
                bodyType, 
                engineType, 
                driveTrain, 
                minEnginePower, 
                maxEnginePower, 
                minMileage, 
                maxMileage, 
                color,
                interiorColor,
                interiorMaterial,
                description,
                carState,
                registrationCountry,
                towBar,
                roofRails,
                sunRoof,
                panoramicRoof,
                rainSensor,
                rearViewCamera,
                parkingSensors,
                blindSpotSensor,
                heatedSeats,
                heatedWindshield,
                heatedMirrors,
                heatedSteeringWheel,
                autonomousHeater,
                climateControl,
                airConditioner,
                cruiseControl,
                steeringWheelMultimedia,
                electricSeats,
                frontElectroWindows,
                rearElectroWindows,
                airBags,
                isTradable,
                isRegistred,
                abs, 
                esp, 
                asr, 
                immobilizer, 
                signaling, 
                minYear, 
                maxYear, 
                generationId, 
                modelId, 
                brandId,
                cityId);
        }
    }
}
