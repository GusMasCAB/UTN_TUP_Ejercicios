using LigaCordobesaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Datos.Interfaz
{
    interface IPosicionDao
    {
        Posicion ObtenerPosicion();
        List<Posicion> ObtenerPosiciones();
    }
}
