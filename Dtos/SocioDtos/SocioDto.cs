using System.ComponentModel.DataAnnotations;

namespace ClubDeportivoAPI.Dtos.SocioDtos
{
    public class SocioDto
    {
        [Required]
        [MaxLength(255, ErrorMessage = "El nombre no debe ser mayor a 255 char.")]
        [MinLength(5, ErrorMessage = "El nombre no debe ser menor a 5 caracteres.")]

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        //public int IdInscripcion { get; set; }
    }
}
