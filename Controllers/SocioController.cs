using ClubDeportivoAPI.Data;
using ClubDeportivoAPI.Dtos.SocioDtos;
using ClubDeportivoAPI.Helpers;
using ClubDeportivoAPI.Interfaces;
using ClubDeportivoAPI.Mappers;
using ClubDeportivoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ClubDeportivoAPI.Controllers
{
    [Route("api/socio")]
    [ApiController]
    public class SocioController : Controller
    {
        //comento esta linea para refactorizar a repository pattern
        //private readonly ApplicationDbContext _context;
        private readonly ISocioRepository _socioRepository;
                                 //repository pattern
        public SocioController(/*ApplicationDbContext context,*/ ISocioRepository socioRepository)
        {
            //_context = context; repository patter
            _socioRepository = socioRepository;
        }

        [HttpGet]
        [Route("socio/name")]
        public async Task<IActionResult> GetSocioByName([FromQuery] SocioQO socioQuery)
        {
            var socios = await _socioRepository.GetAllSociosByName(socioQuery);
            if (socios == null)
            {
                return NotFound();
            }

            return Ok(socios);
        }

        //Devuelvo el listado de socios
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllSocios() 
        {
            var socios = await _socioRepository.GetAllSociosAsync();

            //comento siguiente linea de codigo para no ver solo los datos del mappeador DTO
            //var socioDto = socios.Select(e => SocioMapper.mapperSocio(e));            

            return Ok(socios);
        }

        //Devuelvo el socio segun su id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSocio([FromRoute] int id) 
        {
            //sin Repository Pattern
            //var socio = await _context.Socios.FindAsync(id);
            var socio = await _socioRepository.GetSocioByIdAsync(id);
            if (socio == null)
            {
                return NotFound();
            }   
            return Ok(SocioMapper.mapperSocio(socio));
        }

        //Creo un socio (cliente) sin inscripciones para luego agregar segun necesidad.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSocioRequestDto socioRequestDto) //se recibe un RequestDto para crear abstraccion en el front en caso de ser necesario.
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var socio = SocioMapper.mapperCreateSocioRequestDto(socioRequestDto);
            var socioCreado = await _socioRepository.CreateSocioAsync(socio);

            if (socioCreado == null)
            {
                return BadRequest();
            }
            return Ok();

            //return CreatedAtAction(nameof(GetSocio), new {id = socio.Id}, SocioMapper.mapperSocio(socio));
        }

        //Actualizo un row completo segun id y body mappeado segun request.
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSocioRequestDto updateDto)
        {
            var socio = await _socioRepository.UpdateSocioByIdAsync(id, updateDto);

            if (socio == null)
            {
                return NotFound();
            }

            return Ok(socio);
        }

        //Delete de socio por id 
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var socio = await _socioRepository.DeletSocioByIdAsync(id);

            if (socio == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
