using GdzieZjemAPI.Models;

namespace GdzieZjemAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string username, string password);

    }
}