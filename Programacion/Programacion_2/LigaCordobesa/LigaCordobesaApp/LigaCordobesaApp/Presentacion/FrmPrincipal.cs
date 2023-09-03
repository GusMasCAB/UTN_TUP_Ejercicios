using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LigaCordobesaApp.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ingresarEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarEquipo frmIngresarEquipo = new FrmIngresarEquipo();
            frmIngresarEquipo.ShowDialog();
        }
    }
}
