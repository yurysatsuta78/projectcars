namespace projectcars.Entities
{
    public class UserFavouriteCarEntity
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public CarEntity CarEntity { get; set; }
    }
}
