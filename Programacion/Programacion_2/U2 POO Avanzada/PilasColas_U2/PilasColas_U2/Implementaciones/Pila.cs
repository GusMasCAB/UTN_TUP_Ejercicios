using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PilasColas_U2.Implementaciones
{
    /*A continuación, escribe una clase Pila, que implemente esta interfaz,
    utilizando para ello un array de Object y un contador de objetos.*/
    internal class Pila : ICollection
    {
        private object[] pilas;
        private int contador;
        public Pila(int tamanio) {
            pilas = new object[tamanio];
            contador = 0;
        }

        //estaVacia() : devuelve true si la colección está vacía y false en caso contrario
        public bool EstaVacia()
        {
            return contador==0;
        }

        //extraer(): devuelve y elimina el ultimo elemento del arreglo.
        public object Extraer()
        {
            pilas[contador] = null;
            return Primero();
        }

        //primero() : devuelve el ultimo elemento del arreglo.
        public object Primero()
        {
            if (EstaVacia())
                throw new Exception("El arreglo que representa la pila esta vacio");
            return pilas.LastOrDefault();
        }
        //añadir(): añade un objeto por el extremo que corresponda, y devuelve true si
        //se ha añadido y false en caso contrario.
        public bool Añadir(object elemento)
        {
            if (contador > pilas.Length)
            {
                return false;
            }
            else
            {
                pilas[contador] = elemento;
                contador++;
                return true;
            }
        }
    }
}
