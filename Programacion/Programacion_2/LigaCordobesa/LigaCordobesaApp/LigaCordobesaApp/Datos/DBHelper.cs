using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using LigaCordobesaApp.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LigaCordobesaApp.Datos
{
    public class DBHelper
    {
        private string cadenaConexion = @"Data Source=.\sqlexpress;Initial Catalog=Liga_Cordobesa;Integrated Security=True";
        private SqlConnection conn = null;

        public DBHelper() { 
            conn = new SqlConnection(cadenaConexion);
        }

        private SqlCommand ConectarBD() {
            if (conn == null || conn.State == ConnectionState.Closed)
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

        public DataTable ConsultarConParametros(string sql, List<Parametro> lst)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = ConectarBD();
            cmd.CommandText = sql;
            foreach (Parametro aux in lst)
            {
                cmd.Parameters.AddWithValue(aux.Nombre,aux.Valor);
            }
            tabla.Load(cmd.ExecuteReader());
            DesconectarBD();
            return tabla;
        }

        public bool GrabarEquipo(Equipo equipo)
        {
            bool resultado = true;
            SqlTransaction t = null;
            try
            {
                SqlCommand cmdEquipo = ConectarBD();
                cmdEquipo.CommandText = "sp_ingresar_equipos";
                t = conn.BeginTransaction();
                cmdEquipo.Transaction = t;
                cmdEquipo.Parameters.AddWithValue("@nombre", equipo.Nombre);
                cmdEquipo.Parameters.AddWithValue("@tecnico", equipo.Tecnico);
                SqlParameter sqlParameter = new SqlParameter("@newId", SqlDbType.Int);
                sqlParameter.Direction = ParameterDirection.Output;
                cmdEquipo.Parameters.Add(sqlParameter);
                cmdEquipo.ExecuteNonQuery();

                int idEquipo = (int)sqlParameter.Value;

                SqlCommand cmdJugador;
                foreach (Jugador jugador in equipo.Jugadores)
                {
                    cmdJugador = ConectarBD();
                    cmdJugador.CommandText = "sp_ingresar_jugadores";
                    cmdJugador.Transaction = t;
                    cmdJugador.Parameters.AddWithValue("@idEquipo", idEquipo);
                    cmdJugador.Parameters.AddWithValue("@idPersona", jugador.persona.Id);
                    cmdJugador.Parameters.AddWithValue("@idPosicion", jugador.posicion.Id);
                    cmdJugador.Parameters.AddWithValue("@Camiseta", jugador.Camiseta);

                    cmdJugador.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception)
            {
                 if(t != null)
                    t.Rollback();
                resultado = false;
            }
            finally { 
                if(conn != null && ConnectionState.Open==conn.State)
                    DesconectarBD();
            }
            return resultado;
        }

        internal int NuevoEquipo(string sql)
        {
            SqlCommand cmd = ConectarBD();
            cmd.CommandText = sql;
            
            SqlParameter sqlParameter = new SqlParameter("@next",SqlDbType.Int);
            sqlParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqlParameter);
            cmd.ExecuteNonQuery();
            DesconectarBD();

            return (int)sqlParameter.Value;
        }
    }
}
