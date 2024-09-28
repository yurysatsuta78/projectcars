namespace projectcars.Entities
{
    public class CarEntity
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public double EngineVolume { get; set; }
        public string TransmissionType { get; set; } = String.Empty;
        public string BodyType { get; set; } = String.Empty;
        public string EngineType { get; set; } = String.Empty;
        public string DriveTrain { get; set; } = String.Empty;
        public int EnginePower { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; } = String.Empty;
        public bool IsHidden { get; set; }

        //ABS
        public bool Abs {  get; set; }
        //ESP
        public bool Esp { get; set; }
        //Traction Control
        public bool Asr { get; set; }
        //Immobilizer
        public bool Immobilizer { get; set; }
        //Signaling
        public bool Signaling { get; set; }
        public GenerationEntity? GenerationEntity { get; set; }
        public Guid GenerationId { get; set; }
        public ICollection<ImageEntity>? ImageEntities { get; }
    }
}
