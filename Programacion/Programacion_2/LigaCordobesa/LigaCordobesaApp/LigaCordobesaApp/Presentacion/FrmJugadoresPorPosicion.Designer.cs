namespace LigaCordobesaApp.Presentacion
{
    partial class FrmJugadoresPorPosicion
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
            this.components = new System.ComponentModel.Container();
            this.lblEdadDesde = new System.Windows.Forms.Label();
            this.lblEdadHasta = new System.Windows.Forms.Label();
            this.txtEdadDesde = new System.Windows.Forms.TextBox();
            this.txtEdadHasta = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSPosiciones = new LigaCordobesaApp.Presentacion.Reportes.DSPosiciones();
            this.dTPosicionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dSPosiciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTPosicionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEdadDesde
            // 
            this.lblEdadDesde.AutoSize = true;
            this.lblEdadDesde.Location = new System.Drawing.Point(24, 22);
            this.lblEdadDesde.Name = "lblEdadDesde";
            this.lblEdadDesde.Size = new System.Drawing.Size(66, 13);
            this.lblEdadDesde.TabIndex = 1;
            this.lblEdadDesde.Text = "Edad Desde";
            // 
            // lblEdadHasta
            // 
            this.lblEdadHasta.AutoSize = true;
            this.lblEdadHasta.Location = new System.Drawing.Point(209, 22);
            this.lblEdadHasta.Name = "lblEdadHasta";
            this.lblEdadHasta.Size = new System.Drawing.Size(63, 13);
            this.lblEdadHasta.TabIndex = 2;
            this.lblEdadHasta.Text = "Edad Hasta";
            // 
            // txtEdadDesde
            // 
            this.txtEdadDesde.Location = new System.Drawing.Point(278, 19);
            this.txtEdadDesde.Name = "txtEdadDesde";
            this.txtEdadDesde.Size = new System.Drawing.Size(100, 20);
            this.txtEdadDesde.TabIndex = 3;
            // 
            // txtEdadHasta
            // 
            this.txtEdadHasta.Location = new System.Drawing.Point(94, 19);
            this.txtEdadHasta.Name = "txtEdadHasta";
            this.txtEdadHasta.Size = new System.Drawing.Size(100, 20);
            this.txtEdadHasta.TabIndex = 4;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(599, 16);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LigaCordobesaApp.Presentacion.Reportes.RptPosiciones.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(84, 73);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 6;
            // 
            // reportViewer2
            // 
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "LigaCordobesaApp.Presentacion.Reportes.RptPosiciones.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(8, 45);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(666, 272);
            this.reportViewer2.TabIndex = 7;
            // 
            // dSPosiciones
            // 
            this.dSPosiciones.DataSetName = "DSPosiciones";
            this.dSPosiciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dTPosicionesBindingSource
            // 
            this.dTPosicionesBindingSource.DataMember = "DTPosiciones";
            this.dTPosicionesBindingSource.DataSource = this.dSPosiciones;
            // 
            // FrmJugadoresPorPosicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 331);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtEdadHasta);
            this.Controls.Add(this.txtEdadDesde);
            this.Controls.Add(this.lblEdadHasta);
            this.Controls.Add(this.lblEdadDesde);
            this.Name = "FrmJugadoresPorPosicion";
            this.Text = "Reporte de Jugadores por posicion";
            this.Load += new System.EventHandler(this.FrmJugadoresPorPosicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSPosiciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTPosicionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEdadDesde;
        private System.Windows.Forms.Label lblEdadHasta;
        private System.Windows.Forms.TextBox txtEdadDesde;
        private System.Windows.Forms.TextBox txtEdadHasta;
        private System.Windows.Forms.Button btnConsultar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Reportes.DSPosiciones dSPosiciones;
        private System.Windows.Forms.BindingSource dTPosicionesBindingSource;
    }
}