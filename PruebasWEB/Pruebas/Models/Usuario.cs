using System;

namespace Pruebas.Models
{
    public class Usuario
    {
        public string user { get; set; }

        public string contraseña {get; set;}
        public string nombre { get; set; }
        public int cedula { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }
        public int telefono { get; set; }
        public string metodoPago {get;set;}
    }
}