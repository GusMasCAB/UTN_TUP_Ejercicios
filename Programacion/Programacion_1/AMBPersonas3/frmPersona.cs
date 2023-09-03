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
        const int tamanio = 10; // tamaño del arreglo persona
        Persona[] aPersonas = new Persona[tamanio]; // es un arreglo estático de personas 
        int ultimo; // maneja la posicion del arreglo

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
        }

        #region Evento Load, cargar combos y listas
        //Evento load tiene lugar cuando se carga el formulario
        //Es el evento por defecto del formulario
        //para conectarnos a la base de datos comenzamos en el load para tener los combo y listas cargados
        private void frmPersona_Load(object sender, EventArgs e)
        {
            Habilitar(false);
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
            ///Metodo Load() de la clase DataTable que rellena la instancia(tabla) de la clase DataTable con el DataReader pasado como parametro
            ///Metodo ExecuteReader() de la clase Comando. Ejecuta el comado y devuelve un objeto tipo DataReader, es decir las tablas resultado de la consulta
            tabla.Load(comando.ExecuteReader()); ///Todos los Select lo ejecutamos con ExecuteReader()

            conexion.Close(); /// cerramos la conexion

            ///Una vez desconectados le pasamos al ComboBox el DataTable
            /// DataSource propiedad que establece la fuente de datos del control
            cboTipoDocumento.DataSource = tabla;
            ///DisplayMember indicamos lo que se quiere ver en el Combo
            cboTipoDocumento.DisplayMember = "n_tipo_documento";
            /// ValueMember indicamos el valor que va a tomar. Acordarse ValueMember != IndexMember
            cboTipoDocumento.ValueMember = "id_tipo_documento";

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

            CargarLista(lstPersonas,"personas");//(ListBox, nombre de la tabla)
        }

        // Metodo que recibe como parametro un ListBox y un nombre de la tabla. Este metodo carga la lista(ListBox) de personas
        private void CargarLista(ListBox lista, string nombreTabla)
        {
            ultimo = 0;

            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            lector = comando.ExecuteReader(); //DataReader: se trabaja con conexion abierta a la base de datos. El DataReader es solo de lectura y de forma secuencial.
                                              // Ventajas del DataReader: es mas rapido, mas ligero. Tambien se utiliza en este caso porque vamos llenar un arreglo
                                              // y seria innecesario tener llenado un arreglo y una tabla al mismo tiempo. 

            while (lector.Read()) // Read() metodo booleano si no hay mas filas para rrecorer devuelve false
            { 
                Persona p = new Persona();
                // los metodos get del DataReader lector devuelve el valor de la columna especificada.
                // Hay que validar los datos debido a que la base de datos puede tener valores NULL y los metodos no convierten 
                //NULL a otros tipos de datos
                if(!lector.IsDBNull(0)) //metodo IsDbNull(int columna) indica si la columna pasada como parametro es nula o no
                    p.Apellido = lector.GetString(0); //lector.GetString(int columna) primera columna es 0;
                if(!lector.IsDBNull(1))
                    p.Nombres = Convert.ToString(lector["nombres"]);  //lector["nombre"] le pasamos el nombre de la columna con corchetes
                if(!lector.IsDBNull(2))
                    p.TipoDocumento = lector.GetInt32(2);
                if(!lector.IsDBNull(3))
                    p.Documento = lector.GetInt32(3);
                if(!lector.IsDBNull(4))
                    p.EstadoCivil = Convert.ToInt32(lector["estado_civil"]);
                if (!lector.IsDBNull(5))
                    p.Sexo = lector.GetInt32(5);
                if(!lector.IsDBNull(6))
                    p.Fallecio = lector.GetBoolean(6);
                if(!lector.IsDBNull(7))
                    p.FechaNacimiento = lector.GetDateTime(7);
                

                aPersonas[ultimo] = p;
                ultimo++;
                if (ultimo == tamanio)
                {
                    MessageBox.Show("Se completo el arreglo!!");
                    break; // break te sale del bucle
                }
            }
            lector.Close(); // se cierra el DataReader y la conexion
            conexion.Close() ; // se cierra la conexion sola porq tambien se cierra el lector

            // antes de llenar la lista limpiamos la lista
            lista.Items.Clear();
            //LLenamos la ListBox
            for (int i = 0; i < ultimo; i++)
            {
                lista.Items.Add(aPersonas[i].ToString());
                ////La estructura listBox1.Items.Add("Elemento 1") sigue esta convención para acceder
                ////a la colección de elementos y agregar un nuevo elemento a través del método "Add" de esa colección.
            }
            lista.SelectedIndex = 0;
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
                CargarLista(lstPersonas,"personas");
            }
        }
        // Cancelar ya sea para nuevo o edicion 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar(false);
            nuevo = false;
            CargarLista(lstPersonas,"personas");
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

            if (nuevo) //(nuevo == true) es equivalente
            {
                //VALIDAR QUE NO EXISTA LA PK !!!(SI NO ES AUTOINCREMENTAL / IDENTITY)
                // Insert con sentencia SQL Tradicional
                string sqlInsert = "INSERT INTO personas VALUES('" + p.Apellido + "','"
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
                comando.CommandText = sqlInsert;
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
                // Update utilizando parametros (clase Parameters)
                string update = "UPDATE personas SET apellido = @apellido, nombres = @nombre, tipo_documento = @tipoDocumento,"+ 
                                                     "documento = @documento, estado_civil = @estadoCivil, sexo = @sexo," + 
                                                     "fallecio = @fallecio, fecha_nacimiento = @fechaNacimiento " + 
                                                     "WHERE documento = " + p.Documento ;
                SentenciasDML(update,p);
                
            }
            Habilitar(false);
            nuevo = false;
            CargarLista(lstPersonas, "personas");
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
            CargarCampos(lstPersonas.SelectedIndex);// Le pasamos como argumento el indice de la persona seleccionada
        }

        // Metodo que me carga los componentes del form segun la persona seleccionada de la ListBox
        private void CargarCampos(int posicion)
        {
            // cargar campos desde el arreglo
            txtApellido.Text = aPersonas[posicion].Apellido;
            txtNombres.Text = aPersonas[posicion].Nombres;
            cboTipoDocumento.SelectedValue = aPersonas[posicion].TipoDocumento;
            txtDocumento.Text = aPersonas[posicion].Documento.ToString();
            cboEstadoCivil.SelectedValue = aPersonas[posicion].EstadoCivil.ToString();
            dtpFechaNacimiento.Value = aPersonas[posicion].FechaNacimiento;
            if (aPersonas[posicion].Sexo == 1)
            {
                rbtFemenino.Checked = true;
            }
            else {
                rbtMasculino.Checked = true;
            }
            chkFallecio.Checked = aPersonas[posicion].Fallecio;
        }
        #endregion
    }
}
