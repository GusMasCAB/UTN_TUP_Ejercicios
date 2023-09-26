using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilasColas_U2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
/*Problema 2.1:
Pilas. Escribe una interfaz, llamada IColleccion que declare los siguientes 
métodos:
estaVacia(): devuelve true si la colección está vacía y false en caso contrario.
extraer(): devuelve y elimina el primer elemento de la colección.
primero(): devuelve el primer elemento de la colección.
añadir(): añade un objeto por el extremo que corresponda, y devuelve true si 
se ha añadido y false en caso contrario.
A continuación, escribe una clase Pila, que implemente esta interfaz, 
utilizando para ello un array de Object y un contador de objetos.
Problema 2.2:
Colas. Desarrollar una clase Cola que implemente la interfaz definida en el 
problema anterior pero esta vez utilizando un objeto List. Tener en cuenta que una 
Cola es una estructura FIFO (Primero en entrar primero en salir).
*/