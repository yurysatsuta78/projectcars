using projectcars.Entities;

namespace projectcars.Models
{
    public class User
    {
        private User(Guid id, string name, string surname, string phoneNumber, string passwordHash) 
        {
            Id = id;
            Name = name;
            SurName = surname;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public static User Create(Guid id, string name, string surname, string phoneNumber, string passwordHash) 
        {
            return new User(id, name, surname, phoneNumber, passwordHash);
        }
    }
}
