using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClubDeportivoAPI.Controllers
{
    [Route("api/actividad")]
    [ApiController]
    public class ActividadController : Controller
    {
        private readonly IActividadRepository _actividadRepository;

        public ActividadController(IActividadRepository repository)
        {
            _actividadRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActividades()
        {
            var actividades = await _actividadRepository.GetAllActividadesAsync();
            return Ok(actividades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActividadById([FromRoute] int id)
        {
            var actividad = await _actividadRepository.GetActividadByIdAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }
            return Ok(actividad);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Actividad actividad)
        {
            var actividadCreada = await _actividadRepository.CreateActividadAsync(actividad);
            if (actividadCreada == null)
            {
                return BadRequest();
            }

            return Ok(actividadCreada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Actividad actividad)
        {
            var actividadUpdated = await _actividadRepository.UpdateActividadAsync(id, actividad);
            if (actividadUpdated == null)
            {
                return BadRequest();
            }

            return Ok(actividadUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var actividadBorrada = await _actividadRepository.DeleteActividadAsync(id);
            if(actividadBorrada == null)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}
