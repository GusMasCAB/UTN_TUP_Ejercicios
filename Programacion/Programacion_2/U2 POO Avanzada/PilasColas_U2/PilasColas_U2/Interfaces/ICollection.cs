using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColas_U2
{
    internal interface ICollection
    {
        bool EstaVacia();
        object Extraer();
        object Primero();
        bool Añadir(object elemento);
    }
}
