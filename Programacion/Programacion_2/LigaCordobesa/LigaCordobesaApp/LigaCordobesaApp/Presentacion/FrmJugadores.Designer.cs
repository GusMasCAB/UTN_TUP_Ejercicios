namespace LigaCordobesaApp.Presentacion
{
    partial class FrmJugadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblEdadDesde = new System.Windows.Forms.Label();
            this.lblEdadHasta = new System.Windows.Forms.Label();
            this.grpEquipo = new System.Windows.Forms.GroupBox();
            this.dgvJugadores = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEdad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPosicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.grpEquipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDesde
            // 
            this.txtDesde.Location = new System.Drawing.Point(78, 70);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(89, 20);
            this.txtDesde.TabIndex = 0;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(382, 29);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(86, 20);
            this.txtEdad.TabIndex = 1;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(103, 29);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(235, 20);
            this.txtNombreCompleto.TabIndex = 2;
            // 
            // txtHasta
            // 
            this.txtHasta.Location = new System.Drawing.Point(254, 70);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(84, 20);
            this.txtHasta.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 29);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 13);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre Completo";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(344, 32);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(32, 13);
            this.lblEdad.TabIndex = 5;
            this.lblEdad.Text = "Edad";
            // 
            // lblEdadDesde
            // 
            this.lblEdadDesde.AutoSize = true;
            this.lblEdadDesde.Location = new System.Drawing.Point(6, 73);
            this.lblEdadDesde.Name = "lblEdadDesde";
            this.lblEdadDesde.Size = new System.Drawing.Size(66, 13);
            this.lblEdadDesde.TabIndex = 6;
            this.lblEdadDesde.Text = "Edad Desde";
            // 
            // lblEdadHasta
            // 
            this.lblEdadHasta.AutoSize = true;
            this.lblEdadHasta.Location = new System.Drawing.Point(188, 73);
            this.lblEdadHasta.Name = "lblEdadHasta";
            this.lblEdadHasta.Size = new System.Drawing.Size(60, 13);
            this.lblEdadHasta.TabIndex = 7;
            this.lblEdadHasta.Text = "EdadHasta";
            // 
            // grpEquipo
            // 
            this.grpEquipo.Controls.Add(this.btnConsultar);
            this.grpEquipo.Controls.Add(this.txtHasta);
            this.grpEquipo.Controls.Add(this.lblNombre);
            this.grpEquipo.Controls.Add(this.lblEdadHasta);
            this.grpEquipo.Controls.Add(this.txtDesde);
            this.grpEquipo.Controls.Add(this.lblEdadDesde);
            this.grpEquipo.Controls.Add(this.txtNombreCompleto);
            this.grpEquipo.Controls.Add(this.lblEdad);
            this.grpEquipo.Controls.Add(this.txtEdad);
            this.grpEquipo.Location = new System.Drawing.Point(25, 28);
            this.grpEquipo.Name = "grpEquipo";
            this.grpEquipo.Size = new System.Drawing.Size(568, 143);
            this.grpEquipo.TabIndex = 8;
            this.grpEquipo.TabStop = false;
            this.grpEquipo.Text = "groupBox1";
            // 
            // dgvJugadores
            // 
            this.dgvJugadores.AllowUserToAddRows = false;
            this.dgvJugadores.AllowUserToDeleteRows = false;
            this.dgvJugadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJugadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ColNombreCompleto,
            this.ColEdad,
            this.ColPosicion});
            this.dgvJugadores.Location = new System.Drawing.Point(25, 177);
            this.dgvJugadores.Name = "dgvJugadores";
            this.dgvJugadores.ReadOnly = true;
            this.dgvJugadores.Size = new System.Drawing.Size(568, 184);
            this.dgvJugadores.TabIndex = 9;
            // 
            // ID
            // 
            this.ID.HeaderText = "ColID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ColNombreCompleto
            // 
            this.ColNombreCompleto.FillWeight = 150F;
            this.ColNombreCompleto.HeaderText = "Nombre Completo";
            this.ColNombreCompleto.Name = "ColNombreCompleto";
            this.ColNombreCompleto.ReadOnly = true;
            // 
            // ColEdad
            // 
            this.ColEdad.FillWeight = 50F;
            this.ColEdad.HeaderText = "Edad";
            this.ColEdad.Name = "ColEdad";
            this.ColEdad.ReadOnly = true;
            // 
            // ColPosicion
            // 
            this.ColPosicion.HeaderText = "Posicion";
            this.ColPosicion.Name = "ColPosicion";
            this.ColPosicion.ReadOnly = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(254, 114);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 10;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(260, 367);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FrmJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 396);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvJugadores);
            this.Controls.Add(this.grpEquipo);
            this.Name = "FrmJugadores";
            this.Text = "Jugadores";
            this.Load += new System.EventHandler(this.FrmJugadores_Load);
            this.grpEquipo.ResumeLayout(false);
            this.grpEquipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblEdadDesde;
        private System.Windows.Forms.Label lblEdadHasta;
        private System.Windows.Forms.GroupBox grpEquipo;
        private System.Windows.Forms.DataGridView dgvJugadores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEdad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPosicion;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnSalir;
    }
}