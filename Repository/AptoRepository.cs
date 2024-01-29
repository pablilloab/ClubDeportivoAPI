using ClubDeportivoAPI.Data;
using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubDeportivoAPI.Repository
{
    public class AptoRepository : IAptoRepository
    {
        private readonly ApplicationDbContext _context;

        public AptoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Apto?> CreateAptoAsync(Apto apto)
        {
            await _context.Aptos.AddAsync(apto);
            await _context.SaveChangesAsync();

            return apto;
        }

        public async Task<Apto?> DeleteAptoAsync(int id)
        {
            var apto = await _context.Aptos.FindAsync(id);
            if (apto == null)
            {
                return null;
            }

            _context.Aptos.Remove(apto);
            await _context.SaveChangesAsync();

            return apto;
        }

        public async Task<List<Apto>?> GetAllAptosAsync()
        {
            return await _context.Aptos.ToListAsync();
        }

        public async Task<Apto?> GetAptoByIdAsync(int id)
        {
            var apto = await _context.Aptos.FindAsync(id);
            if (apto == null)
            {
                return null;
            }

            return apto;
        }
    }
}
