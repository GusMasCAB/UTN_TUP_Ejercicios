using LigaCordobesaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Datos.Interfaz
{
    interface IEquipoDao
    {
        int ProximoId();
        bool Crear(Equipo equipo);
        bool Actualizar(Equipo equipo);
        bool Borrar(Equipo equipo);
        List<Equipo> ObtenerTodos();
        List<Equipo> ObtenerPorFiltros();
        List<Equipo> ObtenerPorId();
    }
}
