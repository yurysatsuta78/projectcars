using projectcars.Models;
using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Cars;

public record UpdateCarRequest
(
    [Required]Car car
);
