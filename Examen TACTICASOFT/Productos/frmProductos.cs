using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace Examen_TACTICASOFT
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
            MaximoCaracteres();
            RellenarDTGVProductos();
            RellenarDTGVProductosSinStock();
            dtgProductos.Columns[0].Visible = false;
            dtgProductoSinStock.Columns[0].Visible = false;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Seguro desea insertar el producto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                string nombre = txtNombre.Text;
                float precio = float.Parse(txtPrecio.Text);
                string categoria = txtCategoria.Text;

                Productos p = new Productos(0,nombre,precio,categoria,1);

                GestorProductos gestor = new GestorProductos();

                bool resultado = gestor.InsertarProducto(p);
                if (resultado)
                {
                    MessageBox.Show("El producto se cargo con exito", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("No se ha podido insertar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       private void RellenarDTGVProductos()
        {
            DataTable dt = new DataTable();
            GestorProductos gestor = new GestorProductos();
            dt = gestor.ConsultarProductos();
            dtgProductos.DataSource = dt;
            dtgProductos.ReadOnly = true;
        }
        private void RellenarDTGVProductosSinStock()
        {
            DataTable dt = new DataTable();
            GestorProductos gestor = new GestorProductos();
            dt = gestor.ConsultarProductosSinStock();
            dtgProductoSinStock.DataSource = dt;
            dtgProductoSinStock.ReadOnly = true;
        }



        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            GestorProductos gestor = new GestorProductos();
            string sql = "SELECT id, nombre, precio,categoria from productos WHERE nombre LIKE '" + txtBuscar.Text + "%' or id LIKE '" + txtBuscar.Text + "%'"; ;
            gestor.Buscar(sql, dtgProductos);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked == true)
            {
                dtgProductos.Columns[0].Visible = true;
            }
            else
            {
                dtgProductos.Columns[0].Visible = false;

            }
        }



        private void dtgProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Desea eliminar los registros?", "Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcion == DialogResult.Yes)
            {
                string codigo;
                string sql;
                ConexionBD bd = new ConexionBD();
                foreach (DataGridViewRow row in dtgProductos.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigo = Convert.ToString(row.Cells[1].Value);
                        sql = "delete from productos where id =" + codigo;
                        bd.actualizarBD(sql);
                    }
                }

            }
            RellenarDTGVProductos();
        }

        private void dtgProductos_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = Convert.ToString(dtgProductos.CurrentRow.Cells[1].Value);
            txtNombre.Text = Convert.ToString(dtgProductos.CurrentRow.Cells[2].Value);
            txtPrecio.Text = Convert.ToString(dtgProductos.CurrentRow.Cells[3].Value);
            txtCategoria.Text = Convert.ToString(dtgProductos.CurrentRow.Cells[4].Value);
            tabControl1.SelectedIndex = 1;
            Habilitar(true);
            btnModificar.Enabled = true;
            btnBaja.Enabled = true;
            btnAlta.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro que desea editar este cliente?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (validarCampos())
                {
                    int id = int.Parse(txtCodigo.Text);
                    string nombre = txtNombre.Text;
                    float precio = float.Parse(txtPrecio.Text);
                    string categoria = txtCategoria.Text;

                    Productos p = new Productos(id, nombre, precio, categoria,1);

                    GestorProductos gestor = new GestorProductos();

                    bool resultado = gestor.EditarProducto(p);

                    if (resultado)
                    {
                        MessageBox.Show("El producto se ha modificado con exito.", "Modificar producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tabControl1.SelectedIndex = 0;
                        RellenarDTGVProductos();
                        Limpiar();

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

            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Debe ingresar un Codigo...");
                txtNombre.Focus();
                ok = false;
                errorCliente.SetError(txtNombre, "Ingrese un Codigo");
                return false;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre...");
                txtNombre.Focus();
                ok = false;
                errorCliente.SetError(txtNombre, "Ingrese un nombre");
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Debe ingresar un Precio...");
                txtPrecio.Focus();
                ok = false;
                errorCliente.SetError(txtPrecio, "Ingrese un Precio");
                return false;
            }
            if (txtCategoria.Text == "")
            {
                MessageBox.Show("Debe ingresar una categoria...");
                txtCategoria.Focus();
                ok = false;
                errorCliente.SetError(txtCategoria, "Ingrese una categoria");
                return false;
            }

            return true;
        }
        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "";
        }

        private void txtBuscarSinStock_TextChanged(object sender, EventArgs e)
        {
            GestorProductos gestor = new GestorProductos();
            string sql= " select * from productos where id like '"+txtBuscarSinStock.Text+"%' and estado = 0";
            gestor.Buscar(sql,dtgProductoSinStock);
        }

        private void dtgProductoSinStock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCodigo.Text = Convert.ToString(dtgProductoSinStock.CurrentRow.Cells[0].Value);
            txtNombre.Text = Convert.ToString(dtgProductoSinStock.CurrentRow.Cells[1].Value);
            txtPrecio.Text = Convert.ToString(dtgProductoSinStock.CurrentRow.Cells[2].Value);
            txtCategoria.Text = Convert.ToString(dtgProductoSinStock.CurrentRow.Cells[3].Value);
            tabControl1.SelectedIndex = 1;
            Habilitar(true);
            btnModificar.Enabled = true;
            btnBaja.Enabled = false;
            btnAlta.Enabled = true;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Quiere dar de alta el producto?", "Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Opcion == DialogResult.OK)
            {
                int Codigo;
                string sql;

                ConexionBD bd = new ConexionBD();
                Codigo = Convert.ToInt32(dtgProductoSinStock.CurrentRow.Cells[0].Value);
                sql = "UPDATE productos Set Estado = 1 WHERE Id=" + Codigo;
                bd.actualizarBD(sql);
               
                tabControl1.SelectedIndex = 0;
                RellenarDTGVProductos();
                RellenarDTGVProductosSinStock();
                Limpiar();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Quiere dar de baja el producto?", "Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Opcion == DialogResult.OK)
            {
                int Codigo;
                string sql;

                ConexionBD bd = new ConexionBD();
                Codigo = Convert.ToInt32(dtgProductos.CurrentRow.Cells[1].Value);
                sql = "UPDATE productos Set Estado = 0 WHERE Id=" + Codigo;
                bd.actualizarBD(sql);

                tabControl1.SelectedIndex = 2;
                RellenarDTGVProductosSinStock();
                RellenarDTGVProductos();
                Limpiar();
            }
        }
        private void MaximoCaracteres()
        {
            txtNombre.MaxLength = 20;
            txtPrecio.MaxLength = 5;
            txtCategoria.MaxLength = 20;

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            lblCantidadRegistrosSinStock.Text = "Cantidad de Registros: " + dtgProductoSinStock.Rows.Count;
            lblCantidadRegistros.Text = "Cantidad de Registros: " + dtgProductos.Rows.Count;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloDecimales(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void Habilitar(bool x)
        {
            txtCodigo.Enabled = x;
            txtNombre.Enabled = x;
            txtPrecio.Enabled = x;
            txtCategoria.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnCargar.Enabled = !x;
            btnModificar.Enabled = !x;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            btnCargar.Enabled = true;
            Limpiar();
            btnBaja.Enabled = false;
            btnAlta.Enabled = false;
        }

        private void dtgProductoSinStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
            Limpiar();
            btnCargar.Enabled = false;
            btnModificar.Enabled = false;
        }
    }
}
