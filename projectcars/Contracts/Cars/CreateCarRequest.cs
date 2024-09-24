using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cars;

public record CreateCarRequest
(
    [Required]double Price,
    [Required]double EngineVolume,
    [Required]string TransmissionType,
    [Required]string BodyType,
    [Required]string EngineType,
    [Required]string DriveTrain,
    [Required]int EnginePower,
    [Required]int Mileage,
    [Required]string Color,
    [Required]bool Abs,
    [Required]bool Esp,
    [Required]bool Asr,
    [Required]bool Immobilazer,
    [Required]bool Signaling,
    [Required]Guid GenerationId,
    [Required][MaxLength(10)]IFormFile[] Images
);
