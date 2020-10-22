using System;

namespace Practica1.IngresoSistema
{
    public class Verificar
    {
        private (string, string) datos = ("Juan","Jfrm0612"); //Usuario único
        public (string, string) datosperty
        {
            get { return datos; }
        }
        
        public bool verificarDatos(Usuario fulano)
        {
            if(fulano.Nombre == datos.Item1 && fulano.contraseña == datos.Item2)
            {
                return true;
            }
            return false;
        }
    }
}