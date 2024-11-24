using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cars;

public record FromFavouritesCarRequest
(
    [Required] Guid UserId,
    [Required] Guid CarId
);