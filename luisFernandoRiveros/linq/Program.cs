using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using linq.Torneo;
using Newtonsoft.Json;
using linq.Observer;
using Excepciones.CustomExceptions;
namespace linq
{
    class Program
    {
        static IntOutdatas inout= new IntOutdatas(); 
        static Gestion_datos Data_bases=new Gestion_datos();
        static Seleccion Local=new Seleccion();
        static Seleccion Visitante=new Seleccion();
        static int opera;
        static string result;
        static Gestor_Selecciones Gestor = new Gestor_Selecciones ();
        static void menu(){
            Console.Clear();
            inout.escribir("Bienvenido al sistema de partidos de futbol ¿que desea hacer?\n");
            inout.escribir("1.Crear partido\n");
            inout.escribir("2.Crear seleccion\n");
            inout.escribir("3.Restiar sistema\n");
            inout.escribir("4.Salir\n");
            inout.escribir("Opcion:");

        }
        static string simular_Partido(Seleccion L,Seleccion V){
            Partido partido1 = new Partido(L, V);
            string resu= partido1.Resultado();
            int g1=partido1.EquipoLocal.Goles,g2=partido1.EquipoVisitante.Goles;
            int a1=partido1.EquipoLocal.Asistencias, a2=partido1.EquipoVisitante.Asistencias;
            bool s1=g1>g2,s2=g2>g1;
            
            //patron observer
            Gestor.Suscribe(Data_bases.Selecciones_json.First(s => s.Nombre == L.Nombre));
            Gestor.Notify(g1,a1,Convert.ToInt32(s1));
            Gestor.Unsuscribe(Data_bases.Selecciones_json.First(s => s.Nombre == L.Nombre));

            Gestor.Suscribe(Data_bases.Selecciones_json.First(s => s.Nombre == V.Nombre));
            Gestor.Notify(g2,a2,Convert.ToInt32(s2));
            Gestor.Unsuscribe(Data_bases.Selecciones_json.First(s => s.Nombre == V.Nombre));
            return resu;
        }
        static void crear_Partido(){
            inout.escribir("Nombre seleccion Local:");
            string loc=inout.Pedir_dato();
            try{Seleccion Local = Data_bases.Selecciones_json.First(s => s.Nombre == loc) as Seleccion;
                inout.escribir("Nombre seleccion Visitante:");
                string visit=inout.Pedir_dato();
                if(loc!=visit){
                    try{Seleccion Visitante = Data_bases.Selecciones_json.First(s => s.Nombre == visit) as Seleccion;
                    result=simular_Partido(Local,Visitante);
                    inout.escribir("El resultado del partido es "+result+"\n");}
                    catch(InvalidOperationException){inout.escribir("seleccion Visitante no existe\n");}}
                else{inout.escribir("La seleccion local no puede ser la misma que visitante\n");}
                }
            catch(InvalidOperationException){ inout.escribir("seleccion Local no existe\n");}
       


        }
        static void Main()
        {
            menu();
            
            try{
                opera=Int32.Parse(inout.Pedir_dato());
                switch(opera){
                case 1:
                    crear_Partido();
                    Data_bases.Guardar();
                    inout.escribir("Volver al menu(x)\n");
                    if(inout.Pedir_dato()=="x"){
                        Main();
                    }

                    break;
                case 2:
                    try{
                    Data_bases.Crear_seleccion();}
                    catch(LoseForUsed ex){inout.escribir(ex.Message);}
                    break;
                case 3:
                    Data_bases.Resetiar();
                    break;
                case 4:
                    inout.escribir("Muchas gracias por usar");
                    break;
                default:
                    Main();
                    break;
                }
            }
            catch(FormatException){inout.escribir("opcion invalida");}
            
            
            /*Gestion_datos Data_bases=new Gestion_datos();
            
            List<Seleccion> Selecciones = JsonConvert.DeserializeObject<List<Seleccion>>(File.ReadAllText("./selecciones.json"));
            Seleccion Francia = Selecciones.First(s => s.Nombre == "Francia") as Seleccion;
            Seleccion Argentina = Selecciones.FirstOrDefault(s => s.Nombre == "Argentina") as Seleccion;
            Partido partido1 = new Partido(Francia, Argentina);
            Console.WriteLine(partido1.Resultado());
            Data_bases.Crear_seleccion("ungria");*/
            

            //Seleccion FranciaDeserializada = JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText("./selecciones.json"));
           

            //List<Jugador> jugadoresDeserializados = JsonConvert.DeserializeObject<List<Jugador>>(File.ReadAllText("./jugadoresFrancia.json"));

            // Seleccion Argentina = Selecciones.FirstOrDefault(s => s.Nombre == "Argentina") as Seleccion;

            // Partido partido1 = new Partido(Francia, Argentina);
            // // partido1.Resultado();
            // Jugador jugador = new Jugador("Cristiano", 35, 7, 98, 40, 25, 3);
            // var jugadorSerializado = JsonConvert.SerializeObject(jugador);

            // File.WriteAllText("./jugadores.json", jugadorSerializado);

            // using (StreamWriter file = File.CreateText("./jugadores.json"))
            // {
            //     JsonSerializer serializer = new JsonSerializer();
            //     serializer.Serialize(file, jugadorSerializado);
            // }

            // Jugador jugador2 = JsonConvert.DeserializeObject<Jugador>(File.ReadAllText("./jugadores.json"));

            // using (StreamReader file = File.OpenText("./jugadores.json"))
            // {
            //     JsonSerializer serializer = new JsonSerializer();
            //     Jugador jugador2  = (Jugador)serializer.Deserialize(file, typeof(Jugador));
            //     Console.WriteLine(jugador2.Nombre);
            // }

            // List<String> Nombres = new List<string>();

            // foreach (Seleccion seleccion in Selecciones)
            // {
            //     if (seleccion.Nombre == "Francia")
            //     {
            //         foreach(Jugador jugador in seleccion.Jugadores)
            //         {
            //             Nombres.Add(jugador.Nombre);
            //         }
            //     }
            // }

            // Seleccion s = Selecciones.Where(s => s.Nombre == "Francia").ToList<Seleccion>()[0];
            // Seleccion francia = Selecciones.First(s => s.Nombre == "Francia") as Seleccion;
            // List<String> nombres2 = francia.Jugadores.Select(jugador => jugador.Nombre).ToList();

            // List<String> nombres3 = Selecciones.First(s => s.Nombre == "Francia")
            //                                    .Jugadores.Select(jugador => jugador.Nombre).ToList();

            // Jugador últimoJugador = francia.Jugadores.First(j => j.Posicion == 11);

            // Jugador jugador33 = francia.Jugadores.FirstOrDefault(j => j.Edad == 33);
            // Jugador jugador332 = francia.Jugadores.LastOrDefault(j => j.Edad == 33);

            // Seleccion Colombia = Selecciones.FirstOrDefault(s => s.Nombre == "Colombia") as Seleccion;
            // List<Jugador> JugadoresViejos = Colombia.Jugadores.Where(j => (j.Edad >= 26 && j.Edad <= 34)).ToList<Jugador>();

            // List<Jugador> JugadoresViejos2 = Colombia.Jugadores.Where(j => j.Edad >= 26)
            //                                                    .Where(j => j.Edad <= 33).ToList<Jugador>();

            // Seleccion Argentina = Selecciones.FirstOrDefault(s => s.Nombre == "Argentina") as Seleccion;
            // bool HayJugadorPro = Argentina.Jugadores.Any(j => j.Goles > 30);

            // List<Jugador> EspañaOrdenados = Selecciones.FirstOrDefault(s => s.Nombre == "España") 
            //                                            .Jugadores.OrderBy(j => j.Edad).ToList<Jugador>();

            // List<Jugador> EspañaOrdenados2 = Selecciones.FirstOrDefault(s => s.Nombre == "España") 
            //                                            .Jugadores.OrderByDescending(j => j.Edad).ToList<Jugador>();    

            // var jugadorMax = francia.Jugadores.Max(j => j.Goles);
            // var jugadorMin = francia.Jugadores.Min(j => j.Goles);

            // List<Jugador> jugadoresCombinados = francia.Jugadores.Concat(Colombia.Jugadores).OrderBy(j => j.Ataque).ToList<Jugador>();
            // int CantidadJugadores = jugadoresCombinados.Count;

        }
    }
}
