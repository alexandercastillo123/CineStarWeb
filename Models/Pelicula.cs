using System;
using System.Collections.Generic;
using System.Data;

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

        public List<Pelicula> getList(DataTable dt)
        {
            List<Pelicula> peliculas = new List<Pelicula>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    peliculas.Add(new Pelicula
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Titulo = dr["Titulo"].ToString() ?? "",
                        Link = dt.Columns.Contains("Link") ? dr["Link"].ToString() ?? "" : "",
                        Sinopsis = dt.Columns.Contains("Sinopsis") ? dr["Sinopsis"].ToString() ?? "" : ""
                    });
                }
            }
            return peliculas;
        }

        public Pelicula? getRegistro(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Pelicula
                {
                    Id = Convert.ToInt32(dr["id"]),
                    Titulo = dr["Titulo"].ToString() ?? "",
                    FechaEstreno = dt.Columns.Contains("FechaEstreno") ? dr["FechaEstreno"].ToString() ?? "" : "",
                    Director = dt.Columns.Contains("Director") ? dr["Director"].ToString() ?? "" : "",
                    Generos = dt.Columns.Contains("Generos") ? dr["Generos"].ToString() ?? "" : "",
                    GenerosTexto = dt.Columns.Contains("Geneross") ? dr["Geneross"].ToString() ?? "" : "",
                    IdClasificacion = dt.Columns.Contains("idClasificacion") && dr["idClasificacion"] != DBNull.Value ? Convert.ToInt32(dr["idClasificacion"]) : 0,
                    IdEstado = dt.Columns.Contains("idEstado") && dr["idEstado"] != DBNull.Value ? Convert.ToInt32(dr["idEstado"]) : 0,
                    Duracion = dt.Columns.Contains("Duracion") ? dr["Duracion"].ToString() ?? "" : "",
                    Link = dt.Columns.Contains("Link") ? dr["Link"].ToString() ?? "" : "",
                    Reparto = dt.Columns.Contains("Reparto") ? dr["Reparto"].ToString() ?? "" : "",
                    Sinopsis = dt.Columns.Contains("Sinopsis") ? dr["Sinopsis"].ToString() ?? "" : ""
                };
            }
            return null;
        }
    }
}