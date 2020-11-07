using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.IO;
namespace linq.Torneo
{
    public class RepositorioDatos
    {
        #region Properties  
        public List<Seleccion> Selecciones { get; set; }
        
        #endregion Properties

        #region Initialize
        public RepositorioDatos()
        {
            Selecciones = retornarSelecciones();
        }
        #endregion Initialize


        #region Methods
        private List<Seleccion> CrearSelecciones()
        {
            List<Seleccion> selecciones = new List<Seleccion>();
            selecciones.Add(new Seleccion()
            {
                Nombre = "Francia",
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Griezmann", 28, 11, 90, 55, 10, 2),
                    new Jugador("Benzema", 32, 9, 92, 40, 20, 1),
                    new Jugador("Mbappe", 21, 7, 95, 50, 15, 14),
                    new Jugador("Dembelé", 23, 11, 92, 45, 12, 17),
                    new Jugador("Raul", 23, 11, 92, 45, 12, 17),
                    new Jugador("Esteban", 23, 11, 92, 45, 12, 17),
                    new Jugador("Jaime", 23, 11, 92, 45, 12, 17),
                    new Jugador("Pedrito", 23, 11, 92, 45, 12, 17),
                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "España",
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Ramos", 33, 6, 60, 85, 8, 0),
                    new Jugador("Fati", 17, 9, 95, 40, 10, 12),
                    new Jugador("Aspas", 32, 11, 85, 55, 5, 5),
                    new Jugador("Busquets", 33, 5, 79, 85, 2, 3),
                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "Colombia",
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Falcao", 33, 9, 89, 50, 9, 2),
                    new Jugador("James", 29, 10, 97, 45, 7, 17),
                    new Jugador("Ospina", 31, 1, 40, 95, 0, 0),
                    new Jugador("Mina", 24, 2, 55, 89, 4, 0),
                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "Argentina",
                Jugadores = new List<Jugador>()
                {
                    new Jugador("Messi", 33, 10, 99, 50, 40, 20),
                    new Jugador("Aguero", 32, 9, 90, 50, 10, 5),
                    new Jugador("Acuña", 24, 4, 75, 85, 3, 10),
                    new Jugador("Dybala", 25, 7, 90, 45, 8, 6),
                    new Jugador("Raul", 23, 11, 92, 45, 12, 17),
                    new Jugador("Esteban", 23, 11, 92, 45, 12, 17),
                    new Jugador("Jaime", 23, 11, 92, 45, 12, 17),
                    new Jugador("Pedrito", 23, 11, 92, 45, 12, 17),
                }
            });
            /*
            selecciones.Add(new Seleccion()
            {
                Nombre = "Brasil"
            });*/

            return selecciones;
        }

        public List<Seleccion> retornarSelecciones()
        {
            List<Seleccion> selections = JsonConvert.DeserializeObject<List<Seleccion>>(File.ReadAllText("./Selection.json"));
            return selections;
        }
        public void Crear()
        {
            Seleccion nueva =  new Seleccion();
            List<Seleccion> selections = JsonConvert.DeserializeObject<List<Seleccion>>(File.ReadAllText("./Selection.json"));
            Seleccion comprobar;
            Console.Write("Nombre de la selección: "); 
            nueva.Nombre = Console.ReadLine();
            try
            {
                
                comprobar = selections.First(s => s.Nombre == nueva.Nombre) as Seleccion;
                Console.WriteLine("La seleccion ya existe");
                this.Crear();
                
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Digite el nombre de los jugadores");
            }

            nueva.GolesTotales = 0;
            nueva.PuntosTotales = 0;
            nueva.Jugadores = agregarJugador();
            selections.Add(nueva);
            var seleccionSerializada = JsonConvert.SerializeObject(selections);
            File.WriteAllText("./Selection.json", seleccionSerializada);
            
        }

        private List<Jugador> agregarJugador()
        {
            string nombre;
            List<Jugador> players = new List<Jugador>();
            for(int i = 0;i<4; i++)
            {
                Console.Write("Nombre Jugador: ");
                nombre = Console.ReadLine();
                players.Add(new Jugador (nombre,20,0,1,2,3,4));
            }
            return players;
        }
        #endregion Methods


    }
}