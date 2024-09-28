namespace projectcars.Contracts.Cars;

public record FiltredCarsRequest
(
    double? MaxPrice,
    double? MaxEngineVolume,
    string? TransmissionType,
    string? BodyType,
    string? EngineType,
    string? DriveTrain,
    int? MaxEnginePower,
    int? MaxMileage,
    string? Color,
    bool? Abs,
    bool? Esp,
    bool? Asr,
    bool? Immobilizer,
    bool? Signaling,
    double MinPrice = 0,
    double MinEngineVolume = 0.0,
    int MinEnginePower = 0,
    int MinMileage = 0
);
