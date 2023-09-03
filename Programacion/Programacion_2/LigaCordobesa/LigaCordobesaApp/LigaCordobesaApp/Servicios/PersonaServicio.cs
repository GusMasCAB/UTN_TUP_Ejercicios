using LigaCordobesaApp.Datos;
using LigaCordobesaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LigaCordobesaApp.Servicios
{
    internal class PersonaServicio : IServicio
    {
        private AccesoDatos oBD;
        public PersonaServicio() { 
            oBD = new AccesoDatos();
        }

        public DataTable ConsultarBD()
        {
            return oBD.ConsultarBD("sp_consultar_personas");
        }
    }
}
