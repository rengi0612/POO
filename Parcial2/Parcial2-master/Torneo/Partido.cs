using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;

namespace linq.Torneo
{
    public class Partido
    {
        #region Properties  
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }

        #endregion Properties

        #region Initialize
        public Partido(Seleccion EquipoLocal, Seleccion EquipoVisitante) 
        {
            this.EquipoLocal = new Equipo(EquipoLocal);
            this.EquipoVisitante = new Equipo(EquipoVisitante);
        }
        #endregion Initialize
        #region Methods

        private void CalcularFaltas()
        {

            CalcularAmarillas(EquipoLocal);
            CalcularAmarillas(EquipoVisitante);
            ExpulsarAmarillas(EquipoLocal);
            ExpulsarAmarillas(EquipoVisitante);

        }

        private void ExpulsarAmarillas(Equipo equipo)
        {
            string expulsado;
            for (int i = 0; i < equipo.Seleccion.Jugadores.Count; i++)
            {
                if(equipo.Seleccion.Jugadores[i].TarjetasAmarillas == 2)
                {
                    expulsado = equipo.Seleccion.Jugadores[i].Nombre;
                    equipo.ExpulsarJugador(expulsado);
                }
            }
        }

        private void CalcularAmarillas(Equipo equipo)
        {
            Random random = new Random();
            int amarillas = random.Next(0,9);
            int jugadorAzar;
            equipo.TarjetasAmarillas = amarillas;
            for (int i = 0; i<amarillas; i++)
            {
                jugadorAzar = random.Next(equipo.Seleccion.Jugadores.Count);
                if(equipo.Seleccion.Jugadores[jugadorAzar].TarjetasAmarillas==2)
                {
                    for(int k = 0; i< equipo.Seleccion.Jugadores.Count; i++)
                    {
                        if(equipo.Seleccion.Jugadores[k].TarjetasAmarillas<2)
                        {
                            equipo.Seleccion.Jugadores[k].TarjetasAmarillas +=1;
                            break;
                        }
                    }
                }
                else{
                    equipo.Seleccion.Jugadores[jugadorAzar].TarjetasAmarillas +=1;
                }
                
            }
            
        }

        private void CalcularExpulsiones()
        {
            List<string> jugadoresVacios = Enumerable.Repeat(string.Empty, 50).ToList();
            List<String> JugadoresLocales = EquipoLocal.Seleccion.Jugadores.Select(j => j.Nombre).ToList().Concat(jugadoresVacios).ToList();
            List<String> JugadoresVisitantes = EquipoVisitante.Seleccion.Jugadores.Select(j => j.Nombre).ToList().Concat(jugadoresVacios).ToList();     
            rojasExpulsar(EquipoLocal,JugadoresLocales);       
            rojasExpulsar(EquipoVisitante,JugadoresVisitantes);
        }

        private void rojasExpulsar(Equipo equipo, List<String> jugadores)
        {
            Random random = new Random();
            int expulsados = random.Next(1,6);
            int posicion = 0;
            String expulsado;
            while (expulsados>0)
            {
                posicion = random.Next(jugadores.Count);
                expulsado = jugadores[posicion];
                equipo.ExpulsarJugador(expulsado);
                expulsados--;
            }
        }

        private void CalcularResultado()
        {
            Random random = new Random();
            EquipoLocal.Goles = random.Next(0,6);
            EquipoVisitante.Goles = random.Next(0,6);
        }

        public int[] Resultado()
        {
            int [] resultado = {0,0};

            try
            {
                CalcularFaltas();
                CalcularExpulsiones();
                CalcularResultado();
                
                resultado[0] = EquipoLocal.Goles;
                resultado[1] = EquipoVisitante.Goles;
            }
            catch(LoseForWException ex)
            {
                Console.WriteLine(ex.Message);
                EquipoLocal.Goles -= EquipoLocal.Goles;
                EquipoVisitante.Goles -= EquipoVisitante.Goles;
                if (ex.NombreEquipo == EquipoLocal.Seleccion.Nombre)
                {
                    EquipoVisitante.Goles += 3;
                    resultado[0] = 0 ;
                    resultado[1] = 3;
                }
                else
                {
                    EquipoLocal.Goles += 3;
                    resultado[0] = 3 ;
                    resultado[1] = 0;
                }
            }
            
            return resultado;
        }
        #endregion Methods

    }
}