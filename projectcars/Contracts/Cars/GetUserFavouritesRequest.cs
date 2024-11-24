using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cars;

public record GetUserFavouritesRequest
(
    [Required] Guid UserId
);