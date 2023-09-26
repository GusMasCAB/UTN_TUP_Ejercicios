using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosConInterfaces
{
    internal class Pack : Producto
    {
        public int Cantidad { get; set; }
        public Pack(int cod, string nom, double pre, int cant) : base(cod, nom, pre)
        {
            Cantidad = cant;
        }

        public override double CalcularPrecio()
        {
            return Cantidad * Precio;
        }

        public override string ToString()
        {
            return $"Pack: {base.ToString()}";
        }
    }
}
