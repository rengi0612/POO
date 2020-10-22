using System;
using System.Linq;
using Practica1.IngresoSistema;
using Practica1.Plantas;
using Practica1.Especies;
using Practica1.Sectores;
using Practica1.SistemasHidro;
using System.Collections.Generic;
using Practica1.Robots;
using Practica1.Robots.TiposRobots;

namespace  Practica1.Control
{
    public class UnidadControl
    {
        public datos maquina =  new datos();
        public catalogo matas =  new catalogo();
        public Granja finca = new Granja();
        public Bodega almacen = new Bodega();        
        public robotCosecha cosechador = new robotCosecha();
        public robotSembrar sembrador = new robotSembrar();
        public manteYrecarga zona = new manteYrecarga();
        public void inicio()
        {
            Ingreso Sistema = new Ingreso();
            Sistema.iniciarSistema();
            matas.iniciarLista();
            finca.inicializar();
            almacen.inicializar();
            cosechador.sacarCode();
            sembrador.sacarCode();
            zona.inicializar();
            Console.Clear();
            funciones();
        }

        private void funciones()
        {
            Console.Clear();
            string salir;
            switch(maquina.menu())
            {
                case 1:
                    Console.WriteLine("Crear Cultivo");
                    maquina.imprimirCatalogo(matas);
                    sembrarRobot();
                    Console.WriteLine("Escriba lo que sea para continuar");
                    salir = Console.ReadLine();
                    funciones();
                    break;
                case 2:
                    Console.WriteLine("Crear planta");
                    crearPlanta(); 
                    funciones();
                    break;
                case 3:
                    Console.WriteLine("Consultar Cultivo");
                    consultarCultivo();
                    maquina.imprimirGranja(finca);
                    Console.WriteLine("Escriba lo que sea para continuar");
                    salir = Console.ReadLine();
                    funciones();
                    break;
                case 4:
                    Console.WriteLine("Consultar Semillas y producción");
                    maquina.imprimirAlmacen(almacen);
                    Console.WriteLine("Escriba lo que sea para continuar");
                    salir = Console.ReadLine();
                    funciones();
                    break;
                case 5:
                    Console.WriteLine("Cosechar");
                    Cosecha();
                    
                    Console.WriteLine("Escriba lo que sea para continuar");
                    salir = Console.ReadLine();
                    funciones();
                    break;
                case 6:
                    Console.WriteLine("Consultar estado Robot");
                    Console.Write("Desea consultar sembrador o cosechador: ");
                    consultarEstadoRobot(Console.ReadLine());
                    Console.WriteLine("Escriba lo que sea para continuar");
                    salir = Console.ReadLine();
                    funciones();
                    break;
                case 7:
                    Console.WriteLine("Buscar Robot");
                    if(zona.verificarRobot(sembrador.codigo))
                    {
                        Console.WriteLine("El robot sembrador está en recarga o mantenimiento, bateria {0} , estado {1}",sembrador.bateria,sembrador.estado);
                    }
                    else
                    {
                        Console.WriteLine("El robo sembrador está bien, bateria {0}, estado {1}",sembrador.bateria,sembrador.estado );
                    }
                    if(zona.verificarRobot(cosechador.codigo))
                    {
                        Console.WriteLine("El robot cosechador está en recarga o mantenimiento, bateria {0} , estado{1}",cosechador.bateria,cosechador.estado);
                    }
                    else
                    {
                        Console.WriteLine("El robo cosechador está bien, bateria {0}, estado {1}",cosechador.bateria,cosechador.estado );
                    }
                    Console.WriteLine("Escriba lo que sea para continuar");
                    salir = Console.ReadLine();
                    funciones();
                    break;
                default:
                    Console.WriteLine("Adiós");
                    Console.Clear();
                    break;
            }
        }

        public void crearPlanta()
        {
            Planta nueva = new Planta();
            maquina.pedirDatosPlanta(ref nueva);
            matas.guardarPlanta(nueva);
            almacen.llenar(nueva, nueva.semillas, 0);
        }

        private void consultarCultivo()
        {
            finca.actualizar(ref finca, matas);
        }

        private void Cosecha()
        {
            if(!zona.verificarRobot(cosechador.codigo))
            {
                if(cosechador.cosechar(ref finca,matas,ref almacen))
                {
                    cosechador.bateria -= 10;
                    cosechador.estado -= 2;
                    Console.WriteLine("Su robot ha cosechado");
                }
                else{
                    Console.WriteLine("Su robot no cosechó");
                }
            }
            else
            {
                Console.WriteLine("El robot todavía está en recarga o mantenimiento");
                return;
            }
            

        }

        private void sembrarRobot()
        {
            if(!zona.verificarRobot(sembrador.codigo))
            {
                if(sembrador.sembrar(ref finca,matas,ref almacen))
                {
                    sembrador.bateria -= 7;
                    sembrador.estado -= 3;
                    Console.WriteLine("Su robot ha sembrado");
                }
                else{
                    Console.WriteLine("Su robot no sembró");
                }
            }
            else{
                Console.WriteLine("El robot todavía está en recarga o mantenimiento");
                return;
            }
            
        }

        private void consultarEstadoRobot(string opc)
        {
            if(opc == "cosechador"){
                if(cosechador.verificarBateria() == 1)
                {
                    Console.WriteLine("Necesita recargar, será mandado a Recargar");
                    Tuple<robotPadre,string,int> zonita = zona.estaciones.First(j => j.Item2 == "prob1" || j.Item2=="prob2");
                    zona.estaciones.Remove(zonita);
                    zona.llenar(cosechador,"Batería");
                }
                else if (cosechador.verificarBateria() == 2)
                {
                    Console.WriteLine("Batería intermedia,con un nivel de {0}",cosechador.bateria);
                }
                else
                {
                    Console.WriteLine("Batería Full, con un nivel de {0}",cosechador.bateria);
                }

                if(cosechador.verificarEstado())
                {
                    Console.WriteLine("El robot necesita mantenimiento, será mandado a reparar");
                    Tuple<robotPadre,string,int> zonita = zona.estaciones.First(j => j.Item2 == "prob1" || j.Item2=="prob2");
                    zona.estaciones.Remove(zonita);
                    zona.llenar(cosechador,"Mantenimiento");
                }
                else
                {
                    Console.WriteLine("El robot está en buen estado, con un nivel de {0}",cosechador.estado);
                }
            }
            else
            {
                if(sembrador.verificarBateria() == 1)
                {
                    Console.WriteLine("Necesita recargar, será mandado a Recargar");
                    Tuple<robotPadre,string,int> zonita = zona.estaciones.First(j => j.Item2 == "prob1" || j.Item2=="prob2");
                    zona.estaciones.Remove(zonita);
                    zona.llenar(sembrador,"Batería");
                }
                else if (sembrador.verificarBateria() == 2)
                {
                    Console.WriteLine("Batería intermedia,con un nivel de {0}",sembrador.bateria);
                }
                else
                {
                    Console.WriteLine("Batería Full, con un nivel de {0}",sembrador.bateria);
                }

                if(cosechador.verificarEstado())
                {
                    Console.WriteLine("El robot necesita mantenimiento, será mandado a reparar");
                    Tuple<robotPadre,string,int> zonita = zona.estaciones.First(j => j.Item2 == "prob1" || j.Item2=="prob2");
                    zona.estaciones.Remove(zonita);
                    zona.llenar(sembrador,"Mantenimiento");
                }
                else
                {
                    Console.WriteLine("El robot está en buen estado, con un nivel de {0}",sembrador.estado);
                }
            }
            
        }
    }
}