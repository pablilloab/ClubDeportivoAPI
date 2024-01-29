using System.ComponentModel.DataAnnotations.Schema;

namespace ClubDeportivoAPI.Models
{
    public class Apto
    {
        public int Id { get; set; }
        public int? IdSocio { get; set; }
        public string HistoriaMedica { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Alto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Peso { get; set; }
    }
}
