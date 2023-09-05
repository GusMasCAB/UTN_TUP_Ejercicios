using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNac { get; set; }

        public Persona() { }

        public Persona(int id, string nombreCompleto, string dni, DateTime fechaNac) { 
            Id = id;
            NombreCompleto = nombreCompleto;
            DNI = dni;
            FechaNac = fechaNac;
        }

        public override string ToString()
        {
            return $"Nombre Completo: {NombreCompleto} \nDNI: {DNI} \nFecha Nacimiento: {FechaNac}";
        }
    }
}
