using LigaCordobesaApp.Datos.Interfaz;
using LigaCordobesaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Datos.Implementacion
{
    internal class PosicionDao : IPosicionDao
    {
        public Posicion ObtenerPosicion()
        {
            throw new NotImplementedException();
        }

        public List<Posicion> ObtenerPosiciones()
        {
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("sp_consultar_posiciones");
            List<Posicion> lstPosiciones = new List<Posicion>();

            foreach (DataRow fila in tabla.Rows)
            {
                Posicion p = new Posicion();
                if (!fila.IsNull(0))
                    p.Id = (int)fila[0];
                if(!fila.IsNull(1))
                    p.Descripcion = (string)fila[1];
                lstPosiciones.Add(p);
            }
            return lstPosiciones;
        }
    }
}
