using System;
using Practica1.Plantas;
using Practica1.Especies;
using Practica1.Sectores;
using Practica1.SistemasHidro;

namespace Practica1.Control
{
    public class datos
    {
        public int menu()
        {
            int opc;
            Console.Clear();
            Console.WriteLine("Estas son las opciones disponibles");
            Console.WriteLine("1. Crear Cultivo");
            Console.WriteLine("2. Crear Planta");
            Console.WriteLine("3. Consultar Cultivo");
            Console.WriteLine("4. Consultar semillas y producción");
            Console.WriteLine("5. Cosechar");
            Console.WriteLine("6. Consultar Estado Robot");
            Console.WriteLine("7. Buscar Robot");
            Console.WriteLine("0. Salir");
            Console.Write("Opción : ");
            opc = Int32.Parse(Console.ReadLine());
            return opc;
        }

        public void pedirDatosPlanta(ref Planta matica)
        {
            Console.Clear();
            matica = new Planta();
            Console.WriteLine("Ingrese el nombre de la planta");
            Console.Write("Nombre: ");
            matica.nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la necesidad de Luz de la planta");
            Console.Write("Necesidad de luz en horas por día: ");
            matica.necesidadLuz = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la producción total de la planta");
            Console.Write("Producción total de la planta en Kg: ");
            matica.produccionTotal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese las semillas de la planta");
            Console.Write("Cantidad total de semillas de la planta en #: ");
            matica.semillas = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la tasa de crecimiento");
            Console.Write("Tasa de crecimiento de la planta 1-5 : ");
            matica.tasaCrecimiento = Int32.Parse(Console.ReadLine());
        }

        public void imprimirCatalogo(catalogo lista)
        {
            Console.Clear();
            Console.WriteLine("---Nombre---||Necesidad Luz||Producción Total||Semillas||Tasa de Crecimiento||");
            foreach(Planta matica in lista.plantasDisponibles)
            {
                Console.WriteLine("{0,12}||{1,13}||{2,16}||{3,8}||{4,19}||",matica.nombre,matica.necesidadLuz.ToString(),matica.produccionTotal.ToString(),matica.semillas.ToString(),matica.tasaCrecimiento.ToString());
            }
        }
        public void imprimirAlmacen(Bodega almacen)
        {
            Console.Clear();
            Console.WriteLine("---Nombre---||Cantidad Semillas||Cantidad producción||");
            foreach(Tuple<Planta, int, int> tupla in almacen.semillasYproduccion)
            {
                Console.WriteLine("{0,12}||{1,17}||{2,19}||",tupla.Item1.nombre,tupla.Item2,tupla.Item3);
            }
        }

        public void imprimirGranja(Granja finca)
        {
            Console.WriteLine("Código||Ocupacion||Minuto Siembra||Nivel Ocupacion||----Estado----||----Planta----");
            foreach(Tuple<hidroponico,string,string> hidro in finca.cultivos)
            {
                Console.WriteLine("{0,6}||{1,9}||{2,14}||{3,15}||{4,14}||{5,14}",hidro.Item1.cod,hidro.Item1.ocupacion,hidro.Item1.minutoSiembra,hidro.Item1.nivelOcupacion,hidro.Item2,hidro.Item3);
            }
        }
    }
}