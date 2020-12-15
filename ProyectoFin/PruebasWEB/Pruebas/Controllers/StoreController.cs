using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pruebas.Models;
using Pruebas.ViewModels;
using Microsoft.AspNetCore.Hosting;  
using System.IO;
using Microsoft.EntityFrameworkCore;
using Pruebas.Services;

namespace Pruebas.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {
      
        #region Properties
        private readonly PruebasWEBDBContext dBContext;
        private readonly IWebHostEnvironment webHostEnvironment; 
        #endregion

        #region Constructor
        /*public StoreController(PruebasWEBDBContext dBContext)
        {
            this.dBContext = dBContext;
        }*/ 
        public StoreController(IWebHostEnvironment hostEnvironment,PruebasWEBDBContext dBContext)  
        {  
            
            webHostEnvironment = hostEnvironment;  
            this.dBContext = dBContext;
        }  
        #endregion Constructor
  
        public ListProducto Productos = new ListProducto();
        //ListUser Usuarios = new ListUser();
        [HttpGet("PerfilUsuario/{id}")]
        //https://localhost:5001/Store/PerfilUsuario
        public async Task<IActionResult> PerfilUsuario(long id)
        {
            /*Usuario user1 = new Usuario()
            {
                usuario = "Tocayo",
                nombre = "Tocayo",
                cedula = 12345,
                Tipo = "Cliente",
                Direccion = "Calle 10 4 53",
                telefono = 4321,
                metodoPago = "Efecty"
            };*/
            try
            {
                Usuario usuario = await dBContext.Usuarios.FindAsync(id);
                if (usuario == null)
                    throw new Exception("El usuario no existe");
                return View(usuario);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
           
        }
        //https://localhost:5001/Store/EditarUsuario
        [HttpGet("EditarUsuario/{id}")]
        public async Task<IActionResult> EditarUsuario(long id)
        {
            /*Usuario jaimito = new Usuario()
            {
                usuario = "Tocayo",
                nombre = "Tocayo",
                cedula = 12345,
                Tipo = "Cliente",
                Direccion = "Calle 10 4 53",
                telefono = 4321,
                metodoPago = "Efecty"
            };*/
            /*Usuarios.ListaUsuarios.Add(jaimito);
            Usuario encontrado = Usuarios.ListaUsuarios.First(j => j.usuario == userName);*/
            try
            {
                Usuario usuario = await dBContext.Usuarios.FindAsync(id);
                if (usuario == null)
                    throw new Exception("El usuario no existe");
                return View(usuario);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            //return View(encontrado);
        }

        [HttpPost("ReemplazarUsuario")]
        public async Task<IActionResult> ReemplazarUsuario(Usuario user1)
        {
            try
            {
                Usuario usuarioOrigin = await dBContext.Usuarios.FindAsync(user1.ID);
                usuarioOrigin.Direccion = user1.Direccion;
                usuarioOrigin.telefono = user1.telefono;
                usuarioOrigin.metodoPago = user1.metodoPago;
                dBContext.Entry(usuarioOrigin).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                
                return Redirect("/Store/PerfilUsuario/" + usuarioOrigin.ID.ToString());
                //return Ok(user1.ID);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
            //return Ok(user1.nombre);
        }
        [HttpGet("EditarProducto/{idusuario}/{idproducto}")]
        public async Task<IActionResult> EditarProducto(long idusuario, long idproducto)
        {
            
            try
            {
                Producto usuario = await dBContext.Productos.FindAsync(idproducto);
                if (usuario == null)
                    throw new Exception("El producto no existe");
                return View(usuario);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            //return View(encontrado);
        }
        [HttpPost("ReemplazarProducto")]
        public async Task<IActionResult> ReemplazarProducto(Producto user1)
        {
            try
            {
                Producto usuarioOrigin = await dBContext.Productos.FindAsync(user1.ID);
                usuarioOrigin.Precio = user1.Precio ;
                usuarioOrigin.Cantidad = user1.Precio ;
                dBContext.Entry(usuarioOrigin).State = EntityState.Modified;
                
                
                Proceso per =dBContext.Procesos.First(j=> j.IDproducto== usuarioOrigin.ID);
                   
                await dBContext.SaveChangesAsync();
                return Redirect("/Store/MostrarProductos/" + per.IDusuario.ToString());
                //return Ok(user1.ID);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
            //return Ok(user1.nombre);
        }
        //https://localhost:5001/Store/CrearProducto
        [HttpGet("CrearProducto/{id}")]

        public IActionResult CrearProducto(long id)
        {
            ViewData["ID"]=id;
            return View();
        }

        [HttpPost("GuardarProducto/{id}")]

        public async Task<IActionResult> GuardarProducto(Productofile produc,long id)
        {
            
            mensaje mess = new mensaje();
            //mess.Mess = produc.Nombre;
            //produc.Imagen=UploadedFile(produc);
            Producto product1 = new Producto()
            {
                Nombre = produc.Nombre,
                Imagen = UploadedFile(produc),
                Categoria = produc.Categoria,
                Precio = produc.Precio,
                Cantidad = produc.Cantidad,
                Organicidad = produc.Organicidad,
                Estado = produc.Estado
            };
            dBContext.Productos.Add(product1);
           

            await dBContext.SaveChangesAsync();

            product1 = dBContext.Productos.First(j=>j.Nombre ==produc.Nombre);
            Proceso proce=new Proceso()
            {
                IDusuario=id,
                IDproducto=product1.ID,
                Estado="Venta",
                Cantidad =product1.Cantidad
            };
            dBContext.Procesos.Add(proce);
            await dBContext.SaveChangesAsync();
            return Redirect("/Store/MostrarProductos/"+id);
        }
        //https://localhost:5001/Store/MostrarProductos
        [HttpGet("MostrarProductos/{id}")]
        public async Task<IActionResult> MostrarProductos(long id)
        {
            
            try
            {
                Usuario usuario = await dBContext.Usuarios.FindAsync(id);
                if (usuario == null)
                    throw new Exception("Un error ocurrio durante el proceso");
                ListProducto vm = new ListProducto();
                ListProceso pr = new ListProceso();
                Producto prtemp = new Producto();
                ViewData["ID"]=id;
                if(usuario.Tipo=="Comprador")
                {
                    ViewData["Anuncio"]="Agregar al carrito";
                    ViewData["opciones"] = "AgregarCarrito";
                    vm.ListaProductos=  await dBContext.Productos.ToListAsync();
                }
                if(usuario.Tipo=="Vendedor")
                {
                    ViewData["Anuncio"]="Editar";
                    ViewData["opciones"] = "EditarProducto";
                    pr.ListaProcesos =await dBContext.Procesos.Where(j=> j.IDusuario== id).ToListAsync();
                    foreach(Proceso proces in pr.ListaProcesos){
                    prtemp = await dBContext.Productos.FindAsync(proces.IDproducto);
                    vm.ListaProductos.Add(prtemp);
                    }
                }
                
                return View(vm);
                
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            

            /*ListProducto Productines = new ListProducto();
            Producto product1 = new Producto()
            {
                Nombre = "Raqueta",
                Precio = 320000,
                Imagen= "Balon1.jpg"                
            };
            Productines.ListaProductos.Add(product1);*/
           
        }
        //https://localhost:5001/Store/VerCarrito
        [HttpGet("VerCarrito/{id}")]
        public async Task<IActionResult> VerCarrito(long id)
        {
            ViewData["ID"]=id;
            ListProducto vm = new ListProducto();
            ListProceso pr = new ListProceso();
            Producto prtemp = new Producto();
            ViewData["Anuncio"]="Editar";
            ViewData["opciones"] = "EditarProducto";
            pr.ListaProcesos =await dBContext.Procesos.Where(j=> j.IDusuario== id && j.Estado=="Carrito").ToListAsync();
            foreach(Proceso proces in pr.ListaProcesos){
                prtemp = await dBContext.Productos.FindAsync(proces.IDproducto);
                vm.ListaProductos.Add(prtemp);
                }
            return View(vm);
            
        }

        private void guardar(Producto produc3){
            
            this.Productos.ListaProductos.Add(produc3);
        }
        private string UploadedFile(Productofile model)  
        {  
            string uniqueFileName = null;  
  
            if (model.ProfileImage != null)  
            {  
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath,"Imagenes","Products");  
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;  
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);  
                using (var fileStream = new FileStream(filePath, FileMode.Create))  
                {  
                    model.ProfileImage.CopyTo(fileStream);  
                }  
            }  
            return uniqueFileName;  
        }
        [HttpGet("menuComprador")]
        public IActionResult menuComprador(mensaje id1)
        {
            ViewData["ID"] = id1.id;
            return View();
        }
        [HttpGet("menuVendedor")]
        public IActionResult menuVendedor(mensaje id1)
        {
            ViewData["ID"] = id1.id;
            return View();
        }
        /*public IActionResult menuVendedor()
        {
            return View();
        }*/
        [HttpGet("AgregarCarrito/{idusuario}/{idproducto}")]
        public async Task<IActionResult> AgregarCarrito(long idusuario, long idproducto)
        {
            Proceso proce = new Proceso()
            {
                IDusuario = idusuario,
                IDproducto = idproducto,
                Estado = "Carrito",
                Cantidad = 1
            };
            dBContext.Procesos.Add(proce);
            await dBContext.SaveChangesAsync();
            return Redirect("/Store/MostrarProductos/"+ idusuario.ToString());
        }
    }  
}  