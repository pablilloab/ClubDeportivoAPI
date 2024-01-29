using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClubDeportivoAPI.Controllers
{
    [Route("api/cuota")]
    [ApiController]
    public class CuotaController : Controller
    {
        private readonly ICuotaRepository _cuotaRepository;

        public CuotaController(ICuotaRepository cuotaRepository)
        {
            _cuotaRepository = cuotaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCuotas()
        {
            var cuotas = await _cuotaRepository.GetAllCuotasAsync();
            if(cuotas == null)
            {
                return NotFound();
            }

            return Ok(cuotas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuotaById([FromRoute] int id)
        {
            var cuota = await _cuotaRepository.GetCuotaByIdAsync(id);
            if(cuota == null)
            {
                return NotFound();
            }

            return Ok(cuota);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCuota([FromBody] Cuota cuota)
        {
            var cuotaCreada = await _cuotaRepository.CreateCuotaAsync(cuota);
            if (cuotaCreada == null)
            {
                return NotFound();
            }

            return Ok(cuotaCreada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuota([FromRoute] int id)
        {
            var cuotaBorrada = await _cuotaRepository.DeleteCuotaAsync(id);
            if (cuotaBorrada == null)
            {
                return BadRequest();
            }

            return Ok(cuotaBorrada);
        }
    }
}
