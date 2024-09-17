namespace projectcars.Models
{
    public class Generation
    {
        private Generation(Guid generationId, string generationName, bool restyling, string startYear, string endYear)
        {
            GenerationId  = generationId;
            GenerationName = generationName;
            Restyling = restyling;
            StartYear = startYear;
            EndYear = endYear;
        }

        public static Generation Create(Guid generationId, string generationName, bool restyling, string startYear, string endYear)
        {
            return new Generation(generationId, generationName, restyling, startYear, endYear);
        }

        public Guid GenerationId { get; set; }
        public string GenerationName { get; set; } = String.Empty;
        public bool Restyling { get; set; }
        public string StartYear { get; set; } = String.Empty;
        public string EndYear { get; set; } = String.Empty;
        public Model? Model { get; set; }
        public string ImageBase64 { get; set; }
    }
}
