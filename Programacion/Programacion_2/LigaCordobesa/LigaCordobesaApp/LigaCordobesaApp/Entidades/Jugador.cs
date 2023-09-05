using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Entidades
{
    public class Jugador
    {
        public Persona persona { get; set; }
        public int Camiseta { get; set; }
        public Posicion posicion { get; set; }

        public Jugador() { }
        public Jugador(Persona persona, int camiseta, Posicion posicion)
        {
            this.persona = persona;
            Camiseta = camiseta;
            this.posicion = posicion;
        }

        public override string ToString()
        {
            return persona.ToString()+$"\nCamiseta: {Camiseta} \n{posicion.ToString()}";
        }
    }
}
