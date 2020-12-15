using System;
using Pruebas.Models;
using System.Collections.Generic;

namespace Pruebas.ViewModels
{
    public class ListUser
    {
        public List<Usuario> ListaUsuarios { get; set; }

        public ListUser()
        {
            ListaUsuarios = new List<Usuario>();
        }
    }
}
