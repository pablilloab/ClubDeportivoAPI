using ClubDeportivoAPI.Data;
using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubDeportivoAPI.Repository
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ISocioRepository _socioRepository;
        private readonly IActividadRepository _actividadRepository;
        private readonly ICarnetRepository _carnetRepository;
        private readonly ICuotaRepository _cuotaRepository;

        public InscripcionRepository(ApplicationDbContext context, ISocioRepository socioRepository, IActividadRepository actividadRepository, ICarnetRepository carnetRepository, ICuotaRepository cuotaRepository)
        {
            _context = context;
            _socioRepository = socioRepository;
            _actividadRepository = actividadRepository;
            _carnetRepository = carnetRepository;
            _cuotaRepository = cuotaRepository;
        }

        // ** ** PROCESO PARA REGISTRAR UNA INSCRIPCION AL CLUB ** **
        public async Task<Inscripcion?> CreateInscripcionAsync(Inscripcion inscripcion, int mensual)
        {
            //reviso si el socio existe en la BBDD
            var socio = await _socioRepository.GetSocioByIdAsync(inscripcion.SocioId ?? 0);
            if (socio == null)
            {
                return null;
            }

            //reviso si la actividad existe en la BBDD
            var actividad = await _actividadRepository.GetActividadByIdAsync(inscripcion.ActividadId ?? 0);
            if (actividad == null)
            {
                return null;
            }

            //preparo las cuotas
            if (mensual == 0)
            {
                var inscripcionCreada = await _context.Inscripciones.AddAsync(inscripcion);
                await _context.SaveChangesAsync();

                if (inscripcionCreada == null)
                {
                    return null;
                }

                return inscripcion;
            }
            else
            {
                //voy a buscar el ultimo id de cuota creado
                int id = await _context.Cuotas.OrderByDescending(c => c.Id).Select(c => c.Id).FirstOrDefaultAsync();
                //sumo 1 al id para generar el id nuevo para las cuotas
                id ++;
                int dias = 0;

                for(int i = 0; i < mensual; i++)
                {
                    Cuota cuota = new Cuota();
                    cuota.Id = id;
                    cuota.FechaPago = DateTime.Now.AddDays(dias);
                    cuota.Monto = inscripcion.Actividad.Costo;
                    cuota.MedioDePago = "contado";
                    cuota.PagoRealizado = false;

                    var cuotaCreada = await _cuotaRepository.CreateCuotaAsync(cuota);
                    if (cuotaCreada == null)
                    {
                        return null;
                    }

                    dias += 30;                    
                }
                var inscripcionCreada = await _context.Inscripciones.AddAsync(inscripcion);
                await _context.SaveChangesAsync();

                if (inscripcionCreada == null)
                {
                    return null;
                }

                return inscripcion;               
            }
            
        }

        public async Task<List<Inscripcion>?> GetAllInscripcionesAsync()
        {
            return await _context.Inscripciones.Include(a => a.Actividad).Include(c => c.Carnet).Include(cta => cta.Cuotas).ToListAsync();
        }

        public async Task<Inscripcion?> GetInscripcionByIdAsync(int id)
        {
            return await _context.Inscripciones.FirstOrDefaultAsync(e => e.Id == id);
        }


    }
}
