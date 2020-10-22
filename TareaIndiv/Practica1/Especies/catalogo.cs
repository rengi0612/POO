using System;
using System.Collections.Generic;
using Practica1.Plantas;
using System.Linq;

namespace Practica1.Especies
{
    public class catalogo
    {
        #region Properties
        public List<Planta> plantasDisponibles = new List<Planta>();
        #endregion Properties
        
        public void guardarPlanta(Planta matica)
        {
            plantasDisponibles.Add(matica);
        }
        public void iniciarLista()
        {
            plantasDisponibles.Add(new Planta() {nombre = "Tomate", necesidadLuz = 6, produccionTotal = 2, semillas = 10, tasaCrecimiento = 1});
            plantasDisponibles.Add(new Planta() {nombre = "Lechuga", necesidadLuz = 8, produccionTotal = 1, semillas = 2, tasaCrecimiento = 1});
        }
        public bool verificarDisp(string matica)
        {

            foreach(Planta mata in this.plantasDisponibles)
            {
                if(mata.nombre == matica)
                {
                    return true;
                }
            }
            return false;
            
        }

    }
}