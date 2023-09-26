using Repaso_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Parcial.Servicios.Interfaz
{
    interface IServicio
    {
        List<Material> TraerMateriales();
        int CrearOrdenRetiro(OrdenRetiro orden);
    }
}
