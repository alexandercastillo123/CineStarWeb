using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CineStarWeb.Models;
using System.Data;

namespace CineStarWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _con;

        public HomeController(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("No se encontró cadena de conexión");
        }

        public IActionResult Index() => View(new CineViewModel());

        public IActionResult Peliculas(int id = 1)
        {
            ViewBag.Titulo = (id == 1) ? "Cartelera" : "Próximos Estrenos";

            var model = new CineViewModel();
            using var cn = new SqlConnection(_con);
            cn.Open();

            using (var cmd = new SqlCommand("sp_getPeliculas", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@idEstado", id);
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    model.PeliculasCartelera.Add(new Pelicula
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Titulo = dr["Titulo"].ToString() ?? "",
                        Link = dr["Link"].ToString() ?? "",
                        Sinopsis = dr["Sinopsis"].ToString() ?? ""
                    });
                }
            }
            return View(model);
        }

        public IActionResult Pelicula(int id)
        {
            var model = new CineViewModel();
            model.PeliculaDetalle = new Pelicula();

            using var cn = new SqlConnection(_con);
            cn.Open();

            using (var cmd = new SqlCommand("sp_getPelicula", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@id", id);
                using var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    model.PeliculaDetalle.Id = Convert.ToInt32(dr["Id"]);
                    model.PeliculaDetalle.Titulo = dr["Titulo"].ToString() ?? "";
                    model.PeliculaDetalle.FechaEstreno = dr["FechaEstreno"].ToString() ?? "";
                    model.PeliculaDetalle.Director = dr["Director"].ToString() ?? "";
                    model.PeliculaDetalle.GenerosTexto = dr["Generos"].ToString() ?? "";
                    model.PeliculaDetalle.Duracion = dr["Duracion"].ToString() ?? "";
                    model.PeliculaDetalle.Link = dr["Link"].ToString() ?? "";
                    model.PeliculaDetalle.Reparto = dr["Reparto"].ToString() ?? "";
                    model.PeliculaDetalle.Sinopsis = dr["Sinopsis"].ToString() ?? "";
                }
            }
            return View(model);
        }

        public IActionResult Cines()
        {
            var model = new CineViewModel();
            using var cn = new SqlConnection(_con);
            cn.Open();

            using (var cmd = new SqlCommand("sp_getCines", cn) { CommandType = CommandType.StoredProcedure })
            {
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    model.Cines.Add(new Cine
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        RazonSocial = dr["RazonSocial"].ToString() ?? "",
                        Salas = Convert.ToInt32(dr["Salas"]),
                        DistritoNombre = dr["Detalle"].ToString() ?? "",
                        Direccion = dr["Direccion"].ToString() ?? "",
                        Telefonos = dr["Telefonos"].ToString() ?? ""
                    });
                }
            }
            return View(model);
        }

        public IActionResult Cine(int id)
        {
            var model = new CineViewModel();
            using var cn = new SqlConnection(_con);
            cn.Open();

            using (var cmd = new SqlCommand("sp_getCine", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@id", id);
                using var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    model.CineDetalle = new Cine
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        RazonSocial = dr["RazonSocial"].ToString() ?? "",
                        Salas = Convert.ToInt32(dr["Salas"]),
                        DistritoNombre = dr["Detalle"].ToString() ?? "",
                        Direccion = dr["Direccion"].ToString() ?? "",
                        Telefonos = dr["Telefonos"].ToString() ?? ""
                    };
                }
            }

            using (var cmd = new SqlCommand("sp_getCinePeliculas", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@idCine", id);
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    model.Horarios.Add(new CinePelicula
                    {
                        TituloPelicula = dr["Titulo"].ToString() ?? "",
                        Horarios = dr["Horarios"].ToString() ?? ""
                    });
                }
            }

            using (var cmd = new SqlCommand("sp_getCineTarifas", cn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@idCine", id);
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string precioTexto = dr["Precio"].ToString() ?? "0";
                    precioTexto = precioTexto.Replace("S/.", "").Trim();

                    model.Tarifas.Add(new CineTarifa
                    {
                        DiasSemana = dr["DiasSemana"].ToString() ?? "",
                        Precio = decimal.TryParse(precioTexto, out decimal p) ? p : 0
                    });
                }
            }
            return View(model);
        }
    }
}