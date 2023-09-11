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
    public partial class FrmJugadores : Form
    {
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }

        private DBHelper gestor;
        public FrmJugadores(int idEquipo,string nombre)
        {
            InitializeComponent();
            IdEquipo = idEquipo;
            Nombre = nombre;
            gestor = new DBHelper();
        }

        private void FrmJugadores_Load(object sender, EventArgs e)
        {
            this.Text = Nombre;
            grpEquipo.Text = Nombre;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Parametro> lstParametros = new List<Parametro>();
            lstParametros.Add(new Parametro("@id_equipo",IdEquipo));
            lstParametros.Add(new Parametro("@nombreCompleto",txtNombreCompleto.Text));
            if (!string.IsNullOrEmpty(txtDesde.Text) || int.TryParse(txtDesde.Text, out _))
                lstParametros.Add(new Parametro("@edad_desde", Convert.ToInt32(txtDesde.Text)));
            if (!string.IsNullOrEmpty(txtHasta.Text) || int.TryParse(txtHasta.Text, out _))
                lstParametros.Add(new Parametro("@edad_hasta", Convert.ToInt32(txtHasta.Text)));
            if (!string.IsNullOrEmpty(txtEdad.Text) || int.TryParse(txtEdad.Text, out _))
                lstParametros.Add(new Parametro("@edad", Convert.ToInt32(txtEdad.Text)));

            DataTable tabla = new DataTable();
            tabla = gestor.ConsultarConParametros("sp_consultar_jugadores",lstParametros);
            dgvJugadores.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                dgvJugadores.Rows.Add(new object[] { fila[0], fila[1], fila[2], fila[3] });
            }
        }
    }
}
