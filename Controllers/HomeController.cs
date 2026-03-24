using Microsoft.AspNetCore.Mvc;
using CineStarWeb.Models;
using System.Data;

namespace CineStarWeb.Controllers
{
    public class HomeController : Controller
    {
        dao.daoCine daoCine = new dao.daoCine();
        dao.daoPelicula daoPelicula = new dao.daoPelicula();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult verCines()
        {
            return View(daoCine.getVerCines());
        }
        public IActionResult verCine(int id)
        {
            return View(daoCine.getCine(id));
        }
        public IActionResult verPeliculas(int id)
        {
            return View(daoPelicula.getPeliculas(id));
        }
        public IActionResult verPelicula(int id)
        {
            return View(daoPelicula.getPelicula(id));
        }
    }
}