using ClubDeportivoAPI.Models;

namespace ClubDeportivoAPI.Interfaces
{
    public interface IInscripcionRepository
    {
        Task<List<Inscripcion>?> GetAllInscripcionesAsync();
        Task<Inscripcion?> GetInscripcionByIdAsync(int id);
        Task<Inscripcion?> CreateInscripcionAsync(Inscripcion inscripcion, int mensual);
    }
}
