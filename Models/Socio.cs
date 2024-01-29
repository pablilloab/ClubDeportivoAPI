namespace ClubDeportivoAPI.Models
{
    public class Socio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public int IdInscripcion { get; set; }
        //public List<Inscripcion> Inscripciones { get; set; }
    }
}
