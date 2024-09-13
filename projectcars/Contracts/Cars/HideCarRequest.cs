using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cars;

public record HideCarRequest
(
    [Required]Guid id
);
