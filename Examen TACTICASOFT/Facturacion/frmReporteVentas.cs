using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_TACTICASOFT.Facturacion
{
    public partial class frmReporteVentas : Form
    {
        int idventa;
        public frmReporteVentas(int idventa)
        {
            InitializeComponent();
            this.idventa = idventa;
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            try
            {
                this.reporteVentasTableAdapter.Fill(this.cojuntoDeDatos.ReporteVentas, idventa);
            }
            catch (Exception)
            {

            }

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
