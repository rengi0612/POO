using System;
namespace Granjirilla.Users
{
    public class Admin{
        #region Properties
        private Tuple<string,string> usuario=new Tuple<string, string>("lulin", "LULEN8");

        #endregion Properties

        #region Methods
        public bool Validar(string user,string pasword)
        {if (usuario.Item1==user && usuario.Item2==pasword){return true;}return false;}
        #endregion  Methods

    }
}