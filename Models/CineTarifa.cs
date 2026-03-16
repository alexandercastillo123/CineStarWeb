namespace CineStarWeb.Models
{
    public class CineTarifa
    {
        public int IdCine { get; set; }
        public string DiasSemana { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}