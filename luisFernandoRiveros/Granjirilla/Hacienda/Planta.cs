namespace Granjirilla.Hacienda
{
    public class Planta{
        #region Properties
        //nombre de la planta
        public string Type { get; set; }
        
        //germ es la Tasa de crecimiento.
        //siendo esta el multiplo de tiempo necesario para los diferentes rstados de crecimento(2,3,7,14,15)dias
        
        public int germ { get; set; }
        //requerimientos de horas de luz por dia
        public int request_liht { get; set; }
        //requerimientos de litros de agua por dia
        public int request_water { get; set; }
        //requerimientos de bolsas abono a la semana
        public int request_food { get; set; }
        //espacio necesario para la planta madura
        public int conditions_size { get; set; }
        //kg de produccion promedio al momento de cosechar la planta
        public int conditions_production { get; set; }
        //cantidad de semillas por kg de produccion
        public int conditions_seeds { get; set; }
     
        #endregion Properties

        #region Initialize
        public Planta(string t, int g, int l, int w, int f, int sz, int p, int s) 
        {
            this.Type=t;
            this.germ=g;
            this.request_liht=l;
            this.request_water=w;
            this.request_food=f;
            this.conditions_size=sz;
            this.conditions_production=p;
            this.conditions_seeds=s;
        }
        #endregion Initialize

        #region Methods
        #endregion  Methods

    }
}