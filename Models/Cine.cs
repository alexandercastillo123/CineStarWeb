namespace CineStarWeb.Models
{
    public class Cine
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public int Salas { get; set; }
        public int IdDistrito { get; set; }
        public string DistritoNombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefonos { get; set; } = string.Empty;
    }
}