using ClubDeportivoAPI.Data;
using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubDeportivoAPI.Repository
{
    public class CarnetRepository : ICarnetRepository
    {
        private readonly ApplicationDbContext _context;

        public CarnetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Carnet> CreateCarnetAsync(Carnet carnet)
        {
            await _context.Carnets.AddAsync(carnet);
            await _context.SaveChangesAsync();

            return carnet;
        }

        public async Task<Carnet> DeleteCarnetAsync(int carnetId)
        {
            var carnet = await _context.Carnets.FindAsync(carnetId);
            if (carnet != null)
            {
                return null;
            }

            _context.Carnets.Remove(carnet);
            await _context.SaveChangesAsync();

            return carnet;
        }

        public async Task<List<Carnet>> GetAllCarnetsAsync()
        {
            return await _context.Carnets.ToListAsync();
        }

        public async Task<Carnet> GetCarnetByIdAsync(int carnetId)
        {
            var carnet = await _context.Carnets.FindAsync(carnetId);
            if (carnet != null)
            {
                return null;
            }

            return carnet;
        }
    }
}
