using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_TACTICASOFT.Productos
{
    public partial class frmConStock : Form
    {
        public frmConStock()
        {
            InitializeComponent();
        }

        private void frmReporteProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cojuntoDeDatos.ProductosConStock' Puede moverla o quitarla según sea necesario.
            this.productosConStockTableAdapter.Fill(this.cojuntoDeDatos.ProductosConStock);
            // TODO: esta línea de código carga datos en la tabla 'pruebademoDataSet1.productos' Puede moverla o quitarla según sea necesario.

            this.reportViewer1.RefreshReport();
        }
    }
}
