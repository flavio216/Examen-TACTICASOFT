
namespace Examen_TACTICASOFT.Productos
{
    partial class frmConStock
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cojuntoDeDatos = new Examen_TACTICASOFT.CojuntoDeDatos();
            this.productosConStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productosConStockTableAdapter = new Examen_TACTICASOFT.CojuntoDeDatosTableAdapters.ProductosConStockTableAdapter();
            this.cojuntoDeDatosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productosConStockBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cojuntoDeDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosConStockBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cojuntoDeDatosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosConStockBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.productosConStockBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.productosConStockBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Examen_TACTICASOFT.Productos.infReporteProductosStock.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // cojuntoDeDatos
            // 
            this.cojuntoDeDatos.DataSetName = "CojuntoDeDatos";
            this.cojuntoDeDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productosConStockBindingSource
            // 
            this.productosConStockBindingSource.DataMember = "ProductosConStock";
            this.productosConStockBindingSource.DataSource = this.cojuntoDeDatos;
            // 
            // productosConStockTableAdapter
            // 
            this.productosConStockTableAdapter.ClearBeforeFill = true;
            // 
            // cojuntoDeDatosBindingSource
            // 
            this.cojuntoDeDatosBindingSource.DataSource = this.cojuntoDeDatos;
            this.cojuntoDeDatosBindingSource.Position = 0;
            // 
            // productosConStockBindingSource1
            // 
            this.productosConStockBindingSource1.DataMember = "ProductosConStock";
            this.productosConStockBindingSource1.DataSource = this.cojuntoDeDatosBindingSource;
            // 
            // frmReporteProductosStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteProductosStock";
            this.Text = "frmReporteProductos";
            this.Load += new System.EventHandler(this.frmReporteProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cojuntoDeDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosConStockBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cojuntoDeDatosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosConStockBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CojuntoDeDatos cojuntoDeDatos;
        private System.Windows.Forms.BindingSource productosConStockBindingSource;
        private CojuntoDeDatosTableAdapters.ProductosConStockTableAdapter productosConStockTableAdapter;
        private System.Windows.Forms.BindingSource productosConStockBindingSource1;
        private System.Windows.Forms.BindingSource cojuntoDeDatosBindingSource;
    }
}