using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso_Parcial.Presentacion.Reportes
{
    public partial class FrmReporteMateriales : Form
    {
        public FrmReporteMateriales()
        {
            InitializeComponent();
        }

        private void FrmReporteMateriales_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSMateriales.materiales' Puede moverla o quitarla según sea necesario.
            this.materialesTableAdapter.Fill(this.dSMateriales.materiales);

            this.reportViewer1.RefreshReport();
        }
    }
}
