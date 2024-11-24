using projectcars.Models;

namespace projectcars.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}