using System;
using System.Collections.Generic;
using System.Data;

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

        public List<CineTarifa> Tarifas { get; set; } = new List<CineTarifa>();
        public List<CinePelicula> Horarios { get; set; } = new List<CinePelicula>();

        public List<Cine> getList(DataTable dt)
        {
            List<Cine> cines = new List<Cine>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cines.Add(new Cine
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        RazonSocial = dr["RazonSocial"].ToString() ?? "",
                        Salas = Convert.ToInt32(dr["Salas"]),
                        IdDistrito = Convert.ToInt32(dr["idDistrito"]),
                        DistritoNombre = dr["Detalle"].ToString() ?? "",
                        Direccion = dr["Direccion"].ToString() ?? "",
                        Telefonos = dr["Telefonos"].ToString() ?? ""
                    });
                }
            }
            return cines;
        }

        public Cine? getRegistro(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Cine
                {
                    Id = Convert.ToInt32(dr["id"]),
                    RazonSocial = dr["RazonSocial"].ToString() ?? "",
                    Salas = Convert.ToInt32(dr["Salas"]),
                    IdDistrito = Convert.ToInt32(dr["idDistrito"]),
                    DistritoNombre = dr["Detalle"].ToString() ?? "",
                    Direccion = dr["Direccion"].ToString() ?? "",
                    Telefonos = dr["Telefonos"].ToString() ?? ""
                };
            }
            return null;
        }
    }

    public class CineTarifa
    {
        public int IdCine { get; set; }
        public string DiasSemana { get; set; } = string.Empty;
        public string Precio { get; set; } = string.Empty;

        public List<CineTarifa> getList(DataTable dt)
        {
            List<CineTarifa> tarifas = new List<CineTarifa>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    tarifas.Add(new CineTarifa
                    {
                        DiasSemana = dr["DiasSemana"].ToString() ?? "",
                        Precio = dr["Precio"].ToString() ?? ""
                    });
                }
            }
            return tarifas;
        }
    }

    public class CinePelicula
    {
        public int IdCine { get; set; }
        public int IdPelicula { get; set; }
        public int Sala { get; set; }
        public string Horarios { get; set; } = string.Empty;
        public string TituloPelicula { get; set; } = string.Empty;

        public List<CinePelicula> getList(DataTable dt)
        {
            List<CinePelicula> peliculas = new List<CinePelicula>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    peliculas.Add(new CinePelicula
                    {
                        TituloPelicula = dr["Titulo"].ToString() ?? "",
                        Horarios = dr["Horarios"].ToString() ?? ""
                    });
                }
            }
            return peliculas;
        }
    }
}