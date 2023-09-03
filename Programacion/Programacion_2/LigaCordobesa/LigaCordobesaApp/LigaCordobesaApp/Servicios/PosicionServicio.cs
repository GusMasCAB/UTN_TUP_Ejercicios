using LigaCordobesaApp.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Servicios
{
    internal class PosicionServicio : IServicio
    {
        private AccesoDatos oBD;
        public PosicionServicio() { 
           oBD = new AccesoDatos();
        }

        public DataTable ConsultarBD()
        {
            return oBD.ConsultarBD("sp_consultar_posiciones");
        }
    }
}
