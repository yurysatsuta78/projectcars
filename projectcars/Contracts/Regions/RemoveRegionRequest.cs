using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Regions;

public record RemoveRegionRequest
(
    [Required]Guid RegionId
);
