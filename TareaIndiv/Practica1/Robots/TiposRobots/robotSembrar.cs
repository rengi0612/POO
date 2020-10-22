using System;
using Practica1.Robots;
using Practica1.Sectores;
using Practica1.Especies;
using Practica1.Plantas;
using System.Linq;
using Practica1.SistemasHidro;

namespace Practica1.Robots.TiposRobots
{
    public class robotSembrar : robotPadre
    {
        public override int verificarBateria() //niveles batería 1-10: bajo 10-20:medio 20-30:alto
        {
            if (this.bateria<18) return 1;
            else if (this.bateria>=18 && this.bateria<20) return 2;
            else return 3;
        }
        public override bool verificarEstado() 
        {
             if (this.estado<3) return true;
             else return false;
            
        }

        public void sacarCode()
        {
            this.codigo = 4321;
        }

        public bool sembrar(ref Granja finca, catalogo matitas, ref Bodega almacen)
        {
            Console.Write("Escriba el nombre de la planta que desea cultivar: ");
            string nombreP = Console.ReadLine();
            if(matitas.verificarDisp(nombreP))
            {
                Tuple<Planta, int, int> busqueda = almacen.semillasYproduccion.First(j => j.Item1.nombre == nombreP);
                Console.Write("Escriba la cantidad de semillas que desea sembrar que sean menores o iguales a {0}: ",busqueda.Item2);
                int sem = Int32.Parse(Console.ReadLine());
                if(almacen.verificarSemillas2(nombreP,sem))
                {
                    Planta busca = matitas.plantasDisponibles.First(j => j.nombre == nombreP);
                    if(finca.añadir2(busca,sem))
                    {
                        
                        int semi = busqueda.Item2;
                        int prod = busqueda.Item3;
                        almacen.semillasYproduccion.Remove(busqueda);
                        almacen.semillasYproduccion.Add(new Tuple<Planta, int, int> (busca, semi-sem, prod));
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No se pude crear el cultivo por falta de espacio");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("No hay suficientes semillas para cultivar lo que desea");
                    return false;
                }

            }
            else{
                Console.WriteLine("No se encontró la planta en el catálogo");
                return false;
            }
        }
    }
}
