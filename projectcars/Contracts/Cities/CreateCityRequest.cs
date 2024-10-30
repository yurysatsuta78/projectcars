using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cities;

public record CreateCityRequest
(
    [Required]string CityName,
    [Required]Guid RegionId
);
