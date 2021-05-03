using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.ModelCaja
{
    public class DetalleVentas
    {
        private int id;
        private int idFactura;
        private int idProducto;
        private float precioUnitario;
        private int cantidad;
        private float precioTotal;

        public DetalleVentas(int id, int idFactura, int idProducto, float precioUnitario, int cantidad, float precioTotal)
        {
            this.id = id;
            this.idFactura = idFactura;
            this.idProducto = idProducto;
            this.precioUnitario = precioUnitario;
            this.cantidad = cantidad;
            this.precioTotal = precioTotal;
        }

        public int Id { get => id; set => id = value; }
        public int IdFactura { get => idFactura; set => idFactura = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float PrecioTotal { get => precioTotal; set => precioTotal = value; }
    }
}
