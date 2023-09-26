using Repaso_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Parcial.Datos.Interfaz
{
    interface IOrdenRetiroDao
    {
        List<Material> ObtenerMateriales();
        int CrearOrden(OrdenRetiro orden);
    }
}
