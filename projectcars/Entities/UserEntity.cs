namespace projectcars.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public ICollection<UserAdEntity> UserAds { get; set; } = new List<UserAdEntity>();
        public ICollection<FavouriteCarEntity>? FavouriteCars { get; set; } = new List<FavouriteCarEntity>();
    }
}
