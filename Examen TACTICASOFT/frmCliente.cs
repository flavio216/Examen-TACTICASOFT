using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;
namespace Examen_TACTICASOFT
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();           
            RellenarDTGVClientesActivos();
            dtgCliente.Columns[0].Visible = false;

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            GestorClientes gestor = new GestorClientes();
            string sql = "SELECT * from clientes WHERE cliente LIKE '" + txtBuscar.Text + "%' or id LIKE '"+txtBuscar.Text +"%'";
            gestor.Buscar(sql, dtgCliente);
        }
        private void RellenarDTGVClientesActivos()
        {
            try
            {
                DataTable dt = new DataTable();
                //ConexionesBD.ConexionBD conex = new ConexionesBD.ConexionBD();
                GestorClientes bd = new GestorClientes();
                dt = bd.consultarTablaClientes();
                dtgCliente.DataSource = dt;
                dtgCliente.ReadOnly = true;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e, "ERROR");
            }



        }
        private void dtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNroCliente.Text = Convert.ToString(dtgCliente.CurrentRow.Cells[1].Value);
            txtNombre.Text = Convert.ToString(dtgCliente.CurrentRow.Cells[2].Value);
            txtTelefono.Text = Convert.ToString(dtgCliente.CurrentRow.Cells[3].Value);
            txtCorreo.Text = Convert.ToString(dtgCliente.CurrentRow.Cells[4].Value);
            tabControl1.SelectedIndex = 0;
            // Habilitar(true);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea cargar este cliente?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                //int id = int.Parse(txtNroCliente.Text);
                string cliente = txtNombre.Text;
                string telefono = txtTelefono.Text;
                string correo = txtTelefono.Text;

                Clientes c = new Clientes(0, cliente, telefono, correo);


                GestorClientes gestor = new GestorClientes();
                bool resultado = gestor.InsertarCliente(c);
                if (resultado)
                {
                    MessageBox.Show("El cliente se ha cargado con exito.", "Insertar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la carga del cliente, por favor contacte al Administrador del sistema.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked == true)
            {
                dtgCliente.Columns[0].Visible = true;
            }
            else
            {
                dtgCliente.Columns[0].Visible = false;

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
