using System;
using Pruebas.Models;
using System.Collections.Generic;

namespace Pruebas.ViewModels
{
    public class ListProducto
    {
        public List<Producto> ListaProductos { get; set; }

        public ListProducto()
        {
            ListaProductos = new List<Producto>();
        }
    }
}