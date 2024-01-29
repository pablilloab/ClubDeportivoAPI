namespace ClubDeportivoAPI.Helpers
{
    //Object query para buscar socios por nombre o apellido.
    public class SocioQO
    {
        public string? Nombre { get; set; } = string.Empty;
        public string? Apellido { get; set; } = string.Empty;
        public string? ColumnaOrdenar {  get; set; } = string.Empty;
        public bool Descending { get; set; } = false;
        public int NumeroDePagina { get; set; } = 1;
        public int TamanoDePagina { get; set; } = 20;
    }
}
