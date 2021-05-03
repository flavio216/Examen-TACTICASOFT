using CapaDatos;
using CapaNegocio;
using CapaNegocio.ModelCaja;
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
    public partial class frmCaja : Form
    {
        List<Caja> Listado = new List<Caja>();
        public frmCaja()
        {
            InitializeComponent();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            int codigo;
            try
            {
                codigo = int.Parse(txtID.Text);
                string sql = "SELECT nombre, precio, categoria FROM Productos WHERE id = " + codigo + " AND Estado = 1";
                ConexionBD gestor = new ConexionBD();
                buscarProducto(sql);
                txtCantidad.Text = "1";
            }
            catch (Exception)
            {
                txtCantidad.Text = "0";

            }
        }
        private void buscarProducto(string sql)
        {
            DataTable dt = new DataTable();
            ConexionBD bd = new ConexionBD();
            dt = bd.buscarTabla(sql);
            try
            {
                txtNombre.Text = dt.Rows[0]["Nombre"].ToString();
                txtPrecio.Text = dt.Rows[0]["Precio"].ToString();
                txtCategoria.Text = dt.Rows[0]["Categoria"].ToString();
                btnAgregar.Enabled = true;
            }
            catch (Exception)
            {

                txtNombre.Clear();
                txtPrecio.Clear();
                txtCantidad.Clear();
                btnAgregar.Enabled = false;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtID.Text);
            string nombre = txtNombre.Text;
            float precio = float.Parse(txtPrecio.Text);
            string categoria = txtCategoria.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            float total = 0;
            bool existe = false;

            foreach (var item in Listado)
            {
                if (item.Codigo == codigo)
                {
                    item.Cantidad += cantidad;
                    existe = true;
                }
            }

            if (!existe)
            {
                Caja c = new Caja(codigo, nombre, precio, categoria, cantidad);
                Listado.Add(c);
            }
            var list = new BindingList<Caja>(Listado);
            dtgvCaja.DataSource = list;
            dtgvCaja.Columns[0].HeaderText = "Codigo";
            dtgvCaja.Columns[1].HeaderText = "Nombre";
            dtgvCaja.Columns[2].HeaderText = "Precio";
            dtgvCaja.Columns[3].HeaderText = "Categoria";
            dtgvCaja.Columns[4].HeaderText = "Cantidad";
            Limpiar();


            foreach (var producto in Listado)
            {
                total += producto.Cantidad * producto.Precio;
            }
            lblSubTotal.Text = total.ToString();
        }
        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgvCaja.SelectedRows)
            {
                if(!row.IsNewRow)
                {
                    dtgvCaja.Rows.Remove(row);
                }
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dtgvCaja.Rows.Count > 0)
            {
                frmFacturacion frm = new frmFacturacion(GetDataTableFromDGV(dtgvCaja));
                dtgvCaja.Rows.Clear();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("El carrito se encuentra vacio", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
    }
}
