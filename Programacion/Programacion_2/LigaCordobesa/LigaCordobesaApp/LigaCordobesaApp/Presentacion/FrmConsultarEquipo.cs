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
    public partial class FrmConsultarEquipo : Form
    {
        DBHelper gestor;
        public FrmConsultarEquipo()
        {
            InitializeComponent();
            gestor = new DBHelper();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Parametro> lst = new List<Parametro>();
                lst.Add(new Parametro("@nombre", Convert.ToInt32(txtNombre.Text)));
                lst.Add(new Parametro("@tecnico", txtTecnico.Text));

                DataTable tabla = new DataTable();
                tabla = gestor.ConsultarConParametros("sp_consultar_equipos",lst);


                foreach (DataRow fila in tabla.Rows)
                {
                    dgvEquipos.Rows.Add(new object[] { fila[0], fila[1], fila[2] });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEquipos.CurrentCell.ColumnIndex == 3)
            {
                int nro = Convert.ToInt32(dgvEquipos.CurrentRow.Cells["ColId"].Value);
                string nombre = dgvEquipos.CurrentRow.Cells["ColNombre"].ToString();

                FrmJugadores detalle = new FrmJugadores(nro,nombre); //llamada con constructor con parámetro.   
                detalle.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
