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
    ///segunda parte del ejercicio
    public partial class frmPersona : Form
    {
        bool nuevo = false;  // bandera para evitar errores por PK. (true)estamos ingresando datos de una nueva persona
                                                                  //(false)estamos editando los datos existentes de una persona
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;  /// el Data Reader no posee constructor
        /// SqlConnection nos permite establecer la conexion con el proveedor    
        /// SqlCommand nos permite ejecutar un comando Select, Insert, Update, Delete <summary>
        /// DataReader y DataTable que son componentes que van a servir para alojar datos
      
        public frmPersona()  // Constructor de frmPersona
        {
            InitializeComponent();
        }
        //Evento load tiene lugar cuando se carga el formulario
        //Es el evento por defecto del formulario
        ///para conectarnos a la base de datos comenzamos en el load para tener los combo y listas cargados
        private void frmPersona_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            /// ConnectionString es una propiedad de tipo string que obtiene o establece la cadena de conexion para conectarnos a una base de datos
            /// @ ----> Interpreta que lo que va despues es cadena de texto. Esto evita errores con caracteres especiales ejemplo \
            conexion.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=TUPPI;Integrated Security=True";
            conexion.Open(); /// abrimos la conexion
            /// Le decimos a traves de que conexion va a ejecutar los comandos 
            comando.Connection = conexion;
            /// Le indicamos el tipo de comando. En este caso es un comando de tipo texto de SQL. Tamnien hay de tipo procedimiento almacenado
            comando.CommandType = CommandType.Text;
            ///le pasamos la instruccion de TRANSACT-SQL
            comando.CommandText = "SELECT * FROM tipo_documento";
            /// Al resultado de la consulta decidimos si ponerlo en un DataReader o un DataTable. 
            /// Para los ComboBox es más practico ponerlo en un DataTable
            
            DataTable tabla = new DataTable();
            ///Método Load() de la clase DataTable que rellena la instancia(tabla) de la clase DataTable con el DataReader pasado como parametro
            ///Metodo ExecuteReader() de la clase Comando. Ejecuta el comado y devuelve un objeto tipo DataReader, es decir las tablas resultado de la consulta
            tabla.Load(comando.ExecuteReader()); ///Todos los Select lo ejecutamos con ExecuteReader()

            conexion.Close(); /// cerramos la conexión

            ///Una vez desconectados le pasamos al ComboBox el DataTable
            /// DataSource propiedad que establece la fuente de datos del control
            cboTipoDocumento.DataSource = tabla;
            ///DisplayMember indicamos lo que se quiere ver en el Combo
            cboTipoDocumento.DisplayMember = "n_tipo_documento";
            /// ValueMember indicamos el valor que va a tomar. Acordarse ValueMember != IndexMember
            cboTipoDocumento.ValueMember = "id_tipo_documento";

            conexion.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=TUPPI;Integrated Security=True";
            conexion.Open(); 
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM estado_civil";
 
            DataTable tabla1 = new DataTable();
            tabla1.Load(comando.ExecuteReader()); 
            conexion.Close(); 

            cboEstadoCivil.DataSource = tabla1;
            cboEstadoCivil.DisplayMember = "n_estado_civil";
            cboEstadoCivil.ValueMember = "id_estado_civil";
            cboEstadoCivil.SelectedIndex = 0;
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
            if (nuevo) //(nuevo == true) es equivalente
            {
                //VALIDAR QUE NO EXISTA LA PK !!!(SI NO ES AUTOINCREMENTAL / IDENTITY)
                /// Creamos una Persona y le seteamos las propiedades
                Persona p = new Persona();
                p.Apellido = txtApellido.Text;
                p.Nombres = txtNombres.Text;
                p.Documento = Convert.ToInt32(txtDocumento.Text);
                /// tomamos el Value de los ComboBox, no el indice
                p.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                p.EstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                p.Fallecio = chkFallecio.Checked;
                if (rbtFemenino.Checked)
                    p.Sexo = 1;               
                else 
                    p.Sexo = 2;
                p.FechaNacimiento = dtpFechaNacimiento.Value;
                // Insert con sentencia SQL Tradicional
                string sqlInsert = "INSERT INTO personas VALUES('" + p.Apellido + "','"
                                                                   + p.Nombres + "',"
                                                                   + p.TipoDocumento +","
                                                                   + p.Documento + ","
                                                                   + p.EstadoCivil + ","
                                                                   + p.Sexo + ",'"
                                                                   + p.Fallecio +"','"
                                                                   + p.FechaNacimiento +"')";

                conexion.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=TUPPI;Integrated Security=True";
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sqlInsert;
                comando.ExecuteNonQuery();  /// Esto es para los Insert, Delete, Update no devueve tablas. Devuelve el numero de filas afectadas
                                            /// Lo único que cambiaria serian las sentencias el CommandText
                conexion.Close();

                // Inster utilizando parametros (clase Parameters)
            }
            else { 
                // Update
            } 
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
