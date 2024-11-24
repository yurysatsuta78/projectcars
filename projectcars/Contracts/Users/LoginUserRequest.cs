using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Users;

public record LoginUserRequest
(
    [Required] string PhoneNumber,
    [Required] string Password
);