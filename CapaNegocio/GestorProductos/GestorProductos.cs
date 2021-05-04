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
    public class GestorProductos
    {
        public bool InsertarProducto(Producto p)
        {
            bool resultado = false;
            ConexionBD bd = new ConexionBD();

            try
            {
                string consulta = "INSERT INTO Productos VALUES ( @nombre, @precio, @categoria, @estado)";
                SqlCommand cmd = new SqlCommand(consulta, bd.conexion);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@categoria", p.Categoria);
                cmd.Parameters.AddWithValue("@estado", 1);


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
    
        public DataTable ConsultarProductos()
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD bd = new ConexionBD();
                bd.Conectar();
                bd.pComando.CommandText = " select id,nombre,precio,categoria from productos where estado = 1";
                dt.Load(bd.pComando.ExecuteReader());
                bd.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se podido establecer conexión con la base de datos, por favor contacte al administrador" +
                    "del sistema." + ex) ;
                return dt;
            }

        }
        public DataTable ConsultarProductosSinStock()
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD bd = new ConexionBD();
                bd.Conectar();
                bd.pComando.CommandText = " select id,nombre,precio,categoria from productos where estado = 0";
                dt.Load(bd.pComando.ExecuteReader());
                bd.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se podido establecer conexión con la base de datos, por favor contacte al administrador" +
                    "del sistema." + ex);
                return dt;
            }

        }
        public bool EditarProducto(Producto p)
        {
            bool resultado = false;
            ConexionBD bd = new ConexionBD();
            try
            {
                string sql = "update productos set nombre = @nombre, precio = @precio, categoria = @categoria where id = @id ";
                SqlCommand cmd = new SqlCommand(sql, bd.conexion);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@categoria", p.Categoria);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                bd.Conectar();
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show("No se ha podido actualizar ", " Aviso"+ex);
            }
            finally
            {
                bd.Desconectar();
            }
            return resultado;
        }
    }
}
