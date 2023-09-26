using Repaso_Parcial.Datos.Interfaz;
using Repaso_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Repaso_Parcial.Datos.Implementacion
{
    public class OrdenRetiroDao : IOrdenRetiroDao
    {
        public List<Material> ObtenerMateriales()
        {
            DataTable tabla = HelperDao.obtenerInstancia().ConsultarBD("sp_consultar_materiales");
            List<Material> lstMateriales = new List<Material>();

            foreach (DataRow fila in tabla.Rows)
            {
                Material m = new Material();
                if (!fila.IsNull(0))
                    m.Codigo = (int)fila[0];
                if (!fila.IsNull(1))
                    m.Nombre = fila[1].ToString();
                if (!fila.IsNull(2))
                    m.Stock = (int)fila[2];
                lstMateriales.Add(m);
            }
            return lstMateriales;
        }
        public int CrearOrden(OrdenRetiro orden)
        {
            SqlConnection conn = HelperDao.obtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            int idOrden=0;
            try
            {
                conn.Open();
                t = conn.BeginTransaction();
                SqlCommand cmdMaestro = new SqlCommand("sp_insertar_ordenesPedidos", conn);
                cmdMaestro.Transaction = t;
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.Add(new SqlParameter("@fecha",orden.Fecha));
                cmdMaestro.Parameters.Add(new SqlParameter("@responsable", orden.Responsable));

                SqlParameter param = new SqlParameter("@idOrden",SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);

                cmdMaestro.ExecuteNonQuery();
                idOrden = (int)param.Value;

                SqlCommand cmdDetalle;
                foreach (DetalleOrden detalle in orden.lstDetallesOrden)
                {
                    cmdDetalle = new SqlCommand("sp_insertar_detalles",conn);
                    cmdDetalle.Transaction = t;
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.Add(new SqlParameter("idOrden",idOrden));
                    cmdDetalle.Parameters.Add(new SqlParameter("idMaterial",detalle.material.Codigo));
                    cmdDetalle.Parameters.Add(new SqlParameter("cantidad",detalle.Cantidad));

                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch
            {
                if(t!=null)
                    t.Rollback();
            }
            finally 
            { 
                if (conn != null && conn.State==ConnectionState.Open)
                    conn.Close();
            }
            return idOrden;
        }
    }
}
