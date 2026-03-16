namespace CineStarWeb.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string FechaEstreno { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Generos { get; set; } = string.Empty;
        public string GenerosTexto { get; set; } = string.Empty;
        public int IdClasificacion { get; set; }
        public int IdEstado { get; set; }
        public string Duracion { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Reparto { get; set; } = string.Empty;
        public string Sinopsis { get; set; } = string.Empty;
    }
}