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
                string color,
                bool abs,
                bool esp,
                bool asr,
                bool immobilizer,
                bool signaling
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
            Color = color;
            Abs = abs;
            Esp = esp;
            Asr = asr;
            Immobilizer = immobilizer;
            Signaling = signaling;
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
                string color,
                bool abs,
                bool esp,
                bool asr,
                bool immobilizer,
                bool signaling
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
                    color,
                    abs,
                    esp,
                    asr,
                    immobilizer,
                    signaling
                );
        }

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
        public Generation? Generation { get; set; }

        //ABS
        public bool Abs { get; set; }
        //ESP
        public bool Esp { get; set; }
        //Traction Control
        public bool Asr { get; set; }
        //Immobilizer
        public bool Immobilizer { get; set; }
        //Signaling
        public bool Signaling { get; set; }
    }
}
