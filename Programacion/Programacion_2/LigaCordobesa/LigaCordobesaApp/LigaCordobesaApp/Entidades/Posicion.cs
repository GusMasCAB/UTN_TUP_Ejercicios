using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Entidades
{
    internal class Posicion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Posicion() { }
        public Posicion(int id, string posicion) {
            Id = id;
            Descripcion = posicion;
        }

        public override string ToString()
        {
            return $"Posición: {Descripcion}"; 
        }
    }
}
