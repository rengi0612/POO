using System;
using Granjirilla.Users;
using Granjirilla.Fachada;
namespace Granjirilla.ingresar
{
    public class ingreso{
        #region Properties
        private string user { get; set;}
        private string password { get; set;}
        #endregion Properties

        #region Methods
        public void ingresar(){   
            Admin admin = new Admin();
            Console.Write("Ingrese usuario: ");
            user = Console.ReadLine();
            Console.Write("Ingrese contraseña: ");
            password = Console.ReadLine();
            
            if(admin.Validar(user,password)){
                Sis_control sistema = new Sis_control();
                sistema.inicio();
            }
            else{
                Console.Clear();
                Console.WriteLine("Usuario y/o contraseña incorrectos,  Ingrese de nuevo:\n");

                ingresar();
            }

        }
        
        #endregion  Methods

    }
}