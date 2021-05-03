using CapaDatos;
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
            RellenarDTGVClientes();
            dtgCliente.Columns[0].Visible = false;
            MaximoCaracteres();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            btnModificar.Enabled = false;
            Limpiar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            GestorClientes gestor = new GestorClientes();
            string sql = "SELECT * from clientes WHERE cliente LIKE '" + txtBuscar.Text + "%' or id LIKE '"+txtBuscar.Text +"%'";
            gestor.Buscar(sql, dtgCliente);
        }
      

        private void RellenarDTGVClientes()
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
        

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
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
                    tabControl1.SelectedIndex = 1;
                    Limpiar();

                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la carga del cliente, por favor contacte al Administrador del sistema.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }

            }
            
           
            RellenarDTGVClientes();
        }
        private void Mostrar(string sql, DataGridView dtgv)
        {
            ConexionBD bd = new ConexionBD();
            DataTable dt = new DataTable();
            dt = bd.buscarTabla(sql);
            dtgv.DataSource = dt;
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

        
        private void Habilitar(bool x)
        {
            txtNroCliente.Enabled = x;
            txtNombre.Enabled = x;
            txtTelefono.Enabled = x;
            txtCorreo.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnCargar.Enabled = x;
            btnModificar.Enabled = x;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Desea eliminar los registros?", "Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if(opcion == DialogResult.Yes)
            {
                string codigo;
                string sql;
                ConexionBD bd = new ConexionBD();
                foreach (DataGridViewRow row in dtgCliente.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigo = Convert.ToString(row.Cells[1].Value);
                        sql = "delete from clientes where id =" + codigo;
                        bd.actualizarBD(sql);                       
                    }
                }

            }
            RellenarDTGVClientes();


        }

        private void dtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgCliente.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dtgCliente.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }

        }
        private void Limpiar()
        {
            txtNroCliente.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }


        private void dtgCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNroCliente.Text = Convert.ToString(dtgCliente.CurrentRow.Cells[1].Value);
            txtNombre.Text = Convert.ToString(dtgCliente.CurrentRow.Cells[2].Value);
            txtTelefono.Text = Convert.ToString(dtgCliente.CurrentRow.Cells[3].Value);
            txtCorreo.Text = Convert.ToString(dtgCliente.CurrentRow.Cells[4].Value);
            Habilitar(true);
            tabControl1.SelectedIndex = 0;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea editar este cliente?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (validarCampos())
                {
                    int id = int.Parse(txtNroCliente.Text);
                    string nombre = txtNombre.Text;
                    string telefono = txtTelefono.Text;
                    string correo = txtCorreo.Text;

                    Clientes c = new Clientes(id, nombre, telefono, correo);

                    GestorClientes gestor = new GestorClientes();

                    bool resultado = gestor.EditarCliente(c);

                    if (resultado)
                    {
                        MessageBox.Show("El cliente se ha modificado con exito.", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tabControl1.SelectedIndex = 1;
                        RellenarDTGVClientes();
                        

                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en la edición del cliente, por favor contacte al Administrador del sistema.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private bool validarCampos()
        {
            bool ok = true;

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un Nombre...");
                txtNombre.Focus();
                ok = false;
                errorCliente.SetError(txtNombre, "Ingrese un Nombre");
                return false;
            }
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Debe ingresar el Telefono...");
                txtTelefono.Focus();
                ok = false;
                errorCliente.SetError(txtTelefono, "Ingrese Telefono");
                return false;
            }
            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Debe ingresar un Correo...");
                txtCorreo.Focus();
                ok = false;
                errorCliente.SetError(txtCorreo, "Ingrese un Correo");
                return false;
            }
           
            return true;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            lblCantidadRegistros.Text = "Cantidad de Registros: " + dtgCliente.Rows.Count;
           
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }
        private void MaximoCaracteres()
        {
            txtNombre.MaxLength = 20;
            txtTelefono.MaxLength = 14;
            txtCorreo.MaxLength = 20;
            txtBuscar.MaxLength = 10;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
