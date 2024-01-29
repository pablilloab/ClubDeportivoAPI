using ClubDeportivoAPI.Models;

namespace ClubDeportivoAPI.Interfaces
{
    public interface ICuotaRepository
    {
        Task<List<Cuota>?> GetAllCuotasAsync();
        Task<List<Cuota>?> GetCuotaByIdAsync(int id);
        Task<Cuota?> CreateCuotaAsync(Cuota cuota);
        Task<Cuota?> DeleteCuotaAsync(int id);
    }
}
