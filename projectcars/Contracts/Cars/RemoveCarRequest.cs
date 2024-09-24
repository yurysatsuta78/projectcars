using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cars;

public record RemoveCarRequest
(
    [Required] Guid Id
);
