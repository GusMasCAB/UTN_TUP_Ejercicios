using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Entidades
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tecnico { get; set; }
        public List<Jugador> Jugadores { get; set; }

        public Equipo() { 
            Jugadores = new List<Jugador>();
        }
        public Equipo(int id, string nombre, string tecnico)
        {
            Id = id;
            Nombre = nombre;
            Tecnico = tecnico;
            Jugadores = new List<Jugador>();
        }

        public void AgregarJugador(Jugador jugador) { 
            Jugadores.Add(jugador);
        }

        public void QuitarJugador(int indice) { 
            Jugadores.RemoveAt(indice);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
