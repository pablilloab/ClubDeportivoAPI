using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubDeportivoAPI.Controllers
{
    [Route("api/carnet")]
    [ApiController]
    public class CarnetController : Controller
    {
        private readonly ICarnetRepository _carnetRepository;

        public CarnetController(ICarnetRepository carnetRepository)
        {
            _carnetRepository = carnetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarnet()
        {
            var carnets = await _carnetRepository.GetAllCarnetsAsync();
            if (carnets == null)
            {
                return NotFound();
            }

            return Ok(carnets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarnetById([FromRoute] int id)
        {
            var carnet = await _carnetRepository.GetCarnetByIdAsync(id);
            if (carnet == null)
            {
                return NotFound();
            }

            return Ok(carnet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarnet([FromBody] Carnet carnet)
        {
            var carnetCreado = await _carnetRepository.CreateCarnetAsync(carnet);
            if (carnetCreado == null)
            {
                return NotFound();
            }

            return Ok(carnet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletCarnet([FromRoute] int id)
        {
            var carnetBorrado = await _carnetRepository.DeleteCarnetAsync(id);
            if(carnetBorrado == null)
            {
                return NotFound();
            }

            return Ok(carnetBorrado);
        }
    }
}
