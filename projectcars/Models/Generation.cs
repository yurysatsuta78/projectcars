using projectcars.Entities;

namespace projectcars.Models
{
    public class Generation
    {
        private Generation
            (
                string generationName,
                bool restyling,
                string startYear,
                string endYear
            )
        {
            GenerationName = generationName;
            Restyling = restyling;
            StartYear = startYear;
            EndYear = endYear;
        }

        public static Generation Create
            (
                string generationName,
                bool restyling,
                string startYear,
                string endYear
            )
        {
            return new Generation
                (
                    generationName,
                    restyling,
                    startYear,
                    endYear
                );
        }

        public int GenerationId { get; set; }
        public string GenerationName { get; set; } = String.Empty;
        public bool Restyling { get; set; }
        public string StartYear { get; set; } = String.Empty;
        public string EndYear { get; set; } = String.Empty;
        public Model? Model { get; set; }
    }
}
