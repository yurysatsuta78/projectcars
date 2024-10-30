﻿using System.ComponentModel.DataAnnotations;

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
    [Required]int ProdYear,
    [Required]string Color,
    [Required]string InteriorColor,
    [Required]string InteriorMaterial,
    [Required]string Description,
    [Required]string CarState,
    [Required]string RegistrationCountry,
    [Required]bool TowBar,
    [Required]bool RoofRails,
    [Required]bool SunRoof,
    [Required]bool PanoramicRoof,
    [Required]bool RainSensor,
    [Required]bool RearViewCamera,
    [Required]bool ParkingSensors,
    [Required]bool BlindSpotSensor,
    [Required]bool HeatedSeats,
    [Required]bool HeatedWindshield,
    [Required]bool HeatedMirrors,
    [Required]bool HeatedSteeringWheel,
    [Required]bool AutonomousHeater,
    [Required]bool ClimateControl,
    [Required]bool AirConditioner,
    [Required]bool CruiseControl,
    [Required]bool SteeringWheelMultimedia,
    [Required]bool ElectricSeats,
    [Required]bool FrontElectroWindows,
    [Required]bool RearElectroWindows,
    [Required]bool AirBags,
    [Required]bool IsTradable,
    [Required]bool IsRegistred,
    [Required]bool Abs,
    [Required]bool Esp,
    [Required]bool Asr,
    [Required]bool Immobilizer,
    [Required]bool Signaling,
    [Required]Guid GenerationId,
    [Required]Guid CityId,
    [Required][MaxLength(10)]IFormFile[] Images
);
