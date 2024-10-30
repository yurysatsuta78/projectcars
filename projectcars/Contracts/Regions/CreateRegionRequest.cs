using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Regions;

public record CreateRegionRequest
(
    [Required]string RegionName
);