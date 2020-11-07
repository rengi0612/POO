using System.Collections.Generic;
using System.Linq;

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
            Selecciones = CrearSelecciones();
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
                    new Jugador("Romas", 33, 6, 60, 85, 8, 0),
                    new Jugador("Fatu", 17, 9, 95, 40, 10, 12),
                    new Jugador("Aspaers", 32, 11, 85, 55, 5, 5),
                    new Jugador("Busquetero", 33, 5, 79, 85, 2, 3),
                    new Jugador("Luleno", 33, 6, 60, 85, 8, 0),
                    new Jugador("Fatimo", 17, 9, 95, 40, 10, 12),
                    new Jugador("Aspero", 32, 11, 85, 55, 5, 5),
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
                    new Jugador("Griez", 28, 11, 90, 55, 10, 2),
                    new Jugador("Benzurco", 32, 9, 92, 40, 20, 1),
                    new Jugador("Mbapperin", 21, 7, 95, 50, 15, 14),
                    new Jugador("Dembeléno", 23, 11, 92, 45, 12, 17),
                    new Jugador("Romero", 33, 6, 60, 85, 8, 0),
                    new Jugador("Fatulio", 17, 9, 95, 40, 10, 12),
                    new Jugador("Parcerin", 32, 11, 85, 55, 5, 5),
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
                    new Jugador("Mesero", 33, 10, 99, 50, 40, 20),
                    new Jugador("Agueriño", 32, 9, 90, 50, 10, 5),
                    new Jugador("Acolito", 24, 4, 75, 85, 3, 10),
                    new Jugador("Dandi", 25, 7, 90, 45, 8, 6),
                    new Jugador("Fernando", 17, 9, 95, 40, 10, 12),
                    new Jugador("Aspaero", 32, 11, 85, 55, 5, 5),
                    new Jugador("Buquiño", 33, 5, 79, 85, 2, 3),
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
                    new Jugador("Bealule", 32, 9, 92, 40, 20, 1),
                    new Jugador("Murillo", 21, 7, 95, 50, 15, 14),
                    new Jugador("David", 23, 11, 92, 45, 12, 17),
                    new Jugador("Mariano", 21, 7, 95, 50, 15, 14),
                    new Jugador("Dester", 23, 11, 92, 45, 12, 17),
                    new Jugador("Romiño", 33, 6, 60, 85, 8, 0),
                    new Jugador("Ferulio", 17, 9, 95, 40, 10, 12),
                }
            });
            selecciones.Add(new Seleccion()
            {
                Nombre = "Brasil"
            });

            return selecciones;
        }

        #endregion Methods



    }
}