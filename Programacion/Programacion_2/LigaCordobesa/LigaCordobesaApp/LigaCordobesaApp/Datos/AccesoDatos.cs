using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using LigaCordobesaApp.Entidades;

namespace LigaCordobesaApp.Datos
{
    public class AccesoDatos
    {
        private string cadenaConexion = @"Data Source=.\sqlexpress;Initial Catalog=Liga_Cordobesa;Integrated Security=True";
        private SqlConnection conn;

        public AccesoDatos() { 
            conn = new SqlConnection(cadenaConexion);
        }

        private SqlCommand ConectarBD() {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public void DesconectarBD() {
            conn.Close();
        }

        public DataTable ConsultarBD(string sql) {

            DataTable tabla = new DataTable();
            SqlCommand cmd = ConectarBD();
            cmd.CommandText = sql;
            tabla.Load(cmd.ExecuteReader());
            DesconectarBD();

            return tabla;
        }

        public void GrabarBD(Equipo equipo, string sql)
        {
            try
            {
                SqlCommand cmd = ConectarBD();
                SqlTransaction t = conn.BeginTransaction();
                cmd.CommandText = sql;
                cmd.Transaction = t;

                cmd.Parameters.AddWithValue("@nombre",equipo.Nombre);
                cmd.Parameters.AddWithValue("@tecnico", equipo.Tecnico);
                SqlParameter sqlParameter = new SqlParameter("@newId",SqlDbType.Int);
                sqlParameter.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                
                int idEquipo = (int)sqlParameter.Value;
                SqlCommand cmdDetalle;
                foreach (Jugador jugador in equipo.Jugadores)
                {
                    cmdDetalle = new SqlCommand("sp_ingresar_jugadores", conn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@idPersona", jugador.posicion);
                    cmdDetalle.Parameters.AddWithValue("@idPodicion", jugador.posicion);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", jugador.posicion);

                    cmdDetalle.ExecuteNonQuery();
                    detalleNro++;
                }
                t.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
