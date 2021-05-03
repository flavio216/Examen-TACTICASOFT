using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.ModelCaja
{
    public class Ventas
    {
        private int id;
        private int idCliente;
        private DateTime fecha;
        private float total;

        public Ventas(int id, int idCliente, DateTime fecha, float total)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.fecha = fecha;
            this.total = total;
        }

        public int Id { get => id; set => id = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public float Total { get => total; set => total = value; }
    }
}
