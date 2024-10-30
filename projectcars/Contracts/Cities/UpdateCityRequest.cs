using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cities;

public record UpdateCityRequest
(
    [Required]Guid CityId,
    [Required]string CityName,
    [Required]Guid RegionId
);
