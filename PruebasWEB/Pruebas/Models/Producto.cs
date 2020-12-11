using System;

namespace Pruebas.Models
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Imagen {get; set;}
        public string Categoria { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public bool Organicidad { get; set; }
        public bool Estado { get; set; }
    }
}