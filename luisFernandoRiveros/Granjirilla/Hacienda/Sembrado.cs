namespace Granjirilla.Hacienda
{
    public class Sembrado{
        #region Properties
        //[JsonProperty("nombre")]
        
        public string Name_semb { get; set; }
        //vacio,semilla,germinando,primordio final,maduro
        public string Estado { get; set; }
        public bool riego { get; set; }
        public bool techo { get; set; }
        public bool UV { get; set; }
        //1,2,3 para saber los 3 riegos al dia
        public int Health_water{ get; set; }
        public bool Health_light{get; set; }
        public bool Health_food{get; set; }
        //[JsonProperty("jugadores")]
        public Planta Plantas { get; set; }
        #endregion Properties

        #region Initialize
        public Sembrado() 
        {
            this.Estado="vacio";
        }
        #endregion Initialize

        #region Methods
        #endregion  Methods

    }
}