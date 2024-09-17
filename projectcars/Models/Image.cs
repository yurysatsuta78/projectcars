namespace projectcars.Models
{
    public class Image
    {
        private Image(Guid id, string imagePath) 
        {
            Id = id;
            ImagePath = imagePath;
        }

        public Guid Id { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string ImagePath { get; set; } = string.Empty;

        public static Image Create(Guid id, string imagePath) 
        {
            return new Image(id, imagePath);
        }
    }
}
