using System;
using Microsoft.AspNetCore.Http;
namespace Pruebas.Models
{
    public class Proceso
    {
        public long ID { get; set; }
        public long IDusuario { get; set; }
        public long IDproducto { get; set; }
        public string Estado { get; set; }
        public long Cantidad {get; set;}
        public DateTime Fecha { get; set; }
        
    }
}