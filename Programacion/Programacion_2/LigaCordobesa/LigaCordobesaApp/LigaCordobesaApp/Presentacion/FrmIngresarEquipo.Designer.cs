namespace LigaCordobesaApp
{
    partial class FrmIngresarEquipo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvJugadores = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJugador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCamiseta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPosicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cboPersonas = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNombreEquipo = new System.Windows.Forms.TextBox();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.cboPosiciones = new System.Windows.Forms.ComboBox();
            this.txtTecnico = new System.Windows.Forms.TextBox();
            this.lblNombreEquipo = new System.Windows.Forms.Label();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.lblPersonas = new System.Windows.Forms.Label();
            this.lblPosiciones = new System.Windows.Forms.Label();
            this.txtCamiseta = new System.Windows.Forms.TextBox();
            this.lblCamiseta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvJugadores
            // 
            this.dgvJugadores.AllowUserToAddRows = false;
            this.dgvJugadores.AllowUserToDeleteRows = false;
            this.dgvJugadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJugadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColJugador,
            this.ColCamiseta,
            this.ColPosicion,
            this.ColAcciones});
            this.dgvJugadores.Location = new System.Drawing.Point(50, 193);
            this.dgvJugadores.Name = "dgvJugadores";
            this.dgvJugadores.ReadOnly = true;
            this.dgvJugadores.Size = new System.Drawing.Size(549, 178);
            this.dgvJugadores.TabIndex = 0;
            this.dgvJugadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJugadores_CellContentClick);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "ID";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            // 
            // ColJugador
            // 
            this.ColJugador.FillWeight = 150F;
            this.ColJugador.HeaderText = "Jugador";
            this.ColJugador.Name = "ColJugador";
            this.ColJugador.ReadOnly = true;
            // 
            // ColCamiseta
            // 
            this.ColCamiseta.HeaderText = "Camiseta";
            this.ColCamiseta.Name = "ColCamiseta";
            this.ColCamiseta.ReadOnly = true;
            // 
            // ColPosicion
            // 
            this.ColPosicion.HeaderText = "Posicion";
            this.ColPosicion.Name = "ColPosicion";
            this.ColPosicion.ReadOnly = true;
            // 
            // ColAcciones
            // 
            this.ColAcciones.FillWeight = 50F;
            this.ColAcciones.HeaderText = "Acciones";
            this.ColAcciones.Name = "ColAcciones";
            this.ColAcciones.ReadOnly = true;
            // 
            // cboPersonas
            // 
            this.cboPersonas.FormattingEnabled = true;
            this.cboPersonas.Location = new System.Drawing.Point(50, 167);
            this.cboPersonas.Name = "cboPersonas";
            this.cboPersonas.Size = new System.Drawing.Size(162, 21);
            this.cboPersonas.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(203, 393);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(119, 20);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(328, 393);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 20);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(480, 166);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 21);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombreEquipo
            // 
            this.txtNombreEquipo.Location = new System.Drawing.Point(115, 65);
            this.txtNombreEquipo.Name = "txtNombreEquipo";
            this.txtNombreEquipo.Size = new System.Drawing.Size(210, 20);
            this.txtNombreEquipo.TabIndex = 5;
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipo.Location = new System.Drawing.Point(24, 22);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(98, 25);
            this.lblEquipo.TabIndex = 6;
            this.lblEquipo.Text = "Equipo Nr";
            // 
            // cboPosiciones
            // 
            this.cboPosiciones.FormattingEnabled = true;
            this.cboPosiciones.Location = new System.Drawing.Point(216, 167);
            this.cboPosiciones.Name = "cboPosiciones";
            this.cboPosiciones.Size = new System.Drawing.Size(131, 21);
            this.cboPosiciones.TabIndex = 7;
            // 
            // txtTecnico
            // 
            this.txtTecnico.Location = new System.Drawing.Point(115, 107);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.Size = new System.Drawing.Size(210, 20);
            this.txtTecnico.TabIndex = 8;
            // 
            // lblNombreEquipo
            // 
            this.lblNombreEquipo.AutoSize = true;
            this.lblNombreEquipo.Location = new System.Drawing.Point(12, 68);
            this.lblNombreEquipo.Name = "lblNombreEquipo";
            this.lblNombreEquipo.Size = new System.Drawing.Size(97, 13);
            this.lblNombreEquipo.TabIndex = 9;
            this.lblNombreEquipo.Text = "Nombre del Equipo";
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Location = new System.Drawing.Point(15, 110);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(86, 13);
            this.lblTecnico.TabIndex = 10;
            this.lblTecnico.Text = "Director Tecnico";
            // 
            // lblPersonas
            // 
            this.lblPersonas.AutoSize = true;
            this.lblPersonas.Location = new System.Drawing.Point(47, 151);
            this.lblPersonas.Name = "lblPersonas";
            this.lblPersonas.Size = new System.Drawing.Size(104, 13);
            this.lblPersonas.TabIndex = 11;
            this.lblPersonas.Text = "Seleccionar Jugador";
            // 
            // lblPosiciones
            // 
            this.lblPosiciones.AutoSize = true;
            this.lblPosiciones.Location = new System.Drawing.Point(215, 151);
            this.lblPosiciones.Name = "lblPosiciones";
            this.lblPosiciones.Size = new System.Drawing.Size(58, 13);
            this.lblPosiciones.TabIndex = 12;
            this.lblPosiciones.Text = "Posiciones";
            // 
            // txtCamiseta
            // 
            this.txtCamiseta.Location = new System.Drawing.Point(351, 168);
            this.txtCamiseta.Name = "txtCamiseta";
            this.txtCamiseta.Size = new System.Drawing.Size(125, 20);
            this.txtCamiseta.TabIndex = 13;
            // 
            // lblCamiseta
            // 
            this.lblCamiseta.AutoSize = true;
            this.lblCamiseta.Location = new System.Drawing.Point(348, 151);
            this.lblCamiseta.Name = "lblCamiseta";
            this.lblCamiseta.Size = new System.Drawing.Size(50, 13);
            this.lblCamiseta.TabIndex = 14;
            this.lblCamiseta.Text = "Camiseta";
            // 
            // FrmIngresarEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 430);
            this.Controls.Add(this.lblCamiseta);
            this.Controls.Add(this.txtCamiseta);
            this.Controls.Add(this.lblPosiciones);
            this.Controls.Add(this.lblPersonas);
            this.Controls.Add(this.lblTecnico);
            this.Controls.Add(this.lblNombreEquipo);
            this.Controls.Add(this.txtTecnico);
            this.Controls.Add(this.cboPosiciones);
            this.Controls.Add(this.lblEquipo);
            this.Controls.Add(this.txtNombreEquipo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cboPersonas);
            this.Controls.Add(this.dgvJugadores);
            this.Name = "FrmIngresarEquipo";
            this.Text = "Nuevo Equipo";
            this.Load += new System.EventHandler(this.FrmIngresarEquipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJugadores;
        private System.Windows.Forms.ComboBox cboPersonas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNombreEquipo;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.ComboBox cboPosiciones;
        private System.Windows.Forms.TextBox txtTecnico;
        private System.Windows.Forms.Label lblNombreEquipo;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.Label lblPersonas;
        private System.Windows.Forms.Label lblPosiciones;
        private System.Windows.Forms.TextBox txtCamiseta;
        private System.Windows.Forms.Label lblCamiseta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJugador;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCamiseta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPosicion;
        private System.Windows.Forms.DataGridViewButtonColumn ColAcciones;
    }
}

