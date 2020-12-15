using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pruebas.Models;
using Pruebas.Services;
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
            usuario = "Raul",
            contraseña = "Raul123"
        };
        #region Properties
        private readonly PruebasWEBDBContext dBContext;
        #endregion

        #region Constructor
        public IngresoController(PruebasWEBDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        #endregion Constructor
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
        public async Task<IActionResult> Validar(Usuario user1)
        {
            ListUser vm = new ListUser();
            mensaje mesenger = new mensaje();
            try
            {
                vm.ListaUsuarios = await dBContext.Usuarios.ToListAsync();
                Usuario user2 = vm.ListaUsuarios.First(j => j.usuario == user1.usuario);
                //Usuario user2 = ListaDeUsuarios.ListaUsuarios.First(j => j.usuario == user1.usuario);
                if (user2.contraseña == user1.contraseña)
                {
                    mesenger.id =user2.ID;
                    if(user2.Tipo=="Vendedor"){
                    return RedirectToAction("menuVendedor","Store",mesenger);
                    }
                    else if(user2.Tipo=="Comprador"){
                    return RedirectToAction("menuComprador","Store",mesenger);}
                    //return Ok(user2.telefono);
                }
                mesenger.Mess = "Constraseña Inválida";
            }
            catch(InvalidOperationException)
            {
                mesenger.Mess = "Usuario Inválido";
            } 
            return RedirectToAction("Ingreso","Ingreso",mesenger);
            
        }
        //https://localhost:5001/Ingreso/CrearUsuario
        [HttpGet("CrearUsuario")]
        public IActionResult CrearUsuario(mensaje dato)
        {
            ViewData["Message"] = dato.Mess;
            return View();
        }

        [HttpPost("GuardarUsuario")]

        public async Task<IActionResult> GuardarUsuario(Usuario user1)
        {
            ListUser vm = new ListUser();
            
            mensaje mesenger = new mensaje();
            try
            {
                vm.ListaUsuarios = await dBContext.Usuarios.ToListAsync();
                Usuario user2 = vm.ListaUsuarios.First(j => j.usuario == user1.usuario);
                mesenger.Mess = "Usuario no válido";
                return RedirectToAction("CrearUsuario","Ingreso",mesenger);
            }
            catch(InvalidOperationException)
            {
                dBContext.Usuarios.Add(user1);
                await dBContext.SaveChangesAsync();
                mesenger.Mess = "Se creó correctamete";
                return RedirectToAction("Ingreso","Ingreso",mesenger);
            }
            //return RedirectToAction("Index","Home");
        }
            //vm.ListaUsuarios = vm.ListaUsuarios.Where(u => u.Nombre == "Gustavo").ToList();

    }

}
