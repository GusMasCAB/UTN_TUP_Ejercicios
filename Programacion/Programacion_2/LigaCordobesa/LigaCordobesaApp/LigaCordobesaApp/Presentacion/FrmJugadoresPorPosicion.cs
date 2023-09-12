using LigaCordobesaApp.Datos;
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
    public partial class FrmJugadoresPorPosicion : Form
    {
        DBHelper gestor;
        public FrmJugadoresPorPosicion()
        {
            InitializeComponent();
            gestor = new DBHelper();
        }

        private void FrmJugadoresPorPosicion_Load(object sender, EventArgs e)
        {
            //validacion de datos

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            List<Parametro> lstParametros = new List<Parametro>
            {
                new Parametro("@edad_desde", Convert.ToInt32(txtEdadDesde.Text)),
                new Parametro("@edad_hasta", Convert.ToInt32(txtEdadHasta.Text))
            };
            tabla = gestor.ConsultarConParametros("sp_cantidad_por_posicion", lstParametros);

            this.dTPosicionesBindingSource.DataSource = tabla;
            this.reportViewer1.RefreshReport();
        }
    }
}
