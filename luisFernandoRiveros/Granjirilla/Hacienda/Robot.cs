namespace Granjirilla.Hacienda
{
    public class Robot{
        #region Properties
        //codigo de identidad
        public string Code { get; set; }
        //tipo de robot (sembrado, recoleccion, limpieza)
        public string Type { get; set; }
        //(0)low (1)medium (2)full
        public int Energy { get; set; }
        // durabilidad valores 0-100.
        public int Durability { get; set; }
        //ubicacion actual Descanso, Bodega, Mantenimiento, sembradoN, Cargando
        public string Ubicacion { get; set; }
        #endregion Properties

        #region Initialize
        public Robot(string c, string t) 
        {
            this.Code=c;
            this.Type=t;
            this.Energy=2;
            this.Durability=100;
            this.Ubicacion="Descanso";
        }
        #endregion Initialize

        #region Methods
        #endregion  Methods

    }
}