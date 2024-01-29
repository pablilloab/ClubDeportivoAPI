namespace ClubDeportivoAPI.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int? SocioId { get; set; }
        public Socio? Socio { get; set; }
        public int? ActividadId { get; set; }
        public Actividad? Actividad { get; set; }
        public int? CarnetId { get; set; }
        public Carnet? Carnet { get; set; }
        //public int? IdCuota { get; set; }
        //public Cuota? Cuota { get; set; }
        public List<Cuota> Cuotas { get; set; }

    }
}
