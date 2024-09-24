using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Generations;

public record RemoveGenerationRequest
(
    [Required] Guid GenerationId
);
