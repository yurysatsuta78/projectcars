using projectcars.Models;

namespace projectcars.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task<User> GetByPhoneNumber(string phoneNumber);
    }
}