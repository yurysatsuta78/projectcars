namespace projectcars.Models
{
    public class Car
    {
        private Car
            (
                Guid id,
                double price,
                double engineVolume,
                string transmissionType,
                string bodyType,
                string engineType,
                string driveTrain,
                int enginePower,
                int mileage,
                int prodYear,
                string color,
                string interiorColor,
                string interiorMaterial,
                string description,
                string carState,
                string registrationCountry,
                bool towBar,
                bool roofRails,
                bool sunRoof,
                bool panoramicRoof,
                bool rainSensor,
                bool rearViewCamera,
                bool parkingSensors,
                bool blindSpotSensor,
                bool heatedSeats,
                bool heatedWindshield,
                bool heatedMirrors,
                bool heatedSteeringWheel,
                bool autonomousHeater,
                bool climateControl,
                bool airConditioner,
                bool cruiseControl,
                bool steeringWheelMultimedia,
                bool electricSeats,
                bool frontElectroWindows,
                bool rearElectroWindows,
                bool airBags,
                bool isTradable,
                bool isRegistred,
                bool abs,
                bool esp,
                bool asr,
                bool immobilizer,
                bool signaling,
                Guid generationId,
                Guid cityId,
                IFormFile[] images
            )
        {
            Id = id;
            Price = price;
            EngineVolume = engineVolume;
            TransmissionType = transmissionType;
            BodyType = bodyType;
            EngineType = engineType;
            DriveTrain = driveTrain;
            EnginePower = enginePower;
            Mileage = mileage;
            ProdYear = prodYear;
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
            GenerationId = generationId;
            CityId = cityId;
            Images = images;
        }

        public static Car Create
            (
                Guid id,
                double price,
                double engineVolume,
                string transmissionType,
                string bodyType,
                string engineType,
                string driveTrain,
                int enginePower,
                int mileage,
                int prodYear,
                string color,
                string interiorColor,
                string interiorMaterial,
                string description,
                string carState,
                string registrationCountry,
                bool towBar,
                bool roofRails,
                bool sunRoof,
                bool panoramicRoof,
                bool rainSensor,
                bool rearViewCamera,
                bool parkingSensors,
                bool blindSpotSensor,
                bool heatedSeats,
                bool heatedWindshield,
                bool heatedMirrors,
                bool heatedSteeringWheel,
                bool autonomousHeater,
                bool climateControl,
                bool airConditioner,
                bool cruiseControl,
                bool steeringWheelMultimedia,
                bool electricSeats,
                bool frontElectroWindows,
                bool rearElectroWindows,
                bool airBags,
                bool isTradable,
                bool isRegistred,
                bool abs,
                bool esp,
                bool asr,
                bool immobilizer,
                bool signaling,
                Guid generationId,
                Guid cityId,
                IFormFile[] images
            )
        {
            return new Car
                (
                    id,
                    price,
                    engineVolume,
                    transmissionType,
                    bodyType,
                    engineType,
                    driveTrain,
                    enginePower,
                    mileage,
                    prodYear,
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
                    generationId,
                    cityId,
                    images
                );
        }

        public Guid Id { get; }
        public double Price { get; }
        public double EngineVolume { get; }
        public string TransmissionType { get; }
        public string BodyType { get; }
        public string EngineType { get; }
        public string DriveTrain { get; }
        public int EnginePower { get; }
        public int Mileage { get; }
        public int ProdYear { get; }
        public string Color { get; }
        public string InteriorColor { get; set; }
        public string InteriorMaterial { get; set; }
        public string Description { get; set; }
        public string CarState { get; set; }
        public string RegistrationCountry { get; set; }
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
        public bool Abs { get; }
        public bool Esp { get; }
        public bool Asr { get; }
        public bool Immobilizer { get; }
        public bool Signaling { get; }
        public Guid GenerationId { get; }
        public Guid CityId { get; }
        public IFormFile[] Images { get; }
    }
}
