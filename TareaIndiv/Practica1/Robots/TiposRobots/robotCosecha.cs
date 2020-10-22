using System;
using Practica1.Robots;
using Practica1.Sectores;
using Practica1.Especies;
using Practica1.Plantas;
using System.Linq;
using Practica1.SistemasHidro;

namespace Practica1.Robots.TiposRobots
{
    public class robotCosecha : robotPadre
    {
        public override int verificarBateria() //niveles batería 1-10: bajo 10-20:medio 20-30:alto
        {
            if (this.bateria<10) return 1;
            else if (this.bateria>=10 && this.bateria<20) return 2;
            else return 3;
        }
        public override bool verificarEstado() 
        {
             if (this.estado<5) return true;
             else return false;
            
        }

        public void sacarCode()
        {
            this.codigo = 1234;
        }

        public bool cosechar(ref Granja finca, catalogo maticas, ref Bodega almacen)
        {
            finca.actualizar(ref finca, maticas);
            string nombreP;
            int sem;
            int pro;
            int codi = 0;;
            for(int i = 0; i < 5; i++)
            {
                if(finca.cultivos[i].Item2 == "sacar")
                {
                    nombreP = finca.cultivos[i].Item3;
                    Planta busqueda = maticas.plantasDisponibles.First(j => j.nombre == nombreP);
                    Tuple<Planta,Int32,Int32> alma = almacen.semillasYproduccion.First(j => j.Item1.nombre == nombreP);
                    sem = alma.Item2 + busqueda.semillas*finca.cultivos[i].Item1.nivelOcupacion;
                    pro = alma.Item3 + busqueda.produccionTotal*finca.cultivos[i].Item1.nivelOcupacion;
                    almacen.semillasYproduccion.Remove(alma);
                    almacen.semillasYproduccion.Add(new Tuple<Planta, int, int>(busqueda,sem,pro)); // actualiza el almacen con las semillas conseguidas por el cultivo y la produccion
                    codi = finca.cultivos[i].Item1.cod;
                    finca.cultivos.RemoveAt(i);
                    finca.cultivos.Add(new Tuple<hidroponico,string,string> (new hidroponico() {cod = codi, ocupacion = false, minutoSiembra = 0, nivelOcupacion = 0}, "sin Sembrar",null));
                }
                
            }
            if (codi>0){
                return true;
            }
            else return false;
        }
    }
}