namespace LigaCordobesaApp.Presentacion
{
    partial class FrmReportePersonas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dTPersonasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSPersonas = new LigaCordobesaApp.Presentacion.Reportes.DSPersonas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dTPersonasTableAdapter = new LigaCordobesaApp.Presentacion.Reportes.DSPersonasTableAdapters.DTPersonasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dTPersonasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // dTPersonasBindingSource
            // 
            this.dTPersonasBindingSource.DataMember = "DTPersonas";
            this.dTPersonasBindingSource.DataSource = this.dSPersonas;
            // 
            // dSPersonas
            // 
            this.dSPersonas.DataSetName = "DSPersonas";
            this.dSPersonas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dTPersonasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LigaCordobesaApp.Presentacion.Reportes.RptPersonas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(556, 309);
            this.reportViewer1.TabIndex = 0;
            // 
            // dTPersonasTableAdapter
            // 
            this.dTPersonasTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportePersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 309);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReportePersonas";
            this.Text = "Reporte de Personas";
            this.Load += new System.EventHandler(this.FrmReportePersonas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dTPersonasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPersonas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes.DSPersonas dSPersonas;
        private System.Windows.Forms.BindingSource dTPersonasBindingSource;
        private Reportes.DSPersonasTableAdapters.DTPersonasTableAdapter dTPersonasTableAdapter;
    }
}