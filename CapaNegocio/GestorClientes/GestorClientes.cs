using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio

{
    public class GestorClientes
    {
        public bool InsertarCliente(Clientes c)
        {
            bool resultado = false;
            ConexionBD bd = new ConexionBD();

            try
            {
                string consulta = "INSERT INTO Clientes VALUES ( @Cliente, @Telefono, @Correo)";
                SqlCommand cmd = new SqlCommand(consulta, bd.conexion);
                cmd.Parameters.Clear();
                //  cmd.Parameters.AddWithValue("@idCliente", c.Id);
                cmd.Parameters.AddWithValue("@Cliente", c.Cliente);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@Correo", c.Correo);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                bd.Conectar();
                //cmd.Connection = conex.conexion;
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception)
            {
                MessageBox.Show(

                    "No se ha podido insertar.",
                    "Aviso");
            }
            finally
            {
                bd.Desconectar();
            }

            return resultado;
        }
        public void Buscar(string sql, DataGridView dtgv)
        {
            DataTable dt = new DataTable();
            ConexionBD gestor = new ConexionBD();
            dt = gestor.buscarTabla(sql);
            dtgv.DataSource = dt;
            //lblCantidadRegistros.Text = "Cantidad de Registros: " + dtgv.Rows.Count;
            //lblCantidadRegistrosBaja.Text = "Cantidad de Registros: " + dtgv.Rows.Count;
        }
        public DataTable consultarTablaClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD conex = new ConexionBD();
                conex.Conectar();
                conex.pComando.CommandText = "SELECT * from clientes";
                dt.Load(conex.pComando.ExecuteReader());
                conex.Desconectar();
                return dt;
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("No se podido establecer conexión con la base de datos, por favor contacte al administrador" +
                    "del sistema.");
                return dt;
            }

        }
    }
}

