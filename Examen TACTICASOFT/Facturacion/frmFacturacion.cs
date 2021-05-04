using CapaDatos;
using CapaNegocio;
using CapaNegocio.GestorCaja;
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
    public partial class frmFacturacion : Form
    {
        public frmFacturacion(object dataSource)
        {
            InitializeComponent();
            timer1.Enabled = true;
            
            dgvCarrito.DataSource = dataSource;
            Calculos(dgvCarrito);
        }

        private void txtBuscarDni_TextChanged(object sender, EventArgs e)
        {
            int dni = int.Parse(txtBuscarDni.Text);
            string sql = " select cliente, telefono, correo from clientes";
            buscarDNI(sql);
        }
        private void buscarDNI(string sql)
        {
            DataTable dt = new DataTable();
            ConexionBD bd = new ConexionBD();
            dt = bd.buscarTabla(sql);

            try
            {
                txtNombre.Text = dt.Rows[0]["Cliente"].ToString();
                txtTelefono.Text = dt.Rows[0]["Telefono"].ToString();
                txtCorreo.Text = dt.Rows[0]["Correo"].ToString();    
                    
             }

            catch (Exception)
            {

                throw;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("hh,mm,ss");
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
          //  int nroventa = Convert.ToInt32(txtNroVenta);
            int dni = int.Parse(txtBuscarDni.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            float importeTotal = float.Parse(txtSubTotal.Text);

            Ventas v = new Ventas(0, dni, fecha, importeTotal);
            GestorCaja gestor = new GestorCaja();
            /*int id =  gestor.insertarVenta(v);
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (!(row.Cells[0].Value == null))
                {
                    int codigo = Convert.ToInt32(row.Cells[0].Value.ToString());
                    int cantidad = Convert.ToInt32(row.Cells[4].Value.ToString());
                    float precio = float.Parse(row.Cells[2].Value.ToString());
                    DetalleVentas dv = new DetalleVentas(0, id, codigo, precio, cantidad, precio * cantidad);
                    gestor.InsertarDetalle(dv);
                }

            }

            MessageBox.Show("El ID de la factura es : " + id, "AVISO");
            */

        }
        public void Calculos(DataGridView dgtv)
        {
            dgtv.Columns[0].HeaderText = "Codigo";
            dgtv.Columns[1].HeaderText = "Nombre";
            dgtv.Columns[2].HeaderText = "Precio";
            dgtv.Columns[3].HeaderText = "Categoria";
            dgtv.Columns[4].HeaderText = "Cantidad";
            float subtotal = 0;

            for (int i = 0; i < dgtv.Rows.Count; i++)
            {
                int cantidad = Convert.ToInt32(dgtv.Rows[i].Cells[2].Value);
                float precio = Convert.ToInt32(dgtv.Rows[i].Cells[4].Value);
                subtotal += cantidad * precio;
            }

            txtSubTotal.Text = subtotal.ToString();

        }

        private void txtBuscarDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }
    }
}
