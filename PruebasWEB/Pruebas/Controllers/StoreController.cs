using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pruebas.Models;
using Pruebas.ViewModels;

namespace Pruebas.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {
        ListProducto Productos = new ListProducto();
        ListUser Usuarios = new ListUser();
        [HttpGet("PerfilUsuario")]
        //https://localhost:5001/Store/PerfilUsuario
        public IActionResult PerfilUsuario()
        {
            Usuario user1 = new Usuario()
            {
                user = "Tocayo",
                nombre = "Tocayo",
                cedula = 12345,
                Tipo = "Cliente",
                Direccion = "Calle 10 4 53",
                telefono = 4321,
                metodoPago = "Efecty"
            };
           
            return View(user1);
        }
        //https://localhost:5001/Store/EditarUsuario
        [HttpGet("EditarUsuario/{userName}")]
        public IActionResult EditarUsuario(string userName)
        {
            Usuario jaimito = new Usuario()
            {
                user = "Tocayo",
                nombre = "Tocayo",
                cedula = 12345,
                Tipo = "Cliente",
                Direccion = "Calle 10 4 53",
                telefono = 4321,
                metodoPago = "Efecty"
            };
            Usuarios.ListaUsuarios.Add(jaimito);
            Usuario encontrado = Usuarios.ListaUsuarios.First(j => j.user == userName);

            return View(encontrado);
        }

        [HttpPost("ReemplazarUsuario")]
        public IActionResult ReemplazarUsuario(Usuario user1)
        {
            return Ok(user1.nombre);
        }

        //https://localhost:5001/Store/CrearProducto
        [HttpGet("CrearProducto")]

        public IActionResult CrearProducto()
        {
            return View();
        }

        [HttpPost("GuardarProducto")]

        public IActionResult GuardarProducto(Producto produc)
        {
            Productos.ListaProductos.Add(produc);
            mensaje mess = new mensaje();
            mess.Mess = produc.Nombre;
            return RedirectToAction("Ingreso","Ingreso",mess);
        }
    }

}
