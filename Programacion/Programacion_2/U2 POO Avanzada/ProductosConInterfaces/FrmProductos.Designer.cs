namespace ProductosConInterfaces
{
    partial class FrmProductos
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
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lstProductos = new System.Windows.Forms.ListBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.rbtSuelto = new System.Windows.Forms.RadioButton();
            this.lblTipo = new System.Windows.Forms.Label();
            this.rbtPack = new System.Windows.Forms.RadioButton();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtMedidaCantidad = new System.Windows.Forms.TextBox();
            this.lblMedidaCantidad = new System.Windows.Forms.Label();
            this.btnMostrarTotal = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(42, 307);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(104, 23);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar Producto";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(34, 72);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Codigo";
            // 
            // lstProductos
            // 
            this.lstProductos.FormattingEnabled = true;
            this.lstProductos.Location = new System.Drawing.Point(279, 14);
            this.lstProductos.Name = "lstProductos";
            this.lstProductos.Size = new System.Drawing.Size(296, 277);
            this.lstProductos.TabIndex = 2;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(80, 69);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 3;
            // 
            // rbtSuelto
            // 
            this.rbtSuelto.AutoSize = true;
            this.rbtSuelto.Checked = true;
            this.rbtSuelto.Location = new System.Drawing.Point(80, 12);
            this.rbtSuelto.Name = "rbtSuelto";
            this.rbtSuelto.Size = new System.Drawing.Size(55, 17);
            this.rbtSuelto.TabIndex = 4;
            this.rbtSuelto.TabStop = true;
            this.rbtSuelto.Text = "Suelto";
            this.rbtSuelto.UseVisualStyleBackColor = true;
            this.rbtSuelto.CheckedChanged += new System.EventHandler(this.rbtSuelto_CheckedChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(39, 14);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 5;
            this.lblTipo.Text = "Tipo:";
            // 
            // rbtPack
            // 
            this.rbtPack.AutoSize = true;
            this.rbtPack.Location = new System.Drawing.Point(80, 35);
            this.rbtPack.Name = "rbtPack";
            this.rbtPack.Size = new System.Drawing.Size(50, 17);
            this.rbtPack.TabIndex = 6;
            this.rbtPack.TabStop = true;
            this.rbtPack.Text = "Pack";
            this.rbtPack.UseVisualStyleBackColor = true;
            this.rbtPack.CheckedChanged += new System.EventHandler(this.rbtPack_CheckedChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(80, 102);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(193, 20);
            this.txtNombre.TabIndex = 8;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(34, 105);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(80, 135);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 10;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(34, 138);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 9;
            this.lblPrecio.Text = "Precio";
            // 
            // txtMedidaCantidad
            // 
            this.txtMedidaCantidad.Location = new System.Drawing.Point(80, 168);
            this.txtMedidaCantidad.Name = "txtMedidaCantidad";
            this.txtMedidaCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtMedidaCantidad.TabIndex = 12;
            // 
            // lblMedidaCantidad
            // 
            this.lblMedidaCantidad.AutoSize = true;
            this.lblMedidaCantidad.Location = new System.Drawing.Point(33, 171);
            this.lblMedidaCantidad.Name = "lblMedidaCantidad";
            this.lblMedidaCantidad.Size = new System.Drawing.Size(42, 13);
            this.lblMedidaCantidad.TabIndex = 11;
            this.lblMedidaCantidad.Text = "Medida";
            // 
            // btnMostrarTotal
            // 
            this.btnMostrarTotal.Location = new System.Drawing.Point(161, 307);
            this.btnMostrarTotal.Name = "btnMostrarTotal";
            this.btnMostrarTotal.Size = new System.Drawing.Size(104, 23);
            this.btnMostrarTotal.TabIndex = 13;
            this.btnMostrarTotal.Text = "Mostrar Total";
            this.btnMostrarTotal.UseVisualStyleBackColor = true;
            this.btnMostrarTotal.Click += new System.EventHandler(this.btnMostrarTotal_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(475, 304);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 15;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(434, 307);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 13);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total $";
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 345);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnMostrarTotal);
            this.Controls.Add(this.txtMedidaCantidad);
            this.Controls.Add(this.lblMedidaCantidad);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.rbtPack);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.rbtSuelto);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lstProductos);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnCargar);
            this.Name = "FrmProductos";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ListBox lstProductos;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.RadioButton rbtSuelto;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.RadioButton rbtPack;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtMedidaCantidad;
        private System.Windows.Forms.Label lblMedidaCantidad;
        private System.Windows.Forms.Button btnMostrarTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
    }
}

