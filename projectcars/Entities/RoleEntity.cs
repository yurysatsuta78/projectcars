namespace projectcars.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    }
}
