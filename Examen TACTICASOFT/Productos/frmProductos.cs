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
            Habilitar(false);
            dtgProductos.Columns[0].Visible = false;
            txtCodigo.Enabled = false;
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            
                if (MessageBox.Show("Seguro desea insertar el producto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
               {
                if (validarCampos())
                {            
                string nombre = txtNombre.Text;
                float precio = float.Parse(txtPrecio.Text);
                string categoria = txtCategoria.Text;

                Producto p = new Producto(0,nombre,precio,categoria);

                GestorProductos gestor = new GestorProductos();

                bool resultado = gestor.InsertarProducto(p);
                if (resultado)
                {
                    MessageBox.Show("El producto se cargo con exito", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                   tabControl1.SelectedIndex = 1;
                   RellenarDTGVProductos();
                   lblCantidadRegistros.Text = "Cantidad de registros:" + dtgProductos.Rows.Count.ToString();
                    }
                else
                {
                    MessageBox.Show("No se ha podido insertar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string sql = "SELECT id, nombre, precio,categoria from productos WHERE nombre LIKE '" + txtBuscar.Text + "%' or id LIKE '" + txtBuscar.Text + "%'";
                Buscar(sql, dtgProductos);
            }
            catch (Exception)
            {

                Limpiar();
            }
           
           
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
            lblCantidadRegistros.Text = "Cantidad de registros:" + dtgProductos.Rows.Count.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro que desea editar este Producto?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (validarCampos())
                {
                    int id = int.Parse(txtCodigo.Text);
                    string nombre = txtNombre.Text;
                    float precio = float.Parse(txtPrecio.Text);
                    string categoria = txtCategoria.Text;

                    Producto p = new Producto(id, nombre, precio, categoria);

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

       
        public void Buscar(string sql, DataGridView dtgv)
        {
            DataTable dt = new DataTable();
            ConexionBD bd = new ConexionBD();
            dt = bd.buscarTabla(sql);
            dtgv.DataSource = dt;
            lblCantidadRegistros.Text = "Cantidad de registros:" +dtgProductos.Rows.Count.ToString();


        }


        private void MaximoCaracteres()
        {
            txtNombre.MaxLength = 20;
            txtPrecio.MaxLength = 5;
            txtCategoria.MaxLength = 20;
            txtBuscar.MaxLength = 10;

        }


        private void frmProductos_Load(object sender, EventArgs e)
        {
            
            lblCantidadRegistros.Text = "Cantidad de Registros: " + dtgProductos.Rows.Count.ToString();
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
        }

      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
            Limpiar();
            btnCargar.Enabled = false;
            btnModificar.Enabled = false;
        }



     

        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgProductos.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dtgProductos.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dtgProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = Convert.ToString(dtgProductos.CurrentRow.Cells[1].Value);
            txtNombre.Text = Convert.ToString(dtgProductos.CurrentRow.Cells[2].Value);
            txtPrecio.Text = Convert.ToString(dtgProductos.CurrentRow.Cells[3].Value);
            txtCategoria.Text = Convert.ToString(dtgProductos.CurrentRow.Cells[4].Value);
            tabControl1.SelectedIndex = 1;
            Habilitar(true);
            btnModificar.Enabled = true;
            txtCodigo.Enabled = false;
        }

      
    }
}
