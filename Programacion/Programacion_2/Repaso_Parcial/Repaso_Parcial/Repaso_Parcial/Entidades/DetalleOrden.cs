using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Parcial.Entidades
{
    public class DetalleOrden
    {
        public Material material { get; set; }
        public int Cantidad { get; set; }
        public DetalleOrden(Material material, int cant)
        {
            this.material = material;
            Cantidad = cant;
        }

    }
}
