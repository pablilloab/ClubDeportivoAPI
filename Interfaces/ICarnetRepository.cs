using ClubDeportivoAPI.Models;

namespace ClubDeportivoAPI.Interfaces
{
    public interface ICarnetRepository
    {
        Task<List<Carnet>?> GetAllCarnetsAsync();
        Task<Carnet?> GetCarnetByIdAsync(int carnetId);
        Task<Carnet?> CreateCarnetAsync(Carnet carnet);
        Task<Carnet?> DeleteCarnetAsync(int carnetId);
    }
}
