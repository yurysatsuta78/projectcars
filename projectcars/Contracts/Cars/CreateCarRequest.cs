using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cars;

public record CreateCarRequest
(
    [Required]double price,
    [Required]double engineVolume,
    [Required]string transmissionType,
    [Required]string bodyType,
    [Required]string engineType,
    [Required]string driveTrain,
    [Required]int enginePower,
    [Required]int mileage,
    [Required]string color,
    [Required]bool abs,
    [Required]bool esp,
    [Required]bool asr,
    [Required]bool immobilazer,
    [Required]bool signaling,
    [Required]int generationId
);
