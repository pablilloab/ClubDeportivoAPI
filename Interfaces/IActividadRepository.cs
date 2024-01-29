using ClubDeportivoAPI.Models;

namespace ClubDeportivoAPI.Interfaces
{
    public interface IActividadRepository
    {
        Task<List<Actividad>> GetAllActividadesAsync();
        Task<Actividad> GetActividadByIdAsync(int id);
        Task<Actividad?> CreateActividadAsync(Actividad actividad);
        Task<Actividad> UpdateActividadAsync(int id, Actividad actividad);
        Task<Actividad> DeleteActividadAsync(int id);        
    }
}
