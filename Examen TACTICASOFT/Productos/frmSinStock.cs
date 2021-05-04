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
    public partial class frmSinStock : Form
    {
        public frmSinStock()
        {
            InitializeComponent();
        }

        private void frmProductosSinStock_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cojuntoDeDatos.ProductosSinStock' Puede moverla o quitarla según sea necesario.
            this.productosSinStockTableAdapter.Fill(this.cojuntoDeDatos.ProductosSinStock);

            this.reportViewer1.RefreshReport();
        }
    }
}
