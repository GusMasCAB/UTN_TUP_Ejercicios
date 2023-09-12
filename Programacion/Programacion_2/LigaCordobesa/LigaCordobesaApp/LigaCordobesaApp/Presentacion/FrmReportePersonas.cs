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
    public partial class FrmReportePersonas : Form
    {
        public FrmReportePersonas()
        {
            InitializeComponent();
        }

        private void FrmReportePersonas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSPersonas.DTPersonas' Puede moverla o quitarla según sea necesario.
            this.dTPersonasTableAdapter.Fill(this.dSPersonas.DTPersonas);

            this.reportViewer1.RefreshReport();
        }
    }
}
