using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubDeportivoAPI.Models
{
    public class Cuota
    {
        [Key,Column(Order = 0)]
        public int Id { get; set; }
        [Key,Column(Order = 1)]
        public DateTime FechaPago { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        
        public string MedioDePago { get; set; } = string.Empty;
        public bool PagoRealizado { get; set; } = false;
    }
}
