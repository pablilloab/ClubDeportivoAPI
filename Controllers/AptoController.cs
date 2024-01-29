using Azure.Core;
using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubDeportivoAPI.Controllers
{
    [Route("api/apto")]
    [ApiController]
    public class AptoController : Controller
    {
        private readonly IAptoRepository _aptoRepository;

        public AptoController(IAptoRepository aptoRepository)
        {
            _aptoRepository = aptoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAptosAsync()
        {
            var aptos = await _aptoRepository.GetAllAptosAsync();
            if (aptos == null)
            {
                return NotFound();
            }

            return Ok(aptos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAptoById([FromRoute] int id)
        {
            var apto = await _aptoRepository.GetAptoByIdAsync(id);
            if (apto == null)
            {
                return NotFound();
            }

            return Ok(apto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApto([FromBody] Apto apto)
        {
            var aptoCreado = await _aptoRepository.CreateAptoAsync(apto);
            if (aptoCreado == null)
            {
                return BadRequest();
            }

            return Ok(aptoCreado);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApto([FromRoute] int id)
        {
            var aptoBorrado = await _aptoRepository.DeleteAptoAsync(id);
            if(aptoBorrado == null)
            {
                return BadRequest();
            }
            return Ok(aptoBorrado);
        }


    }
}
