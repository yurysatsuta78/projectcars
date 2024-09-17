using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Models;

public record CreateModelRequest
(
    [Required] string ModelName,
    [Required] Guid BrandId
);
