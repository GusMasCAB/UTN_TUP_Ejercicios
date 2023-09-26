using LigaCordobesaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Datos.Interfaz
{
    interface IPersonaDao
    {
        int ProximoId();
        bool Crear(Persona persona);
        bool Actualizar(Persona persona);
        bool Borrar(Persona persona);
        List<Persona> ObtenerTodos();
        List<Persona> ObtenerPorFiltros();
        List<Persona> ObtenerPorId();
    }
}
