using LigaCordobesaApp.Entidades;
using LigaCordobesaApp.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LigaCordobesaApp
{
    public partial class FrmIngresarEquipo : Form
    {
        Equipo equipo;
        private PersonaServicio personaServicio;
        private PosicionServicio posicionServicio;
        private EquipoServicio equipoServicio;
        public FrmIngresarEquipo()
        {
            InitializeComponent();
            equipo = new Equipo();
            personaServicio = new PersonaServicio();
            posicionServicio = new PosicionServicio();
            equipoServicio = new EquipoServicio();
        }

        private void FrmIngresarEquipo_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos(cboPersonas, personaServicio);
                CargarCombos(cboPosiciones, posicionServicio);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ocurrió un error de SQL:\n\n{ex.Message}" + "\n\nPor favor, inténtelo de nuevo más tarde",
                        "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error:\n\n{ex.Message}" + "\n\nPor favor, inténtelo de nuevo más tarde",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos(ComboBox cbo,IServicio servicio)
        {
            DataTable tabla = new DataTable();
            tabla = servicio.ConsultarBD();

            cbo.DataSource = tabla;
            cbo.ValueMember = tabla.Columns[0].ColumnName;
            cbo.DisplayMember = tabla.Columns[1].ColumnName;
        }
        #region Eventos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidacionDetalles();
                
                DataRowView aux1 = (DataRowView)cboPersonas.SelectedItem;
                int idPersona = Convert.ToInt32(aux1.Row.ItemArray[0]);
                string nombreCompleto = aux1.Row.ItemArray[1].ToString();
                string dni = aux1.Row.ItemArray[2].ToString();
                DateTime fechaNac = (DateTime)aux1.Row.ItemArray[3];
                
                DataRowView aux2 = (DataRowView)cboPosiciones.SelectedItem;
                int idPosicion = Convert.ToInt32(aux2.Row.ItemArray[0]);
                string pos = aux2.Row.ItemArray[1].ToString();

                Persona persona = new Persona(idPersona,nombreCompleto,dni,fechaNac);
                Posicion posicion = new Posicion(idPosicion,pos);

                Jugador jugador = new Jugador(persona,int.Parse(txtCamiseta.Text),posicion);

                equipo.AgregarJugador(jugador);

                dgvJugadores.Rows.Add(new object[] {jugador.persona.Id,jugador.persona.NombreCompleto, 
                                                    jugador.Camiseta,jugador.posicion.Descripcion,"Quitar"});

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidacionEquipo(txtNombreEquipo, "nombre de Equipo");
                ValidacionEquipo(txtTecnico, "director técnico");
                equipo.Tecnico = txtTecnico.Text;
                equipo.Nombre = txtNombreEquipo.Text;
                equipoServicio.Grabar(equipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvJugadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJugadores.CurrentCell.ColumnIndex==4)
            {
                equipo.QuitarJugador(dgvJugadores.CurrentRow.Index);
                dgvJugadores.Rows.RemoveAt(dgvJugadores.CurrentRow.Index);
            }
        }
        #endregion

        #region Validacion de datos
        private void ValidacionDetalles()
        {

            ValidacionCombos(cboPersonas,"un jugador");
            ValidacionCombos(cboPosiciones,"una posición");

            if (string.IsNullOrEmpty(txtCamiseta.Text) || !int.TryParse(txtCamiseta.Text,out _))
                throw new Exception("Debe ingresar un número de camiseta valido");

            foreach (DataGridViewRow fila in dgvJugadores.Rows)
            {
                if (Convert.ToInt32(fila.Cells["ColId"].Value) == Convert.ToInt32(cboPersonas.SelectedValue))
                    throw new Exception("Debe seleccionar otro Jugador");
            }
        }
        private void ValidacionCombos(ComboBox cbo,string aux)
        {
            if (cbo.SelectedIndex == -1)
                throw new Exception($"Debe seleccionar {aux}");
        }

        private void ValidacionEquipo(TextBox txt,string aux)
        {
            if (string.IsNullOrEmpty(txt.Text))
                throw new Exception($"Debe ingresar un {aux} valido");
        }
        #endregion
    }
}
