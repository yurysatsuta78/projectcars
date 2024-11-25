using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cars;

public record ToFavouritesCarRequest
(
    [Required] Guid CarId
);
