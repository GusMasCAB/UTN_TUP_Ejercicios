using Repaso_Parcial.Datos.Implementacion;
using Repaso_Parcial.Datos.Interfaz;
using Repaso_Parcial.Entidades;
using Repaso_Parcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Parcial.Servicios.Implementaciones
{
    public class Servicio : IServicio
    {
        private IOrdenRetiroDao dao;

        public Servicio() {
            dao = new OrdenRetiroDao();
        }
        public List<Material> TraerMateriales()
        {
            return dao.ObtenerMateriales();
        }
        public int CrearOrdenRetiro(OrdenRetiro orden)
        {
            return dao.CrearOrden(orden);
        }
    }
}
