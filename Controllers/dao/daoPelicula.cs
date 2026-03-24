using CineStarWeb.Controllers.bd;
using CineStarWeb.Models;
using System.Collections.Generic;

namespace CineStarWeb.Controllers.dao
{
    public class daoPelicula
    {
        bd.clsBD clsBD = new bd.clsBD("CineStar");

        internal List<Pelicula> getPeliculas(int id)
        {
            clsBD.Sentencia("sp_getPeliculas");
            clsBD.Parametro("@idEstado", id);
            return new Pelicula().getList(clsBD.getDataTable());
        }

        internal Pelicula? getPelicula(int id)
        {
            clsBD.Sentencia("sp_getPelicula");
            clsBD.Parametro("@id", id);
            return new Pelicula().getRegistro(clsBD.getDataTable());
        }
    }
}
