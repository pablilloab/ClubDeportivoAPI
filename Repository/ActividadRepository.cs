using ClubDeportivoAPI.Data;
using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubDeportivoAPI.Repository
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly ApplicationDbContext _context;

        public ActividadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Actividad> CreateActividadAsync(Actividad actividad)
        {
            if (actividad == null)
            {
                return null;
            }
            await _context.Actividades.AddAsync(actividad);
            await _context.SaveChangesAsync();
            return actividad;
        }

        public async Task<Actividad> DeleteActividadAsync(int id)
        {
            
            var actividadABorrar = _context.Actividades.FirstOrDefault(a => a.Id == id);   
            if (actividadABorrar == null)
            {
                return null;
            }

            try
            {
                _context.Remove(actividadABorrar);
                await _context.SaveChangesAsync();
                return actividadABorrar;
            } catch(DbUpdateException e)
            {
                throw new DbUpdateException($"Error al intentar eliminar la actividad con ID {id}. Detalles: {e.Message}", e);
            }
            
        }

        public async Task<Actividad> GetActividadByIdAsync(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            return actividad;
            
        }

        public async Task<List<Actividad>> GetAllActividadesAsync()
        {
            var listadoActividades = await _context.Actividades.ToListAsync();
            return listadoActividades;
        }

        public async Task<Actividad> UpdateActividadAsync(int id, Actividad actividad)
        {
            var actividadParaUpdate = await _context.Actividades.FirstOrDefaultAsync(a => a.Id == id);
            if (actividadParaUpdate == null)
            {
                return null;
            }

            //muevo los datos del objeto que se envio por el body de la request.
            actividadParaUpdate.Descripcion = actividad.Descripcion;
            actividadParaUpdate.Horario = actividad.Horario;
            actividadParaUpdate.Costo = actividad.Costo;

            await _context.SaveChangesAsync();
            return actividadParaUpdate;
        }
    }
}
