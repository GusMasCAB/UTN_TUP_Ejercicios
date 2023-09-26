using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilasColas_U2.Implementaciones
{
    internal class Cola
    {
        private List<object> colas;
        public Cola()
        {
            colas = new List<object>();
        }

        //estaVacia() : devuelve true si la colección está vacía y false en caso contrario
        public bool EstaVacia()
        {
            return colas.Any();
        }

        //extraer(): devuelve y elimina el primer elemento de la lista.
        public object Extraer()
        {
            object elemento = Primero();
            colas.Remove(elemento);
            return elemento;
        }

        //primero() : devuelve el primer elemento de la lista.
        public object Primero()
        {
            if (EstaVacia())
                throw new Exception("La lista que representa la cola esta vacia");
            return colas.FirstOrDefault();
        }
        //añadir(): añade un objeto por el extremo que corresponda, y devuelve true si
        //se ha añadido y false en caso contrario.
        public bool Añadir(object elemento)
        {
            colas.Add(elemento);
            return true;
        }
    }
}
