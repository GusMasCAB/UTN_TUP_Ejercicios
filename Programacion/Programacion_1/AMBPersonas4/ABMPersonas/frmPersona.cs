using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ABMPersonas
{
    public partial class frmPersona : Form
    {
        bool esNuevo = false;
        List<Persona> lst;
        string cnnString = @"Data Source =.\SQLEXPRESS; Initial Catalog = TUPPI; Integrated Security = True";

        public frmPersona()
        {
            InitializeComponent();
            lst = new List<Persona>();

        }

        private void frmPersona_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            CargarCombo("tipo_documento", cboTipoDocumento);
            CargarCombo("estado_civil", cboEstadoCivil);
            CargarLista("personas", lstPersonas);
            // txtApellido.MaxLength = 30; Validar largo de los campos según definición de tabla

        }

        private void CargarLista(string tabla, ListBox lstBox)
        {
            //string cnnString = @"Data Source =.\SQLEXPRESS; Initial Catalog = TUPPI; Integrated Security = True";
            //SqlConnection cnn = new SqlConnection(cnnString);
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = cnnString;
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM " + tabla;
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            lst.Clear();
            while (reader.Read())
            {
                string nom = reader["nombres"].ToString();
                string ape = reader["apellido"].ToString();
                int tipodoc = Convert.ToInt32(reader["tipo_documento"].ToString());
                int doc = Convert.ToInt32(reader["documento"].ToString());
                int sexo = Convert.ToInt32(reader["sexo"].ToString());
                int estadoCivil = Convert.ToInt32(reader["estado_civil"].ToString());
                bool esFallecio = bool.Parse(reader["fallecio"].ToString());
                DateTime fec = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());

                Persona oPersona = new Persona(ape, nom, tipodoc, doc, estadoCivil, sexo, esFallecio, fec);
                lst.Add(oPersona);

            }
            lstBox.Items.Clear();
            lstBox.Items.AddRange(lst.ToArray());
            //Deja el primer item como seleccionado
            if (lstBox.Items.Count > 0)
                lstBox.SelectedIndex = 0;
            cnn.Close();
        }

        private void CargarCombo(string tabla, ComboBox cbo)
        {
            //SqlConnection cnn = new SqlConnection(cnnString);
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = cnnString;
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM " + tabla;
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            cbo.DataSource = dt;
            cbo.DisplayMember = dt.Columns[1].ColumnName;
            cbo.ValueMember = dt.Columns[0].ColumnName;
            cnn.Close();
        }


        private void Habilitar(bool x)
        {
            txtApellido.Enabled = x;
            txtNombres.Enabled = x;
            cboTipoDocumento.Enabled = x;
            txtDocumento.Enabled = x;
            cboEstadoCivil.Enabled = x;
            dtpFechaNacimiento.Enabled = x;
            rbtFemenino.Enabled = x;
            rbtMasculino.Enabled = x;
            chkFallecio.Enabled = x;
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnSalir.Enabled = !x;
            lstPersonas.Enabled = !x;
        }

        private void limpiar()
        {
            txtApellido.Text = "";
            txtNombres.Text = "";
            cboTipoDocumento.SelectedIndex = -1;
            txtDocumento.Text = "";
            cboEstadoCivil.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Today;
            rbtFemenino.Checked = false;
            rbtMasculino.Checked = false;
            chkFallecio.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Habilitar(true);
            limpiar();
            txtApellido.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedIndex != -1)
            {
                Habilitar(true);
                txtDocumento.Enabled = false;// deshabilita el documento porque es PK en la tabla
                txtApellido.Focus();
                esNuevo = false;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedIndex != -1)
            {
                string mensaje = "Seguro que desea eliminar la persona: " + lstPersonas.Text + "?";
                if (MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection cnn = new SqlConnection(cnnString);
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Personas Where documento = @documento", cnn);
                    Persona oPersona = lst.ElementAt(lstPersonas.SelectedIndex);

                    //Cargamos los parámetros del commnad con los datos del objeto persona:
                    cmd.Parameters.AddWithValue("@documento", oPersona.Documento);

                    int afectadas = cmd.ExecuteNonQuery();
                    if (afectadas == 1)
                        MessageBox.Show("Se eliminó con éxito!", "Confirmación");
                    else
                        MessageBox.Show("NO se puedo eliminar la persona seleccionada!", "Error");

                    cnn.Close();

                    CargarLista("personas", lstPersonas);
                    limpiar();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            Habilitar(false);
            esNuevo = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            Persona oPersona = null;
            string query = null;

            if (esNuevo)
            {
                oPersona = new Persona();
                // VALIDAR QUE NO EXISTA LA PK !!!!!! (SI NO ES AUTOINCREMENTAL / IDENTITY)
                if (Existe(oPersona))
                {
                    MessageBox.Show("La persona ya se encuentra registrada para el DNI ingresado!", "Validaciones");
                    return;
                }
                // insert usando parámetros
                query = "INSERT INTO Personas VALUES(@apellido, @nombres , @tipoDocumento, @documento, @estadoCivil, @sexo, @fallecio, @fechaNacimiento )";
            }
            else
            {
                //Objeto persona actualizado
                //Persona oPersona = (Persona)lstPersonas.SelectedItem;
                //????
                oPersona = lst.ElementAt(lstPersonas.SelectedIndex);
                loadDataPersona(oPersona);

                //query = "UPDATE Personas SET apellido = '" + oPersona.Apellido + "'," +
                //    "nombres='" + oPersona.Nombres + "', " +
                //    "tipo_documento = " + oPersona.TipoDocumento + "," +
                //    "estado_civil = " + oPersona.EstadoCivil + ", " +
                //    "sexo = " + oPersona.Sexo + ", " +
                //    "fallecio = '" + oPersona.Fallecio + "', " +
                //    "fecha_nacimiento = '" + oPersona.FechaNacimiento.ToString() + "'" +
                //    " WHERE documento = " + oPersona.Documento;


                query = "UPDATE Personas SET apellido = @apellido," +
                    "nombres = @nombres, " +
                    "tipo_documento = @tipoDocumento, " +
                    "estado_civil = @estadoCivil, " +
                    "sexo = @sexo, " +
                    "fallecio = @fallecio, " +
                    "fecha_nacimiento = @fechaNacimiento " +
                    " WHERE documento = @documento";

            }
            //Cargamos el objeto persona con los datos ingresados
            loadDataPersona(oPersona);

            //Común de SQL:
            SqlConnection cnn = new SqlConnection(cnnString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand(query, cnn);

            //Cargamos los parámetros del commnad con los datos del objeto persona:
            cmd.Parameters.AddWithValue("@apellido", oPersona.Apellido);
            cmd.Parameters.AddWithValue("@nombres", oPersona.Nombres);
            cmd.Parameters.AddWithValue("@tipoDocumento", oPersona.TipoDocumento);
            cmd.Parameters.AddWithValue("@estadoCivil", oPersona.EstadoCivil);
            cmd.Parameters.AddWithValue("@documento", oPersona.Documento);
            cmd.Parameters.AddWithValue("@sexo", oPersona.Sexo);
            cmd.Parameters.AddWithValue("@fallecio", oPersona.Fallecio);
            cmd.Parameters.AddWithValue("@fechaNacimiento", oPersona.FechaNacimiento);

            int afectadas = cmd.ExecuteNonQuery();
            if (afectadas == 1)
                MessageBox.Show("Se actualizó con éxito!", "Confirmación");
            else
                MessageBox.Show("NO se actualizó con éxito!", "Error");

            cnn.Close();

            CargarLista("Personas", lstPersonas);

            Habilitar(false);
            esNuevo = false;

        }

        private bool Existe(Persona oPersona)
        {
            bool existe = false;
            foreach (Persona p in lst)
            {
                if (p.Documento == oPersona.Documento)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }

        private void loadDataPersona(Persona oPersona)
        {
            oPersona.Apellido = txtApellido.Text;
            oPersona.Nombres = txtNombres.Text;
            oPersona.Documento = int.Parse(txtDocumento.Text);
            oPersona.EstadoCivil = int.Parse(cboEstadoCivil.SelectedValue.ToString());
            oPersona.TipoDocumento = (int)(cboTipoDocumento.SelectedValue);
            oPersona.Fallecio = chkFallecio.Checked;
            oPersona.FechaNacimiento = dtpFechaNacimiento.Value;
            if (rbtFemenino.Checked)
                oPersona.Sexo = 1;
            else
                oPersona.Sexo = 2;

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
                "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }

        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedIndex != -1) // hay un ítem seleccionado
            {
                Persona oPersona = (Persona)lstPersonas.SelectedItem;
                txtApellido.Text = oPersona.Apellido;
                txtNombres.Text = oPersona.Nombres;
                txtDocumento.Text = oPersona.Documento.ToString();
                cboEstadoCivil.SelectedValue = oPersona.EstadoCivil;
                cboTipoDocumento.SelectedValue = oPersona.TipoDocumento;
                if (oPersona.Sexo == 1)
                    rbtFemenino.Checked = true;
                else
                    rbtMasculino.Checked = true;

                //rbtFemenino.Checked = oPersona.Sexo == 1;
                //rbtMasculino.Checked = oPersona.Sexo == 2;
                chkFallecio.Checked = oPersona.Fallecio;
                dtpFechaNacimiento.Value = oPersona.FechaNacimiento;
            }
        }
    }
}
