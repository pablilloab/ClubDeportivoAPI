using ClubDeportivoAPI.Models;

namespace ClubDeportivoAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
