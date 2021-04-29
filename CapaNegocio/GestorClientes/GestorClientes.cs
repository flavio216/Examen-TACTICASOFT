using CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;
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
        public bool EditarCliente(Clientes c)
        {
            bool resultado = false;
            ConexionBD bd = new ConexionBD();
            try
            {
                string sql = "update clientes set cliente = @cliente, telefono = @telefono, correo = @correo where id = @id ";
                SqlCommand cmd = new SqlCommand(sql, bd.conexion);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", c.Id);
                cmd.Parameters.AddWithValue("@cliente", c.Cliente);
                cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@correo", c.Correo);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                bd.Conectar();
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show("No se ha podido actualizar ", " Aviso");
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

