using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LigaCordobesaApp.Datos
{
    public class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection conn;
        private HelperDao() { 
            conn = new SqlConnection(Properties.Resources.CadenaConexion);
        }
        public static HelperDao ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new HelperDao();
            return instancia;
        }
        public int ProximoId(string sql, string paramOut) {
            SqlCommand cmd = Conectar();

            cmd.CommandText = sql;
            SqlParameter param = new SqlParameter(paramOut, SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();

            conn.Close();
            return (int)param.Value;
        }

        public DataTable Consultar(string sql) {
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
    }
}
