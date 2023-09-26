using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosConInterfaces
{
    interface IProducto //las interfaces son publicas por defecto
    {
        //las interfaces solo van a tener metodos
        double CalcularPrecio();
    }
}
