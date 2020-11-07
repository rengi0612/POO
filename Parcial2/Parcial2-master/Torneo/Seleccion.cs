using System.Collections.Generic;
using Newtonsoft.Json;

namespace linq.Torneo
{
    public class Seleccion : IObserverSeleccion 
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
        public void update(int goles)
        {
            this.GolesTotales+=goles;
        }
        #endregion Methods

    }
}