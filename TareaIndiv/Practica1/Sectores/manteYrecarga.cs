using Practica1.Robots;
using Practica1.Robots.TiposRobots;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Practica1.Sectores
{
    public class manteYrecarga
    {
        public List<Tuple<robotPadre,string,int>> estaciones = new List<Tuple<robotPadre,string,int>>();

        public void llenar(robotPadre robotcito, string razon)
        {
            DateTime now = DateTime.Now;
            this.estaciones.Add(new Tuple<robotPadre, string,int>(robotcito,razon,now.Minute));
        }

        public void inicializar()
        {
            this.estaciones.Add(new Tuple<robotPadre, string,int>(new robotCosecha(),"prob1",-1));
            this.estaciones.Add(new Tuple<robotPadre, string,int>(new robotSembrar(),"prob2",-1));
        }
        public bool verificarRobot(int cod)
        {
            DateTime ahora = DateTime.Now;
            int i= 0;
            foreach(Tuple<robotPadre,string,int> robots in this.estaciones)
            {

                if(robots.Item1.codigo == cod)
                {
                    i = this.estaciones.IndexOf(robots);
                    if ((this.estaciones[i].Item1.bateria + (ahora.Minute - this.estaciones[i].Item3)) > 30)
                    {
                        this.estaciones[i].Item1.bateria =  30;
                    }
                    else
                    {
                        this.estaciones[i].Item1.bateria+= (ahora.Minute - this.estaciones[i].Item3);
                    }
                    if((this.estaciones[i].Item1.estado + (ahora.Minute - this.estaciones[i].Item3))>10)
                    {
                        this.estaciones[i].Item1.estado = 10;
                    }
                    else
                    {
                        this.estaciones[i].Item1.estado+= (ahora.Minute - this.estaciones[i].Item3);
                    }
                    
                    if (this.estaciones[i].Item1.verificarBateria()==3)
                    {
                        this.estaciones.RemoveAt(i);
                        this.estaciones.Add(new Tuple<robotPadre, string,int>(new robotCosecha(),"prob1",-1));
                    }
                    else if (!this.estaciones[i].Item1.verificarEstado())
                    {
                        this.estaciones.RemoveAt(i);
                        this.estaciones.Add(new Tuple<robotPadre, string,int>(new robotSembrar(),"prob2",-1));
                    }
                    return true;
                }
            }
            
            return false;
        }

    }
}