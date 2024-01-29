using System.ComponentModel.DataAnnotations.Schema;

namespace ClubDeportivoAPI.Models
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Horario { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }
        //public List<Inscripcion> Inscripciones { get; set; }
    }
}
