using System.Collections.Generic;
using Newtonsoft.Json;
using linq.Observer;
namespace linq.Torneo
{
    public class Seleccion: IObserver
    {
        #region Properties  
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("puntos")]
        public int PuntosTotales { get; set; }

        [JsonProperty("goles")]
        public int GolesTotales { get; set; }

        [JsonProperty("asistencias")]
        public int AsistenciasTotales { get; set; }

        [JsonProperty("jugadores")]
        public List<Jugador> Jugadores { get; set; }

        #endregion Properties

        #region Initialize

        #endregion Initialize
        #region Methods
        public void update(int pun,int gol,int asi)
        {
            this.PuntosTotales+=pun;
            this.GolesTotales+=gol;
            this.AsistenciasTotales+=asi;
        }
        #endregion Methods
    }
}