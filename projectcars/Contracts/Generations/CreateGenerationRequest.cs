﻿using System.ComponentModel.DataAnnotations;

namespace projectcars.Contracts.Generations;

public record CreateGenerationRequest
(
    [Required] string GenerationName,
    [Required] bool Restyling,
    [Required] int StartYear,
    [Required] int EndYear,
    [Required] Guid ModelId,
    [Required] IFormFile Image
);
