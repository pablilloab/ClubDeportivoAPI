using ClubDeportivoAPI.Models;

namespace ClubDeportivoAPI.Interfaces
{
    public interface IAptoRepository
    {
        Task<List<Apto>?> GetAllAptosAsync();
        Task<Apto?> GetAptoByIdAsync(int id);
        Task<Apto?> CreateAptoAsync(Apto apto);
        Task<Apto?> DeleteAptoAsync(int id);
    }
}
