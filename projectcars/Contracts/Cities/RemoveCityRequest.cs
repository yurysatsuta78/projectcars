using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cities;

public record RemoveCityRequest
(
    [Required]Guid CityId
);
