using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Producto
    {
        private int id;
        private string nombre;
        private float precio;
        private string categoria;
 

        public Producto(int id, string nombre, float precio, string categoria)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Categoria { get => categoria; set => categoria = value; }
    }
}
