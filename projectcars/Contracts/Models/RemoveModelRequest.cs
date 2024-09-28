using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Models;

public record RemoveModelRequest
(
    [Required]Guid id  
);