using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormPersonas
{
    public partial class FrmJuego : Form
    {
        public FrmJuego()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            if (String.IsNullOrEmpty(nombre) == false)
            //if (!String.IsNullOrEmpty(txtNombre.Text))
            {
                Munieco oMunieco = new Munieco(nombre);
                lstMuñecos.Items.Add(oMunieco);
                txtNombre.Text = String.Empty; //Esto deja la caja en blanco nuevamente para una próx entrada
                txtNombre.Focus(); //Esto deja el curso sobre el componente
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre para el muñeco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmJuego_Load(object sender, EventArgs e)
        {
           // lstMuñecos.Items.Clear(); esto es un obviedad porque cuando se carga a memoria ya esta vacío

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea cerrar la ventana", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Munieco.Contador() < 1)
            {
                MessageBox.Show("Debe haber ingresado un muñeco para poder borrar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Munieco.Contador() >= 1)
            {
                if (lstMuñecos.SelectedIndex != -1)
                {
                    lstMuñecos.Items.RemoveAt(lstMuñecos.SelectedIndex);
                    Munieco.Disminuir();
                }
                else
                {
                    MessageBox.Show("Debe haber seleccionado un muñeco para poder borrar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (Munieco.Contador() < 1)
            {
                MessageBox.Show("Debe haber ingresado un muñeco para poder jugar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Munieco.Contador() >= 1)
            {
                Munieco auxMunieco = GetItemText(lstMuñecos.SelectedIndex);
                if (auxMunieco != null) {
                    int segundosJugar = 0;
                    string stringJugar = Interaction.InputBox("Ingrese la cantidad de segundos para jugar:", "Jugar", "2", -1, -1);
                    int.TryParse(stringJugar, out segundosJugar);
                    if (auxMunieco.Energia < segundosJugar)
                    {
                        MessageBox.Show("La cantidad de segundos es mayor a la energia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        auxMunieco.Jugar(segundosJugar);
                        lstMuñecos.Items[lstMuñecos.SelectedIndex] = auxMunieco;
                    }
                }
            }
        }

        private Munieco GetItemText(int i)
        {
            Munieco auxMunieco = null;
            if (lstMuñecos.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar un muñeco!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                auxMunieco = lstMuñecos.Items[i] as Munieco;
            }
            return auxMunieco;
        }

        private void btnComer_Click(object sender, EventArgs e)
        {
            if (Munieco.Contador() < 1)
            {
                MessageBox.Show("Debe haber ingresado un muñeco para poder jugar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Munieco.Contador() >= 1)
            {
                Munieco auxMunieco = GetItemText(lstMuñecos.SelectedIndex);
                if (auxMunieco != null)
                {
                    auxMunieco.Comer();
                    lstMuñecos.Items[lstMuñecos.SelectedIndex] = auxMunieco;
                }
            }
        }
    }
}
