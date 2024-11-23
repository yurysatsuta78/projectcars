namespace projectcars.Entities
{
    public class CarEntity
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
        public string? CarState { get; set; } //В каком состоянии?
        public string? RegistrationCountry { get; set; } //Страна регистрации
        public bool TowBar { get; set; } //Есть фаркоп?
        public bool RoofRails { get; set; } //Есть рейлинги?
        public bool SunRoof {  get; set; } //Есть люк?
        public bool PanoramicRoof { get; set; } //Есть панорамная крыша?
        public bool RainSensor { get; set; } //Есть датчик дождя?
        public bool RearViewCamera { get; set; } //Есть камера заднего вида?
        public bool ParkingSensors { get; set; } //Есть парктроники?
        public bool BlindSpotSensor {  get; set; } //Есть контроль мертвых зон?
        public bool HeatedSeats { get; set; } //Обогревы
        public bool HeatedWindshield { get; set; } //Обогревы
        public bool HeatedMirrors { get; set; } //Обогревы
        public bool HeatedSteeringWheel { get; set; } //Обогревы
        public bool AutonomousHeater { get; set; } //Обогревы
        public bool ClimateControl { get; set; } //Климат контроль и кондиционер
        public bool AirConditioner { get; set; } //Климат контроль и кондиционер
        public bool CruiseControl { get; set; } //Круиз-контроль
        public bool SteeringWheelMultimedia { get; set; } //Мультимедиа на руле
        public bool ElectricSeats { get; set; } //Электросидения
        public bool FrontElectroWindows { get; set; } //Передние и задние электростекла
        public bool RearElectroWindows { get; set; } //Передние и задние электростекла
        public bool AirBags { get; set; } //Подушки безопасности
        public bool IsTradable { get; set; } //Возможен обмен?
        public bool IsRegistred { get; set; } //Снята с учета?
        public bool Abs {  get; set; } //ABS
        public bool Esp { get; set; } //ESP
        public bool Asr { get; set; } //Traction Control       
        public bool Immobilizer { get; set; } //Immobilizer        
        public bool Signaling { get; set; } //Signaling 
        public bool IsHidden { get; set; } //Скрыта?(В случае удаления объявления)
        public GenerationEntity? GenerationEntity { get; }
        public Guid GenerationId { get; set; }
        public ICollection<ImageEntity>? ImageEntities { get; }
        public CityEntity? CityEntity { get; }
        public Guid CityId { get; set; }
        public ICollection<UserAdEntity>? UserAds { get; set; } = new List<UserAdEntity>();
        public ICollection<FavouriteCarEntity>? FavouriteCars { get; set; } = new List<FavouriteCarEntity>();
    }
}
