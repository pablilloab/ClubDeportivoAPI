using ClubDeportivoAPI.Data;
using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubDeportivoAPI.Repository
{
    public class CuotaRepository : ICuotaRepository
    {
        private readonly ApplicationDbContext _context;

        public CuotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cuota> CreateCuotaAsync(Cuota cuota)
        {
            await _context.Cuotas.AddAsync(cuota);
            await _context.SaveChangesAsync();

            return cuota;
        }

        public async Task<Cuota> DeleteCuotaAsync(int id)
        {
            var cuota = await _context.Cuotas.FirstOrDefaultAsync(x => x.Id == id);
            if (cuota == null)
            {
                return null;
            }
            _context.Cuotas.Remove(cuota);
            await _context.SaveChangesAsync();

            return cuota;
        }

        public async Task<List<Cuota>> GetAllCuotasAsync()
        {
            var cuotas = await _context.Cuotas.ToListAsync();
            return cuotas;
        }

        //TODO revisar este metodo, debe traer las cuotas por id, el FindAsyn no funciona (necesita los dos parametros PK)
        public async Task<List<Cuota>> GetCuotaByIdAsync(int id)
        {
            //var cuota = await _context.Cuotas.FindAsync(id);
            var cuota = await _context.Cuotas.Where(e => e.Id == id).ToListAsync();
            return cuota;
        }
    }
}
