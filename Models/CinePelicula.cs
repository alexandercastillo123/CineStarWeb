namespace CineStarWeb.Models
{
    public class CinePelicula
    {
        public int IdCine { get; set; }
        public int IdPelicula { get; set; }
        public int Sala { get; set; }
        public string Horarios { get; set; } = string.Empty;
        public string TituloPelicula { get; set; } = string.Empty;
    }
}