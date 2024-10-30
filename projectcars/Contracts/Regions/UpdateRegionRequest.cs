using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Regions;

public record UpdateRegionRequest
(
    [Required]Guid RegionId,
    [Required]string RegionName
);
