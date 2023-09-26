using Repaso_Parcial.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso_Parcial.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void nuevoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new FrmOrdenRetiro().ShowDialog();
        }

        private void materialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReporteMateriales().ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicacion?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.OK) {
                this.Dispose();
            }
        }
    }
}
