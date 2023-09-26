using LigaCordobesaApp.Datos.Implementacion;
using LigaCordobesaApp.Datos.Interfaz;
using LigaCordobesaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Servicios.Implementacion
{
    public class ServicioEquipo : IServicioEquipo
    {
        private IEquipoDao dao;
        public ServicioEquipo() { 
            dao = new EquipoDao();
        }
        public int ProximoIdEquipo()
        {
            return dao.ProximoIdEquipo();
        }

        public List<Persona> TraerPersonas()
        {
            return dao.ObtenerPersonas();
        }
    }
}
