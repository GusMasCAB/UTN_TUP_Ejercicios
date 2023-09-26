using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_Parcial.Entidades
{
    public class OrdenRetiro
    {
        public int NroOrden { get; set; }
        public DateTime Fecha { get; set; }
        public string Responsable { get; set; }
        public List<DetalleOrden> lstDetallesOrden { get; set; }

        public OrdenRetiro(int nroOrden,DateTime fecha,string responsable)
        {
            NroOrden = nroOrden;
            Fecha = fecha;
            Responsable = responsable;
            lstDetallesOrden = new List<DetalleOrden>();
        }
        public OrdenRetiro() {
            lstDetallesOrden = new List<DetalleOrden>();
        }
        public void AgregarDetalle(DetalleOrden detalle) {
            lstDetallesOrden.Add(detalle);
        }
        public void QuitarDetalle(int indice)
        {
            lstDetallesOrden.RemoveAt(indice);
        }
    }
}
