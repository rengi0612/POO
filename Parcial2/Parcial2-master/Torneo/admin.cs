using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;

namespace linq.Torneo
{
    public class admin 
    {
        public RepositorioDatos Datos = new RepositorioDatos();
        public List<Seleccion> Selecciones;

        private List<IObserverSeleccion> subscriptores;
        public List<IObserverSeleccion> Subscriptores
        {
            get { return subscriptores; }
            set { subscriptores = value; }
        }


        public Partido Juego;

        #region Initialize
        public admin()
        {
            Selecciones = Datos.Selecciones;
        }
        #endregion Initialize
        #region Methods
        public void agregarSeleccion()
        {
            Datos.Crear();
        }

        public void jugarPartido()
        {
            string local;
            string visitante;
            Console.Write("Local: ");
            local = Console.ReadLine();
            Console.Write("Visitante: ");
            visitante = Console.ReadLine();
            try{
                Seleccion Equipolocal = Selecciones.First(s => s.Nombre == local) as Seleccion; 
                Seleccion EquipoVisitante = Selecciones.First(s => s.Nombre == visitante) as Seleccion;
                Juego = new Partido(Equipolocal, EquipoVisitante);
                Console.WriteLine("Resultado del partido : "+ Juego.Resultado()[0] + "-" +Juego.Resultado()[1] );
                subscribir(Equipolocal);
                subscribir(EquipoVisitante);
                notificar(Juego.Resultado()[0],Equipolocal.Nombre);
                Console.WriteLine("Goles totales"+Equipolocal.GolesTotales);
                notificar(Juego.Resultado()[1],EquipoVisitante.Nombre);
                Console.WriteLine("Goles totales"+EquipoVisitante.GolesTotales);
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("No se encontró el equipo");
                this.jugarPartido();
            }
            
            
        }
        public void subscribir(IObserverSeleccion seleccion)
        {
            Subscriptores.Add(seleccion);
        }

        public void notificar(int goles, string nombre)
        {
            foreach(IObserverSeleccion j in Subscriptores)
            {
                j.update(goles);
 
            }
           
        }

        #endregion Methods


    }
}
