using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;              //Clases de ADO.NET
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;    //Proveedor de ADO.NET
using System.Net;

namespace ABMPersonas
{
    //primera parte del ejercicio
    public partial class frmPersona : Form
    {
        bool nuevo = false;  // bandera para evitar errores por PK. (true)estamos ingresando datos de una nueva persona
                                                                  //(false)estamos editando los datos existentes de una persona
        public frmPersona()  // Constructor de frmPersona
        {
            InitializeComponent();
        }
        //Evento load tiene lugar cuando se carga el formulario
        //Es el evento por defecto del formulario
        private void frmPersona_Load(object sender, EventArgs e)
        {
            Habilitar(false);
        }

        //Metodo para habilitar/deshabilitar los controles del formulario
        private void Habilitar(bool x)
        {
            // TextBox: son una clase del name Space System.Windows.Forms
            txtApellido.Enabled = x;   // Enabled es una propiedad de los controles
            txtNombres.Enabled = x;    // de tipo booleano. Establece si el control
            txtDocumento.Enabled = x;  // puede responder a la interaccion del usuario

            // ComboBox:  son una clase del name Space System.Windows.Forms
            cboTipoDocumento.Enabled = x;
            cboEstadoCivil.Enabled = x;

            // RadioButton y CheckBox: son una clase del name Space System.Windows.Forms
            rbtMasculino.Enabled = x;
            rbtFemenino.Enabled = x;
            chkFallecio.Enabled = x;

            // Button: son una clase del name Space System.Windows.Forms
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            
            //Los proximos son diferentes !x debido a que al cargar el frmPersona
            // deben estar habilitados
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnSalir.Enabled = !x;

            // ListBox: son una clase del name Space System.Windows.Forms
            lstPersonas.Enabled = !x;
        }
        // Metodo para limpiar los datos mostrados en los controles
        private void Limpiar() {
            // Text: propiedad de los controles de tipo string que  obtiene o establece el texto del control
            txtApellido.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtDocumento.Text = string.Empty;

            //SelectedIndex: propiedad del ComboBox de tipo int que obtiene o establece el indice del elemento seleccionado
            // le pasamos el -1 para indicar que no hay ningun elemento seleccionado (los comboBox despliegan una lista)
            cboTipoDocumento.SelectedIndex = -1;
            cboEstadoCivil.SelectedIndex = -1;

            //Checked: propiedad de tipo bool (true)indica que la casilla de verificacion esta activada (false)esta desactivado
            rbtMasculino.Checked = false;
            rbtFemenino.Checked = false;
            chkFallecio.Checked = false;
        }

        // Evento que tiene lugar cuando se hace click en el Button Nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true; // Indicamos que ingresamos nuevas Personas
            Habilitar(true); // para habilitar controles necesarios para ingresar datos
            Limpiar();  //para limpiar los controles
            txtApellido.Focus(); //hace que el cursor se pare en el control
        }

        // Evento que tiene lugar cuando se hace click en el Button Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            Habilitar(true); // para habilitar controles necesarios para editar datos
            txtDocumento.Enabled = false; //falso para evitar error de integridad de datos por PK en la base de datos
            txtApellido.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }
        // Cancelar ya sea para nuevo o edicion 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar(false);
            nuevo = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
            nuevo = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea abandonar la aplicación", "SALIR",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();   // cierro el form
            }
        }
    }
}
