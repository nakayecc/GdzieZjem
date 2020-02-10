using GdzieZjemAPI.Models;

namespace GdzieZjemAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
        public User AddTokenToUser(string username , string password);

    }
}