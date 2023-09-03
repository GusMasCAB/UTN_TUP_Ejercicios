using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace LigaCordobesaApp.Datos
{
    internal class AccesoDatos
    {
        private string cadenaConexion = @"Data Source=.\sqlexpress;Initial Catalog=Liga_Cordobesa;Integrated Security=True";
        private SqlConnection conn;
        private SqlCommand cmd;

        public AccesoDatos() { 
            conn = new SqlConnection(cadenaConexion);
        }

        private void ConectarBD() {
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public void DesconectarBD() {
            conn.Close();
        }

        public DataTable ConsultarBD(string sql) {

            DataTable tabla = new DataTable();
            ConectarBD();
            cmd.CommandText = sql;
            tabla.Load(cmd.ExecuteReader());
            DesconectarBD();

            return tabla;
        }

    }
}
