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
    public class IngresoController : Controller
    {
        
        ListUser ListaDeUsuarios = new ListUser();
        public string mensaje;
        Usuario Pepito = new Usuario()
        {
            user = "Raul",
            contraseña = "Raul123"
        };
        //https://localhost:5001/Ingreso/Ingreso
        [HttpGet("Ingreso")]
        public IActionResult Ingreso(mensaje Dato)
        {
            ViewData["Message"] = Dato.Mess;
            return View();
        }
        public void añadir(Usuario Pepis)
        {
            ListaDeUsuarios.ListaUsuarios.Add(Pepis);
        }
        [HttpPost("Validar")]
        public IActionResult Validar(Usuario user1)
        {
            añadir(Pepito);
            mensaje mesenger = new mensaje();
            try
            {
                Usuario user2 = ListaDeUsuarios.ListaUsuarios.First(j => j.user == user1.user);
                if (user2.contraseña == user1.contraseña)
                {
                    mesenger.Mess ="Entró";
                    return RedirectToAction("Ingreso","Ingreso",mesenger);
                }
                mesenger.Mess = "ConstraseñaInválida";
            }
            catch(InvalidOperationException)
            {
                mesenger.Mess = "Usuario Inválido";
            } 
            return RedirectToAction("Ingreso","Ingreso",mesenger);
            
        }
        //https://localhost:5001/Ingreso/CrearUsuario
        [HttpGet("CrearUsuario")]
        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost("GuardarUsuario")]

        public IActionResult GuardarUsuario(Usuario user1)
        {
            ListaDeUsuarios.ListaUsuarios.Add(user1);
            try
            {
                Usuario user2 = ListaDeUsuarios.ListaUsuarios.First(j => j.user == user1.user);
                //return Ok("Se guardó");
                return RedirectToAction("Index","Home");
            }
            catch(InvalidOperationException)
            {
                return Ok("No se guardó");
            }
            //return RedirectToAction("Index","Home");
        }

    }

}
