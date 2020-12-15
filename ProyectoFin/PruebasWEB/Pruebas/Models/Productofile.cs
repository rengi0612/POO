using System;
using Microsoft.AspNetCore.Http;
namespace Pruebas.Models
{
    public class Productofile: Producto
    {

        public IFormFile ProfileImage { get; set; }

    }
}