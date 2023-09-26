using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Repaso_Parcial.Datos
{
    public class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection conn;
        private HelperDao()
        {
               conn = new SqlConnection(Properties.Resources.CadenaConexion);
        }
        public static HelperDao obtenerInstancia() { 
            if(instancia==null)
                instancia = new HelperDao();
            return instancia;
        }

        public DataTable ConsultarBD(string sql) {
            SqlCommand cmd = Conectar();
            cmd.CommandText = sql;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            conn.Close();

            return tabla;
        }
        private SqlCommand Conectar() { 
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }
        public SqlConnection ObtenerConexion() {
            return this.conn;
        }
    }
}
