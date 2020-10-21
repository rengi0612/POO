using System;

namespace Excepciones.CustomExceptions
{
    public class LoseForWException : Exception
    {
        public LoseForWException() { }
        public LoseForWException(string Message) : base(String.Format("{0}",Message)) { }
    }
}