﻿
namespace Examen_TACTICASOFT.Facturacion
{
    partial class frmReporteVentas
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cojuntoDeDatos = new Examen_TACTICASOFT.CojuntoDeDatos();
            this.reporteVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteVentasTableAdapter = new Examen_TACTICASOFT.CojuntoDeDatosTableAdapters.ReporteVentasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cojuntoDeDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporteVentasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Examen_TACTICASOFT.Facturacion.infReporteVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // cojuntoDeDatos
            // 
            this.cojuntoDeDatos.DataSetName = "CojuntoDeDatos";
            this.cojuntoDeDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteVentasBindingSource
            // 
            this.reporteVentasBindingSource.DataMember = "ReporteVentas";
            this.reporteVentasBindingSource.DataSource = this.cojuntoDeDatos;
            // 
            // reporteVentasTableAdapter
            // 
            this.reporteVentasTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteVentas";
            this.Text = "frmReporteVentas";
            this.Load += new System.EventHandler(this.frmReporteVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cojuntoDeDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteVentasBindingSource;
        private CojuntoDeDatos cojuntoDeDatos;
        private CojuntoDeDatosTableAdapters.ReporteVentasTableAdapter reporteVentasTableAdapter;
    }
}