using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Users;

public record RegisterUserRequest
(
    [Required] string Name,
    [Required] string Surname,
    [Required] string PhoneNumber,
    [Required] string Password
);
