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
using System.Collections;

namespace ABMPersonas
{
    public partial class frmPersona : Form
    {
        bool nuevo = false;  // bandera para evitar errores por PK. (true)estamos ingresando datos de una nueva persona
                             //(false)estamos editando los datos existentes de una persona
        List<Persona> personas;
        // Utilizamos el constructor de la clase SqlConnection para pasarle la cadena de conexion
        SqlConnection conexion = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=TUPPI;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;  // el Data Reader no posee constructor
        // SqlConnection nos permite establecer la conexion con el proveedor    
        // SqlCommand nos permite ejecutar un comando Select, Insert, Update, Delete
        // DataReader y DataTable que son componentes que van a servir para alojar datos
      
        public frmPersona()  // Constructor de frmPersona
        {
            InitializeComponent();
            personas = new List<Persona>();
        }

        #region Evento Load, cargar combos y listas
        //Evento load tiene lugar cuando se carga el formulario
        //Es el evento por defecto del formulario
        //para conectarnos a la base de datos comenzamos en el load para tener los combo y listas cargados
        private void frmPersona_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            CargarCombo("tipo_documento", cboTipoDocumento); // (nombre de la tabla, ComboBox)
            CargarCombo("estado_civil", cboEstadoCivil) ;// Se hacen los Select para cargar los ComboBox
            CargarLista("personas",lstPersonas); //(ListBox, nombre de la tabla)
            txtApellido.MaxLength = 30;  // Decimos que el maximo de caracteres permitidos es 30

        }

        private void CargarCombo(string tabla, ComboBox cbo)
        {
            conexion.Open(); //Establece la conexion logica al motor de base de datos
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text; // por defecto el CommandType es text no hace falta esta linea de codigo
            comando.CommandText = "SELECT * FROM " + tabla;
            //DataReader representacion a bajo nivel de una tabla en memoria. Es de solo lectura y hacia adelante. Recorre como un cursor (flecha)
            //DataTable representacion de alto nivel de una tabla en memoria. Seria mejor para los combos que son tablas pequeñas
            DataTable dataTable = new DataTable();
            dataTable.Load(comando.ExecuteReader());  //query es lo mismo que Select
            conexion.Close();

            cbo.DataSource = dataTable; // asociamos la fuente de datos antes de los siguientes
            cbo.DisplayMember = dataTable.Columns[1].ColumnName; // dato a mostrar. "id_tipo_documento" 
            cbo.ValueMember = dataTable.Columns[0].ColumnName;   // dato a guardar. "n_tipo_documento"
        }

