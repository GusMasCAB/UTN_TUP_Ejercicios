using LigaCordobesaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Servicios
{
    interface IServicioEquipo
    {
        int ProximoIdEquipo();
        List<Persona> TraerPersonas();
    }
}
