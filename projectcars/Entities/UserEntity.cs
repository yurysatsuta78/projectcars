namespace projectcars.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PasswordHash { get; set; }
        public ICollection<CarEntity> UserAds { get; set; } = new List<CarEntity>();
        public ICollection<CarEntity> FavouriteCars { get; set; } = new List<CarEntity>();
        public ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
    }
}
