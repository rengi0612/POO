using System;

namespace Pruebas.Models
{
    public class Usuario
    {
        public long ID { get; set; }
        public string usuario { get; set; }

        public string contraseña {get; set;}
        public string nombre { get; set; }
        public long cedula { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }
        public long telefono { get; set; }
        public string metodoPago {get;set;}
    }
}