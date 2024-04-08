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
    public class PersonaDao : IPersonaDao
    {
        public List<Persona> ObtenerTodos()
        {
            DataTable Tabla = HelperDao.ObtenerInstancia().Consultar("sp_consultar_personas");
            List<Persona> lstPersonas = new List<Persona>();

            foreach (DataRow fila in Tabla.Rows)
            {
                Persona p = new Persona();
                if(!fila.IsNull(0))
                    p.Id = Convert.ToInt32(fila[0]);
                if (!fila.IsNull(1))
                    p.NombreCompleto = fila[1].ToString();
                if (!fila.IsNull(2))
                    p.DNI = fila[2].ToString();
                if (!fila.IsNull(3))
                    p.FechaNac = Convert.ToDateTime(fila[3]);
                lstPersonas.Add(p);
            }
            return lstPersonas;
        }
        public bool Actualizar(Persona entidad)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(Persona entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Persona entidad)
        {
            throw new NotImplementedException();
        }

        public List<Persona> ObtenerPorFiltros()
        {
            throw new NotImplementedException();
        }

        public List<Persona> ObtenerPorId()
        {
            throw new NotImplementedException();
        }

        public int ProximoId()
        {
            throw new NotImplementedException();
        }
    }
}
