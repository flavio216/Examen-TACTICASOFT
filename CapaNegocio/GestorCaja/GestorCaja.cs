using CapaDatos;
using CapaNegocio.ModelCaja;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio.GestorCaja
{
    public class GestorCaja
    {
       
        public int insertarVenta(Ventas v)
        {
            int MaxId = 0;
            ConexionBD conex = new ConexionBD();

            try
            {
                string sql = " insert into ventas values (@idcliente, @fecha,@total) select @@identity";
                SqlCommand cmd = new SqlCommand(sql, conex.conexion);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idcliente", v.IdCliente);
                cmd.Parameters.AddWithValue("@fecha", v.Fecha);
                cmd.Parameters.AddWithValue("@total", v.Total);
               // cmd.Parameters.Add("@@identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                conex.Conectar();
                cmd.ExecuteNonQuery();


                SqlCommand id = new SqlCommand("select @@identity from ventas", conex.conexion);
                
                MaxId = Convert.ToInt32(id.ExecuteScalar());
               
                //resto codigo

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se ha podido insertar.",
                    "Aviso");
                MessageBox.Show(ex.Message, "MENSAJE DE ERROR");
            }
            finally
            {
                conex.Desconectar();
            }
            return MaxId;
         
        }
        public bool InsertarDetalle(DetalleVentas dv)
        {
            bool resultado = false;
            ConexionBD conex = new ConexionBD();

            try
            {
                string sql = " insert into ventasItems values (@idVenta, @idProducto, @precioUnitario,@cantidad,@precioTotal)";
                SqlCommand cmd = new SqlCommand(sql, conex.conexion);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idVenta", dv.IdFactura);
                cmd.Parameters.AddWithValue("@idProducto", dv.IdProducto);
                cmd.Parameters.AddWithValue("@precioUnitario", dv.PrecioUnitario);
                cmd.Parameters.AddWithValue("@cantidad", dv.Cantidad);
                cmd.Parameters.AddWithValue("@precioTotal", dv.PrecioTotal);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;

                conex.Conectar();
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se ha podido insertar.",
                    "Aviso");
                MessageBox.Show(ex.Message, "MENSAJE DE ERROR");
                resultado = false;
            }
            finally
            {
                conex.Desconectar();
            }

            return resultado;
        }
        
    }
}
