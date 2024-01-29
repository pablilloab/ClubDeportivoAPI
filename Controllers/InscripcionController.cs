using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClubDeportivoAPI.Controllers
{
    [Route("api/inscripcion")]
    [ApiController]
    public class InscripcionController :Controller
    {
        private readonly IInscripcionRepository _inscripcionRepository;

        public InscripcionController(IInscripcionRepository inscripcionRepository)
        {
            _inscripcionRepository = inscripcionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInscripciones() 
        { 
            var inscripciones = await _inscripcionRepository.GetAllInscripcionesAsync();
            if (inscripciones == null)
            {
                return NotFound();
            }

            return Ok(inscripciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscripcionById([FromRoute] int id)
        {
            var inscripcion = await _inscripcionRepository.GetInscripcionByIdAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return Ok(inscripcion);
        }

        [HttpPost("{mensual}")]
        public async Task<IActionResult> CreateInscipcion([FromRoute] int mensual, [FromBody] Inscripcion inscripcion)
        {
            var inscripcionCreada = await _inscripcionRepository.CreateInscripcionAsync(inscripcion, mensual);
            if (inscripcionCreada == null)
            {
                return BadRequest();
            }

            return Ok(inscripcionCreada);
        }
    }
}
