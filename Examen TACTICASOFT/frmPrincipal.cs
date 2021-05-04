using Examen_TACTICASOFT.Facturacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_TACTICASOFT
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        public void abrirFormHijo(Form formHijo, Panel panel)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panel.Controls.Add(formHijo);
            panel.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmProductos(), panelFormHijo);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmCliente(), panelFormHijo);
        }

        private void btnImportes_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmCaja(), panelFormHijo);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
