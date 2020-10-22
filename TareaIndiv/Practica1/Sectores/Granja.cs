using System;
using System.Collections.Generic;
using Practica1.SistemasHidro;
using Practica1.Especies;
using Practica1.Plantas;
using System.Linq;

namespace Practica1.Sectores
{
    public class Granja
    {

        DateTime now = DateTime.Now;

        public state etapa = new state();
        public List<Tuple<hidroponico,string,string>> cultivos = new List<Tuple<hidroponico,string,string>>();
        public void inicializar() 
        {
            cultivos.Add(new Tuple<hidroponico,string,string> (new hidroponico() {cod = 001, ocupacion = false, minutoSiembra = 0, nivelOcupacion = 0}, "sin Sembrar",null));
            cultivos.Add(new Tuple<hidroponico,string,string> (new hidroponico() {cod = 002, ocupacion = false, minutoSiembra = 0, nivelOcupacion = 0}, "sin Sembrar",null));
            cultivos.Add(new Tuple<hidroponico,string,string> (new hidroponico() {cod = 003, ocupacion = false, minutoSiembra = 0, nivelOcupacion = 0}, "sin Sembrar",null));
            cultivos.Add(new Tuple<hidroponico,string,string> (new hidroponico() {cod = 004, ocupacion = false, minutoSiembra = 0, nivelOcupacion = 0}, "sin Sembrar",null));
            cultivos.Add(new Tuple<hidroponico,string,string> (new hidroponico() {cod = 005, ocupacion = false, minutoSiembra = 0, nivelOcupacion = 0}, "sin Sembrar",null));
        }


        public bool añadir2(Planta matica, int cantidad)
        {
            DateTime ahora = DateTime.Now;
            string estadoPlanta = etapa.estado(ahora.Minute,matica.tasaCrecimiento);
            int cont = 0;
            foreach(Tuple<hidroponico,string,string> busca in this.cultivos)
            {
                if(busca.Item1.ocupacion == true) cont++;
            }
            if(cont==5){
                return false;
            }
            Tuple<hidroponico,string,string> elegido = this.cultivos.First(j => j.Item1.ocupacion == false);
            int codigo = elegido.Item1.cod;
            this.cultivos.Remove(elegido);  
            this.cultivos.Add(new  Tuple<hidroponico, string, string> (new hidroponico() {cod = codigo, ocupacion = true, minutoSiembra = ahora.Minute, nivelOcupacion = cantidad}, estadoPlanta,matica.nombre));
            return true;
        }

        public void actualizar(ref Granja finca, catalogo maticas )
        {
            string estadoPlanta;
            int code;
            bool ocp;
            int minSiem;
            int nOcp;
            string nombreP;

            for (int i = 0; i< 5; i++)
            {
                if(finca.cultivos[i].Item1.ocupacion)
                {
                    nombreP = finca.cultivos[i].Item3;
                    Planta busqueda = maticas.plantasDisponibles.First(j => j.nombre == nombreP);
                    estadoPlanta = etapa.estado(finca.cultivos[i].Item1.minutoSiembra,busqueda.tasaCrecimiento);
                    code = finca.cultivos[i].Item1.cod;
                    ocp = finca.cultivos[i].Item1.ocupacion;
                    minSiem = finca.cultivos[i].Item1.minutoSiembra;
                    nOcp = finca.cultivos[i].Item1.nivelOcupacion;
                    finca.cultivos.RemoveAt(i);
                    finca.cultivos.Add(new  Tuple<hidroponico, string, string> (new hidroponico() {cod = code, ocupacion = ocp, minutoSiembra = minSiem, nivelOcupacion = nOcp}, estadoPlanta,nombreP));
                }

                
            }
            
        }

    }
}