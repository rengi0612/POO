using System;

namespace Excepciones.CustomExceptions
{
    public class LoseForUsed : Exception
    {
        public LoseForUsed() { }
        public LoseForUsed(string Message) : base(String.Format("Ta lleno", Message)) { }
    }
}