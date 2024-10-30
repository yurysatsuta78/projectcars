namespace projectcars.Models
{
    public class Generation
    {
        private Generation(Guid generationId, string generationName, bool restyling, int startYear, int endYear, Guid modelId, IFormFile image)
        {
            GenerationId  = generationId;
            GenerationName = generationName;
            Restyling = restyling;
            StartYear = startYear;
            EndYear = endYear;
            ModelId = modelId;
            Image = image;
        }

        public static Generation Create(Guid generationId, string generationName, bool restyling, int startYear, int endYear, Guid modelId, IFormFile image)
        {
            return new Generation(generationId, generationName, restyling, startYear, endYear, modelId, image);
        }

        public Guid GenerationId { get; }
        public string GenerationName { get; }
        public bool Restyling { get; }
        public int StartYear { get; }
        public int EndYear { get; }
        public Guid ModelId { get; }
        public IFormFile Image { get; }
    }
}
