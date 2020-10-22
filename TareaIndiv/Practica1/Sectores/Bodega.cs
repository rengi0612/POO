using System;
using Practica1.Plantas;
using System.Collections.Generic;
using Practica1.Especies;
using System.Linq;

namespace Practica1.Sectores
{
    
    public class Bodega
    {
        catalogo inicio =  new catalogo();
        public List<Tuple<Planta,Int32,Int32>> semillasYproduccion = new List<Tuple<Planta,Int32,Int32>>();

        public void llenar(Planta matica, int cantidadSemillas, int cantidadPro)
        {
           semillasYproduccion.Add(new Tuple<Planta, int, int>(matica,cantidadSemillas,cantidadPro));
        }

        public void inicializar()
        {
            inicio.iniciarLista();
            semillasYproduccion.Add(new Tuple<Planta, int, int>(inicio.plantasDisponibles[0],inicio.plantasDisponibles[0].semillas,0));
            semillasYproduccion.Add(new Tuple<Planta, int, int>(inicio.plantasDisponibles[1],inicio.plantasDisponibles[1].semillas,0));
        }


        public bool verificarSemillas2(string nombreP, int cantidad)
        {
            Tuple<Planta,Int32,Int32> busca = this.semillasYproduccion.First(j => j.Item1.nombre == nombreP);
            if(busca.Item2 >= cantidad)
            {
                return true;
            }
            else{
                return false;
            }
        }
    }
}