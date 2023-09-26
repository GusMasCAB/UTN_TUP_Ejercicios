using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Parcial.Entidades
{
    public class Material
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }

        public Material(int codigo, string nom, int stock)
        {
            Codigo = codigo;
            Nombre = nom;
            Stock = stock;
        }

        public Material() { }
    }
}