        // Metodo que recibe como parametro un ListBox y un nombre de la tabla. Este metodo carga la lista(ListBox) de personas
        private void CargarLista(string tabla, ListBox lst)
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM " + tabla;
            lector = comando.ExecuteReader(); //DataReader: se trabaja con conexion abierta a la base de datos. El DataReader es solo de lectura y de forma secuencial.
                                              // Ventajas del DataReader: es mas rapido, mas ligero. Tambien se utiliza en este caso porque vamos llenar un arreglo
                                              // y seria innecesario tener llenado un arreglo y una tabla al mismo tiempo. 
            lst.Items.Clear();
            personas.Clear();
            while (lector.Read()) // Read() metodo booleano si no hay mas filas para rrecorer devuelve false
            {
                Persona p = new Persona();
                // los metodos get del DataReader lector devuelve el valor de la columna especificada.
                // Hay que validar los datos debido a que la base de datos puede tener valores NULL y los metodos no convierten 
                //NULL a otros tipos de datos
                if (!lector.IsDBNull(0)) //metodo IsDbNull(int columna) indica si la columna pasada como parametro es nula o no
                    p.Apellido = lector.GetString(0); //lector.GetString(int columna) primera columna es 0;
                if (!lector.IsDBNull(1))
                    p.Nombres = Convert.ToString(lector["nombres"]);  //lector["nombre"] le pasamos el nombre de la columna con corchetes
                if (!lector.IsDBNull(2))
                    p.TipoDocumento = lector.GetInt32(2);
                if (!lector.IsDBNull(3))
                    p.Documento = lector.GetInt32(3);
                if (!lector.IsDBNull(4))
                    p.EstadoCivil = Convert.ToInt32(lector["estado_civil"]);
                if (!lector.IsDBNull(5))
                    p.Sexo = lector.GetInt32(5);
                if (!lector.IsDBNull(6))
                    p.Fallecio = lector.GetBoolean(6);
                if (!lector.IsDBNull(7))
                    p.FechaNacimiento = lector.GetDateTime(7);
                personas.Add(p); 
                //lst.Items.Add(p); //Se guarda en el componente como Object y muestra el ToSring
            }
            lst.Items.AddRange(personas.ToArray());
            conexion.Close() ; // se cierra la conexion sola porq tambien se cierra el lector
            lst.SelectedIndex = 0;
        }
        #endregion

        #region Metodos Habilitar(bool x) y Limpiar()
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
        #endregion

        #region Eventos de los bottones Nuevo, Editar, Borrar, Cancelar, Salir
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
            if (MessageBox.Show("¿Esta seguro de eliminar? " , "BORRAR",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // Delete --------> puede ser un update de un campo lógico que diga si esta eliminado o no
                // ejecutar un metodo de Delete
                CargarLista("personas", lstPersonas);
            }
        }
        // Cancelar ya sea para nuevo o edicion 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar(false);
            nuevo = false;
            CargarLista("personas", lstPersonas);
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
        #endregion

        #region Boton Grabar
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /// Creamos una Persona y le seteamos las propiedades
            Persona p = new Persona();
            string query;

            if (nuevo) //(nuevo == true) es equivalente
            {
                //VALIDAR QUE NO EXISTA LA PK !!!(SI NO ES AUTOINCREMENTAL / IDENTITY)
                cargarPersona(p);
                // Insert con sentencia SQL Tradicional
                query = "INSERT INTO personas VALUES('" + p.Apellido + "','"
                                                        + p.Nombres + "',"
                                                        + p.TipoDocumento + ","
                                                        + p.Documento + ","
                                                        + p.EstadoCivil + ","
                                                        + p.Sexo + ",'"
                                                        + p.Fallecio + "','"
                                                        + p.FechaNacimiento + "')";

                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = query;
                comando.ExecuteNonQuery();  /// Esto es para los Insert, Delete, Update no devueve tablas. Devuelve el numero de filas afectadas
                                            /// Lo unico que cambiaria serian las sentencias el CommandText
                conexion.Close();

                // Inster utilizando parametros (clase Parameters)
                //string insert = "INSERT INTO personas VALUES (@apellido,@nombre,@tipoDocumento," +
                //                                    "@documento, @estadoCivil, @sexo," +
                //                                    "@fallecio, @fechaNacimiento)";
                //SentenciasDML(insert, p);
                                                    
            }
            else
            {
                cargarPersona(p);
                // Update utilizando parametros (clase Parameters)
                query = "UPDATE personas SET apellido = @apellido, nombres = @nombre, tipo_documento = @tipoDocumento,"+ 
                                             "documento = @documento, estado_civil = @estadoCivil, sexo = @sexo," + 
                                             "fallecio = @fallecio, fecha_nacimiento = @fechaNacimiento " + 
                                             "WHERE documento = " + p.Documento ;
                SentenciasDML(query,p);   
            }
            Habilitar(false);
            nuevo = false;
            CargarLista("personas", lstPersonas);
        }

        private void cargarPersona(Persona p)
        {
            p.Apellido = txtApellido.Text;
            p.Nombres = txtNombres.Text;
            p.Documento = Convert.ToInt32(txtDocumento.Text); // para Editar no tenemos problema con el documento porque esta desactivado
            /// tomamos el Value de los ComboBox, no el indice
            p.TipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
            p.EstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue);
            p.Fallecio = chkFallecio.Checked;
            if (rbtFemenino.Checked)
                p.Sexo = 1;
            else
                p.Sexo = 2;
            p.FechaNacimiento = dtpFechaNacimiento.Value;
        }

        private void SentenciasDML(string query, Persona oPersona) {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = query;

            comando.Parameters.AddWithValue("@apellido", oPersona.Apellido);
            comando.Parameters.AddWithValue("@nombre", oPersona.Nombres);
            comando.Parameters.AddWithValue("@tipoDocumento", oPersona.TipoDocumento);
            comando.Parameters.AddWithValue("@documento", oPersona.Documento);
            comando.Parameters.AddWithValue("@estadoCivil", oPersona.EstadoCivil);
            comando.Parameters.AddWithValue("@sexo", oPersona.Sexo);
            comando.Parameters.AddWithValue("@fallecio", oPersona.Fallecio);
            comando.Parameters.AddWithValue("@fechaNacimiento", oPersona.FechaNacimiento);

            comando.ExecuteNonQuery();
            conexion.Close();
        }
        #endregion

        #region Mostrar los datos de la Persona seleccionada en la ListBox
        // Evento que tiene lugar cuando se cambia el indice del elemento seleccionada en la LisBox
        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPersonas.SelectedIndex != -1)
            {
                Persona persona = (Persona)lstPersonas.SelectedItem;
                CargarCampos(persona);// Le pasamos como argumento el indice de la persona seleccionada
            }
         }

        // Metodo que me carga los componentes del form segun la persona seleccionada de la ListBox
        private void CargarCampos(Persona p)
        {
            // cargar campos desde el arreglo
            txtApellido.Text = p.Apellido;
            txtNombres.Text = p.Nombres;
            cboTipoDocumento.SelectedValue = p.TipoDocumento;
            txtDocumento.Text = p.Documento.ToString();
            cboEstadoCivil.SelectedValue = p.EstadoCivil;
            dtpFechaNacimiento.Value = p.FechaNacimiento;
            if (p.Sexo == 1)
                rbtFemenino.Checked = true;
            else
                rbtMasculino.Checked = true;
            chkFallecio.Checked = p.Fallecio;
        }
        #endregion
        
        //Dato para evitar SQL injection siempre hacer las query que van contra la base de datos
        //sean con parametros
    }
}
