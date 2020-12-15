using System;
using Microsoft.AspNetCore.Http;
namespace Pruebas.Models
{
    public class Producto
    {
        public long ID { get; set; }
        public string Nombre { get; set; }
        public string Imagen {get; set;}
        public string Categoria { get; set; }
        public long Precio { get; set; }
        public long Cantidad { get; set; }
        public long Organicidad { get; set; }
        public long Estado { get; set; }
    }
}