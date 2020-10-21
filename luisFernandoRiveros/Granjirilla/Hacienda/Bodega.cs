using System;
using System.Collections.Generic;
namespace Granjirilla.Hacienda
{
    public class Bodega{
        #region Properties
        //item1= Nombre de producto item2=kg de producto
        public List<Tuple<string,string>> Produccion_almacenada=new List<Tuple<string,string>>();
        //item1= Nombre de producto item2=cantidad de semillas
        public List<Tuple<string,string>> Semillas_almacenada=new List<Tuple<string,string>>();
        //Codigo del robot almacenado
        public List<string> Robots_almacenados=new List<string>();
        #endregion Properties

        #region Initialize
        #endregion Initialize

        #region Methods
        #endregion  Methods

    }
}