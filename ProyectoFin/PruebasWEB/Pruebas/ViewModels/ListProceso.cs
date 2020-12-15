using System;
using Pruebas.Models;
using System.Collections.Generic;

namespace Pruebas.ViewModels
{
    public class ListProceso
    {
        public List<Proceso> ListaProcesos { get; set; }

        public ListProceso()
        {
            ListaProcesos = new List<Proceso>();
        }
    }
}