using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosConInterfaces
{
    public abstract class Producto: IProducto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(int cod, string nom, double pre)
        {
            Codigo = cod;
            Nombre = nom;
            Precio = pre;
        }
        public abstract double CalcularPrecio();

        //Acordarse esto hereda de object
        public override string ToString()
        {
            return $"Codigo: {Codigo} - Nombre: {Nombre} - Precio: ${CalcularPrecio()}";
        }
    }
}
