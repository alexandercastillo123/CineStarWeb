using CineStarWeb.Controllers.bd;
using CineStarWeb.Models;
using System.Collections.Generic;

namespace CineStarWeb.Controllers.dao
{
    public class daoCine
    {
        bd.clsBD clsBD = new bd.clsBD("CineStar");
        
        internal Cine? getCine(int idCine)
        {
            clsBD.Sentencia("sp_getCine");
            clsBD.Parametro("@id", idCine);
            Cine? cine = new Cine().getRegistro(clsBD.getDataTable());

            if (cine != null)
            {
                clsBD.Sentencia("sp_getCineTarifas");
                clsBD.Parametro("@idCine", idCine);
                cine.Tarifas = new CineTarifa().getList(clsBD.getDataTable());

                clsBD.Sentencia("sp_getCinePeliculas");
                clsBD.Parametro("@idCine", idCine);
                cine.Horarios = new CinePelicula().getList(clsBD.getDataTable());
            }

            return cine;
        }

        internal List<Cine> getVerCines()
        {
            clsBD.Sentencia("sp_getCines");
            return new Cine().getList(clsBD.getDataTable());
        }
    }
}
