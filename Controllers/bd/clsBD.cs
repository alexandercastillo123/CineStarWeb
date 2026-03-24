using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace CineStarWeb.Controllers.bd
{
    public class clsBD
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;

        public clsBD(string BD)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            cn = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        internal void Sentencia(string v)
        {
            cmd = new SqlCommand(v, cn);
            cmd.CommandType = CommandType.StoredProcedure;
        }

        internal void Parametro(string nombre, object valor)
        {
            cmd.Parameters.AddWithValue(nombre, valor);
        }

        internal DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {
            }
            return dt;
        }
    }
}
