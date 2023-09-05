﻿using LigaCordobesaApp.Datos;
using LigaCordobesaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Servicios
{
    public class EquipoServicio
    {
        private AccesoDatos oBD;
        public EquipoServicio(){
            oBD = new AccesoDatos();
        }

        public void Grabar(Equipo equipo)
        {
            oBD.GrabarBD(equipo,"sp_insertar_equipos");
        }
    }
}