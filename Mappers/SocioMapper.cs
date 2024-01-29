using ClubDeportivoAPI.Dtos.SocioDtos;
using ClubDeportivoAPI.Models;

namespace ClubDeportivoAPI.Mappers
{
    public static class SocioMapper
    {
        public static SocioDto mapperSocio(Socio socio)
        {
            return new SocioDto
            {
                Nombre = socio.Nombre,
                Apellido = socio.Apellido,
                Telefono = socio.Telefono
                //IdInscripcion = socio.IdInscripcion
            };
        }

        public static Socio mapperCreateSocioRequestDto(CreateSocioRequestDto socio)
        {
            return new Socio
            {
                Nombre = socio.Nombre,
                Apellido = socio.Apellido,
                Dni = socio.Dni,
                Telefono = socio.Telefono,
                Email = socio.Email
               // IdInscripcion = socio.IdInscripcion //el Id de inscripcion de mantiene en 0 hasta que el socio no decida pagar cuota mensual.
            };
        }

        public static Socio mapperUpdateSocioRequestDto(CreateSocioRequestDto socio)
        {
            return new Socio
            {
                Nombre = socio.Nombre,
                Apellido = socio.Apellido,
                Dni = socio.Dni,
                Telefono = socio.Telefono,
                Email = socio.Email
                //IdInscripcion = socio.IdInscripcion //el Id de inscripcion de mantiene en 0 hasta que el socio no decida pagar cuota mensual.
            };
        }
    }
}
