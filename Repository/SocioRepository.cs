using ClubDeportivoAPI.Data;
using ClubDeportivoAPI.Dtos.SocioDtos;
using ClubDeportivoAPI.Helpers;
using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Mappers;
using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClubDeportivoAPI.Repository
{
    public class SocioRepository : ISocioRepository
    {
        private readonly ApplicationDbContext _context;

        public SocioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Socio> CreateSocioAsync(Socio socio)
        {
            await _context.Socios.AddAsync(socio);
            await _context.SaveChangesAsync();

            return socio;
        }

        public async Task<Socio?> DeletSocioByIdAsync(int id)
        {
            var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == id);

            if (socio == null)
            {
                return null;
            }

            _context.Remove(socio);
            await _context.SaveChangesAsync();

            return socio;
        }

        public async Task<List<Socio>> GetAllSociosAsync()
        {
            return await _context.Socios.ToListAsync();

            //ejemplo de como incluir varias tablas para dar formato al Json con distinta informacion
            //return await _context.Socios
            //    .Include(i => i.Inscripciones)
            //    .ThenInclude(a => a.Actividad)
            //    .Include(i => i.Inscripciones)
            //    .ThenInclude(c => c.Carnet).ToListAsync();
        }

        public async Task<List<Socio>?> GetAllSociosByName(SocioQO socio)
        {
            var socios = _context.Socios.AsQueryable();

            if (!string.IsNullOrWhiteSpace(socio.Nombre))
            {
                socios = socios.Where(s => s.Nombre.Contains(socio.Nombre));
            }

            if(!socio.Apellido.IsNullOrEmpty())
            {
                socios = socios.Where(s => s.Apellido.Contains(socio.Apellido));
            }

            if(!socio.ColumnaOrdenar.IsNullOrEmpty())
            {
                if(socio.ColumnaOrdenar.Equals("Nombre", StringComparison.OrdinalIgnoreCase))
                {
                    socios = socio.Descending ? socios.OrderByDescending(s => s.Nombre) : socios.OrderBy(s => s.Nombre);
                }

                if (socio.ColumnaOrdenar.Equals("Apellido", StringComparison.OrdinalIgnoreCase))
                {
                    socios = socio.Descending ? socios.OrderByDescending(s => s.Apellido) : socios.OrderBy(s => s.Apellido);
                }
            }

            //Calculo para elegir el numero de pagina y cuando registros por pagina
            var skip = (socio.NumeroDePagina - 1) * socio.TamanoDePagina;

            //           SKIP(salta registros) TAKE(TOMA registros)
            return await socios.Skip(skip).Take(socio.TamanoDePagina).ToListAsync();
        }

        public async Task<Socio> GetSocioByIdAsync(int id)
        {
            var socio = await _context.Socios.FindAsync(id);
            return socio;
        }

        public async Task<SocioDto?> UpdateSocioByIdAsync(int id, UpdateSocioRequestDto updateDto)
        {
            //busco si el id solicitado existe en la db
            var socioForUpdate = await _context.Socios.FirstOrDefaultAsync(e => e.Id == id);
            if (socioForUpdate == null)
            {
                return null;
            }

            //hago la actualizacion de contenido
            socioForUpdate.Nombre = updateDto.Nombre;
            socioForUpdate.Apellido = updateDto.Apellido;
            socioForUpdate.Dni = updateDto.Dni;
            socioForUpdate.Telefono = updateDto.Telefono;
            socioForUpdate.Email = updateDto.Email;

            //socioForUpdate.IdInscripcion = updateDto.IdInscripcion;

            //guardo los cambios y retorno el socio mappeado para el front.
            await _context.SaveChangesAsync();
            return SocioMapper.mapperSocio(socioForUpdate);


        }
    }
}
