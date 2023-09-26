using Repaso_Parcial.Datos.Interfaz;
using Repaso_Parcial.Entidades;
using Repaso_Parcial.Servicios.Implementaciones;
using Repaso_Parcial.Servicios.Interfaz;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso_Parcial
{
    public partial class FrmOrdenRetiro : Form
    {
        IServicio servicio;
        OrdenRetiro nuevoPedido=null;
        public FrmOrdenRetiro()
        {
            InitializeComponent();
            servicio = new Servicio();
            nuevoPedido = new OrdenRetiro();
        }

        private void FrmOrdenRetiro_Load(object sender, EventArgs e)
        {
            CargarMateriales();
            dtpFecha.Value = DateTime.Today;
            cboMateriales.SelectedIndex = 0;
        }

        private void CargarMateriales()
        {
            cboMateriales.DataSource = servicio.TraerMateriales();
            cboMateriales.ValueMember = "Codigo";
            cboMateriales.DisplayMember = "Nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidacionParaDetalles();

                Material oMaterial = (Material)cboMateriales.SelectedItem;
                int cant = (int)nudCantidad.Value;

                //if (cant > oMaterial.Stock)
                //    throw new Exception($"No hay stock suficiente para {oMaterial.Nombre}");

                DetalleOrden detalle = new DetalleOrden(oMaterial,cant);
                nuevoPedido.AgregarDetalle(detalle);

                dgvDetalleOrden.Rows.Add(new object[] {oMaterial.Codigo,oMaterial.Nombre,oMaterial.Stock,cant});

            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Error: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidacionParaOrden();
                nuevoPedido.Fecha = dtpFecha.Value;
                nuevoPedido.Responsable = txtResponsable.Text;
                int idPedido = servicio.CrearOrdenRetiro(nuevoPedido);

                if (idPedido!=0)
                {
                    MessageBox.Show($"Se registro con exito el Orden pedido N° {idPedido}", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarPantalla();
                }
                else {
                    throw new Exception("Ocurrio un error al ingresar una nueva orden de pedido");
                }
            }
            catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDetalleOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleOrden.CurrentCell.ColumnIndex == 4) {
                nuevoPedido.QuitarDetalle(dgvDetalleOrden.CurrentRow.Index);
                dgvDetalleOrden.Rows.RemoveAt(dgvDetalleOrden.CurrentRow.Index);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //VALIDACIONES
        private void ValidacionParaDetalles()
        {
            if (cboMateriales.SelectedIndex == -1)
                throw new Exception("No hay seleccionado ningún material");
            if (nudCantidad.Value <= 0)
                throw new Exception("Debe Ingresar una cantidad valida");
            foreach (DataGridViewRow fila in dgvDetalleOrden.Rows)
            {
                if (Convert.ToInt32(fila.Cells[0].Value) == Convert.ToInt32(cboMateriales.SelectedValue))
                    throw new Exception("Material ya seleccionado. Debe seleccionar otro");
            }
        }

        private void ValidacionParaOrden()
        {
            if (string.IsNullOrEmpty(txtResponsable.Text))
                throw new Exception("Debe ingresar un Responsable de la orden de pedido");
            
            foreach (DataGridViewRow fila in dgvDetalleOrden.Rows)
            {
                if (Convert.ToInt32(fila.Cells["ColCantidad"].Value) > Convert.ToInt32(fila.Cells["ColStock"].Value))
                    throw new Exception($"No hay stock suficiente para el material {fila.Cells["ColNombre"].Value}");
            }

            if (dgvDetalleOrden.Rows.Count == 0)
                throw new Exception("Debe seleccionar al menos un material para crear un nuevo pedido");
        }

        private void LimpiarPantalla()
        {
            dtpFecha.Value = DateTime.Today;
            txtResponsable.Text = string.Empty;
            cboMateriales.SelectedIndex = 0;
            nudCantidad.Value = 1;
            dgvDetalleOrden.Rows.Clear();
        }
        
    }
}
