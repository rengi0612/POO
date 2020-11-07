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
            Random random = new Random();
            this.EquipoLocal.TarjetasAmarillas =random.Next(0,8);
            this.EquipoVisitante.TarjetasAmarillas =random.Next(0,8);
            this.EquipoLocal.TarjetasRojas =random.Next(1,5);
            this.EquipoVisitante.TarjetasRojas=random.Next(1,5);
        }
        #endregion Initialize
        #region Methods
        private void CalcularExpulsiones()
        {
            //expulsion aleatoria por targeta roja de los jugadores
            
            Random random = new Random();
            List<string> jugadoresVacios = Enumerable.Repeat(string.Empty, 50).ToList();
            List<String> JugadoresLocales = EquipoLocal.Seleccion.Jugadores.Select(j => j.Nombre).ToList().Concat(jugadoresVacios).ToList();
            List<String> JugadoresVisitantes = EquipoVisitante.Seleccion.Jugadores.Select(j => j.Nombre).ToList().Concat(jugadoresVacios).ToList();
            int position;
            for(int i=0;i<EquipoLocal.TarjetasRojas;i++){
            position = random.Next(JugadoresLocales.Count);
            String expulsadoLocal = JugadoresLocales[position];
            EquipoLocal.ExpulsarJugador(expulsadoLocal);
            }
            for(int i=0;i<EquipoVisitante.TarjetasRojas;i++){
            position = random.Next(JugadoresVisitantes.Count);
            String expulsadoVisitante = JugadoresVisitantes[position];
            EquipoVisitante.ExpulsarJugador(expulsadoVisitante);
            }
            //expulsion de los jugadores con  2 o mas targetas amarillas
            List<String> JugadoresLocales_amarillas = EquipoLocal.Seleccion.Jugadores.Where(j => j.Targetas>=2).Select(j => j.Nombre).ToList();
            List<String> JugadoresVisitantes_amarillas = EquipoVisitante.Seleccion.Jugadores.Where(j => j.Targetas>=2).Select(j => j.Nombre).ToList();
            foreach (string expulsado in JugadoresLocales_amarillas)
            {
                EquipoLocal.ExpulsarJugador(expulsado);
            }
            foreach (string expulsado in JugadoresVisitantes_amarillas)
            {
                EquipoVisitante.ExpulsarJugador(expulsado);
            }

        }

        private void CalcularResultado()
        {
            Random random = new Random();
            int g1= random.Next(0,6),g2= random.Next(0,6);
            EquipoLocal.Goles = g1;
            EquipoLocal.Asistencias=random.Next(0,g1);
            EquipoVisitante.Goles = g2;
            EquipoVisitante.Asistencias=random.Next(0,g2);

        }
        private void GenerarPenalizaciones()
        {
            Random random = new Random();
            int J_rL=EquipoLocal.Seleccion.Jugadores.Count;
            int J_rV=EquipoVisitante.Seleccion.Jugadores.Count;
            int Amarillo;
            EquipoLocal.Seleccion.Jugadores[1].Targetas+=2;
            for(int i=0;i<EquipoLocal.TarjetasAmarillas;i++){
            Amarillo = random.Next(J_rL);
            EquipoLocal.Seleccion.Jugadores[Amarillo].Targetas+=1;
            }
            for(int i=0;i<EquipoVisitante.TarjetasAmarillas;i++){
            Amarillo=random.Next(J_rV);
            EquipoVisitante.Seleccion.Jugadores[Amarillo].Targetas+=1;
            }
        }


        public string Resultado()
        {
            string resultado = "0 - 0";
            try
            {
                GenerarPenalizaciones();
                CalcularExpulsiones();
                CalcularResultado();
                
                resultado = EquipoLocal.Goles.ToString() + " - " + EquipoVisitante.Goles.ToString();
            }
            catch(LoseForWException ex)
            {
                Console.WriteLine(ex.Message);
                EquipoLocal.Goles -= EquipoLocal.Goles;
                EquipoVisitante.Goles -= EquipoVisitante.Goles;
                if (ex.NombreEquipo == EquipoLocal.Seleccion.Nombre)
                {
                    EquipoVisitante.Goles += 3;
                    resultado = "0 - 3";
                }
                else
                {
                    EquipoLocal.Goles += 3;
                    resultado = "3 - 0";
                }
            }
            
            return resultado;
        }
        #endregion Methods

    }
}