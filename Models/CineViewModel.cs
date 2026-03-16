using System.Collections.Generic;

namespace CineStarWeb.Models
{
    public class CineViewModel
    {
        public List<Pelicula> PeliculasCartelera { get; set; } = new();
        public List<Pelicula> PeliculasProximas { get; set; } = new();
        public List<Cine> Cines { get; set; } = new();
        public Pelicula? PeliculaDetalle { get; set; }
        public Cine? CineDetalle { get; set; }
        public List<CinePelicula> Horarios { get; set; } = new();
        public List<CineTarifa> Tarifas { get; set; } = new();
    }
}