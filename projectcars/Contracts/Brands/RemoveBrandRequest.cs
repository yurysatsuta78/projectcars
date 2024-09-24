using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Brands;

public record RemoveBrandRequest
(
    [Required] Guid BrandId
);
