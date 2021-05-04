
namespace Examen_TACTICASOFT.Productos
{
    partial class frmSinStock
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
            this.productosSinStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productosSinStockTableAdapter = new Examen_TACTICASOFT.CojuntoDeDatosTableAdapters.ProductosSinStockTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cojuntoDeDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosSinStockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.productosSinStockBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Examen_TACTICASOFT.Productos.infReporteProductosSinStock.rdlc";
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
            // productosSinStockBindingSource
            // 
            this.productosSinStockBindingSource.DataMember = "ProductosSinStock";
            this.productosSinStockBindingSource.DataSource = this.cojuntoDeDatos;
            // 
            // productosSinStockTableAdapter
            // 
            this.productosSinStockTableAdapter.ClearBeforeFill = true;
            // 
            // frmProductosSinStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmProductosSinStock";
            this.Text = "frmProductosSinStock";
            this.Load += new System.EventHandler(this.frmProductosSinStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cojuntoDeDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosSinStockBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CojuntoDeDatos cojuntoDeDatos;
        private System.Windows.Forms.BindingSource productosSinStockBindingSource;
        private CojuntoDeDatosTableAdapters.ProductosSinStockTableAdapter productosSinStockTableAdapter;
    }
}