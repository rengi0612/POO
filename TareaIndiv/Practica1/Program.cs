using System;
using Practica1.IngresoSistema;
using Practica1.Control;
using Practica1.Robots.TiposRobots;

namespace Practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UnidadControl Sistema = new UnidadControl();
            Sistema.inicio();


        }
    }
}
