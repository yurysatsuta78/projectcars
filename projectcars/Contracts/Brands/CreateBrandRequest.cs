using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Brands;

public record CreateBrandRequest
(
    [Required] string BrandName,
    [Required] IFormFile Image
);
