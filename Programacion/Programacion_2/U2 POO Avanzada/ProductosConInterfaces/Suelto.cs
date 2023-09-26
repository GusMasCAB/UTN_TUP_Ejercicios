using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosConInterfaces
{
    public class Suelto: Producto
    {
        public int Medida { get; set; }

        public Suelto(int cod, string nom, double pre, int medida) :base(cod,nom,pre)
        {
            Medida = medida;
        }

        public override double CalcularPrecio()
        {
            return Medida * Precio;
        }

        public override string ToString()
        {
            return $"Suelto: {base.ToString()}";
        }
    }
}
