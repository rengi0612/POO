using System;
using Practica1.IngresoSistema;

namespace Practica1.IngresoSistema
{
    public class Ingreso
    {
        public void iniciarSistema()
        {
            Usuario user = new Usuario();
            Console.WriteLine("Bienvenido a su granja hidropónica");
            Console.WriteLine("Por favor Ingrese sus datos");
            Console.Write("Usuario: ");
            user.Nombre = Console.ReadLine();
            Console.Write("Contraseña: ");
            user.contraseña = Console.ReadLine();
            Console.Clear();
            if(verificarUsuario(user))
            {
                Console.WriteLine("Ingresó");
            }
            else
            {
                Console.WriteLine("No se pudo ingresar");
                iniciarSistema();
            }
        }

        private bool verificarUsuario(Usuario fulano)
        {   
            Verificar verificador =  new Verificar();
            bool bandera = verificador.verificarDatos(fulano);
            return bandera;
        }

    }
}