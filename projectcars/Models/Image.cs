namespace projectcars.Models
{
    public class Image
    {
        private Image(Guid id, string imageUrl) 
        {
            Id = id;
            ImageUrl = imageUrl;
        }

        public Guid Id { get; }
        public string ImageUrl { get; }

        public static Image Create(Guid id, string imageUrl) 
        {
            return new Image(id, imageUrl);
        }
    }
}
