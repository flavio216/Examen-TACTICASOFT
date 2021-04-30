using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Productos
    {
        private int id;
        private string nombre;
        private float precio;
        private string categoria;
        private int estado;

        public Productos(int id, string nombre, float precio, string categoria, int estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
            this.estado = estado;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
