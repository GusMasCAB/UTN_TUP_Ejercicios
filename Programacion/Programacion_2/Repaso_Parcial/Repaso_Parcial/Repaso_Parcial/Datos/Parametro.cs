using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Parcial.Datos
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametro(string nom,object valor)
        {
            Nombre = nom;
            Valor = valor;
        }

    }
}
