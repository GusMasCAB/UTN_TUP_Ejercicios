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
    public class EquipoDao : IEquipoDao
    {
        public int ProximoId()
        {
            return HelperDao.ObtenerInstancia().ProximoId("sp_proximo_id","@next");
        }

        public List<Equipo> ObtenerTodos() {
            throw new NotImplementedException();
        }
        public bool Crear(Equipo entidad)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(Equipo entidad)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(Equipo entidad)
        {
            throw new NotImplementedException();
        }

        public List<Equipo> ObtenerPorFiltros()
        {
            throw new NotImplementedException();
        }

        public List<Equipo> ObtenerPorId()
        {
            throw new NotImplementedException();
        }
    }
}
