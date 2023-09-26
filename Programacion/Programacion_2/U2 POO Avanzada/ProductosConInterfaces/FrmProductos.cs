using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosConInterfaces
{
    public partial class FrmProductos : Form
    {
        enum TipoProducto
        {
            Suelto,
            Pack
        }
        List<IProducto> lProductos;
        TipoProducto miTipo;
        public FrmProductos()
        {
            InitializeComponent();
            lProductos = new List<IProducto>();
            miTipo = TipoProducto.Suelto;
        }

        private void rbtSuelto_CheckedChanged(object sender, EventArgs e)
        {
            lblMedidaCantidad.Text = "Medida";
            miTipo = TipoProducto.Suelto;
        }

        private void rbtPack_CheckedChanged(object sender, EventArgs e)
        {
            lblMedidaCantidad.Text = "Cantidad";
            miTipo = TipoProducto.Pack;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Validar datos de entrada!!!

            int cod = int.Parse(txtCodigo.Text);
            string nom = txtNombre.Text;
            double pre = double.Parse(txtPrecio.Text);
            int x = int.Parse(txtMedidaCantidad.Text);

            //if (rbtSuelto.Checked)
            if(miTipo==TipoProducto.Suelto){
                Suelto s = new Suelto(cod, nom, pre, x);
                lProductos.Add(s);
            }
            else
            {
                Pack p = new Pack(cod, nom, pre, x);
                lProductos.Add(p);
            }
            lstProductos.Items.Clear();
            lstProductos.Items.AddRange(lProductos.ToArray());
       }

        private void btnMostrarTotal_Click(object sender, EventArgs e)
        {
            double total = 0;

            foreach (IProducto p in lProductos)
            {
                total += p.CalcularPrecio();
            }
            txtTotal.Text = total.ToString();
        }
    }
}
