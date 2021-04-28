using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Clientes
    {
        private int id;
        private string cliente;
        private string telefono;
        private string correo;

        public Clientes(int id, string cliente, string telefono, string correo)
        {
            this.id = id;
            this.cliente = cliente;
            this.telefono = telefono;
            this.correo = correo;
        }

        public int Id { get => id; set => id = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
