using System;

namespace Excepciones.CustomExceptions
{
    public class LoseForUsed : Exception
    {
        public LoseForUsed() { }
        public LoseForUsed(string Message) : base(String.Format("la seleccion {0} ya existe", Message)) { }
    }
}