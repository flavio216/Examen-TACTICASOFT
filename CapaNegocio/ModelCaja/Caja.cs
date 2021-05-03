using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.ModelCaja
{
    public class Caja
    {
        private int codigo;
        private string nombre;
        private float precio;
        private string categoria;
        private int cantidad;

        public Caja(int codigo, string nombre, float precio, string categoria, int cantidad)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
            this.cantidad = cantidad;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
