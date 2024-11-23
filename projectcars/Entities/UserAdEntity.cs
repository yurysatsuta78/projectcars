namespace projectcars.Entities
{
    public class UserAdEntity
    {
        public Guid UserId { get; set; }
        public UserEntity UserEntity { get; set; }

        public Guid CarId { get; set; }
        public CarEntity CarEntity { get; set; }
    }
}
