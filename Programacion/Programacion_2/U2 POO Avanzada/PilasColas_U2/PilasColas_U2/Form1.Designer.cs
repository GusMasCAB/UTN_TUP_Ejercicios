namespace PilasColas_U2
{
    partial class Form1
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
            this.btnPila = new System.Windows.Forms.Button();
            this.btnCola = new System.Windows.Forms.Button();
            this.lstPila = new System.Windows.Forms.ListBox();
            this.lstCola = new System.Windows.Forms.ListBox();
            this.txtPila = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnExtraer = new System.Windows.Forms.Button();
            this.txtCola = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPila
            // 
            this.btnPila.Location = new System.Drawing.Point(83, 29);
            this.btnPila.Name = "btnPila";
            this.btnPila.Size = new System.Drawing.Size(75, 23);
            this.btnPila.TabIndex = 0;
            this.btnPila.Text = "Pila";
            this.btnPila.UseVisualStyleBackColor = true;
            // 
            // btnCola
            // 
            this.btnCola.Location = new System.Drawing.Point(221, 29);
            this.btnCola.Name = "btnCola";
            this.btnCola.Size = new System.Drawing.Size(75, 23);
            this.btnCola.TabIndex = 1;
            this.btnCola.Text = "Cola";
            this.btnCola.UseVisualStyleBackColor = true;
            // 
            // lstPila
            // 
            this.lstPila.Location = new System.Drawing.Point(62, 94);
            this.lstPila.Name = "lstPila";
            this.lstPila.Size = new System.Drawing.Size(120, 134);
            this.lstPila.TabIndex = 3;
            // 
            // lstCola
            // 
            this.lstCola.FormattingEnabled = true;
            this.lstCola.Location = new System.Drawing.Point(202, 94);
            this.lstCola.Name = "lstCola";
            this.lstCola.Size = new System.Drawing.Size(120, 134);
            this.lstCola.TabIndex = 4;
            // 
            // txtPila
            // 
            this.txtPila.Location = new System.Drawing.Point(62, 59);
            this.txtPila.Name = "txtPila";
            this.txtPila.Size = new System.Drawing.Size(120, 20);
            this.txtPila.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(62, 249);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnExtraer
            // 
            this.btnExtraer.Location = new System.Drawing.Point(247, 249);
            this.btnExtraer.Name = "btnExtraer";
            this.btnExtraer.Size = new System.Drawing.Size(75, 23);
            this.btnExtraer.TabIndex = 6;
            this.btnExtraer.Text = "Extraer";
            this.btnExtraer.UseVisualStyleBackColor = true;
            // 
            // txtCola
            // 
            this.txtCola.Location = new System.Drawing.Point(202, 59);
            this.txtCola.Name = "txtCola";
            this.txtCola.Size = new System.Drawing.Size(120, 20);
            this.txtCola.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 300);
            this.Controls.Add(this.txtCola);
            this.Controls.Add(this.btnExtraer);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtPila);
            this.Controls.Add(this.lstCola);
            this.Controls.Add(this.lstPila);
            this.Controls.Add(this.btnCola);
            this.Controls.Add(this.btnPila);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPila;
        private System.Windows.Forms.Button btnCola;
        private System.Windows.Forms.ListBox lstPila;
        private System.Windows.Forms.ListBox lstCola;
        private System.Windows.Forms.TextBox txtPila;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnExtraer;
        private System.Windows.Forms.TextBox txtCola;
    }
}

