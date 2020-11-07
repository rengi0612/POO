using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using Excepciones.CustomExceptions;
namespace linq.Torneo
{
    public class Gestion_datos
    {
        #region Properties  
        string nombre_Seleccion,nombre_jugador;
        int Edad,Posicion,Goles ,Asistencias;
        double Ataque ,Defensa;
        public List<Seleccion> Selecciones_json { get; set; }
        public Seleccion Selec { get; set; }
        public List<Jugador> Jugadoresadd { get; set; }
        IntOutdatas inout= new IntOutdatas(); 
        #endregion Properties

        #region Initialize
        public Gestion_datos(){
            List<Seleccion> Selecciones = JsonConvert.DeserializeObject<List<Seleccion>>(File.ReadAllText("./selecciones.json"));
            Selecciones_json=Selecciones;
        }
        
        #endregion Initialize
        #region Methods
        
        public void Resetiar(){
            RepositorioDatos Datos = new RepositorioDatos();
            Selecciones_json=Datos.Selecciones;
            Guardar();
        }
        public void Guardar(){
            
            var DatosSerializada = JsonConvert.SerializeObject(Selecciones_json);
            File.WriteAllText("./selecciones.json", DatosSerializada);
        }
        public void Crear_seleccion(){
            List<Seleccion> Selecciones = JsonConvert.DeserializeObject<List<Seleccion>>(File.ReadAllText("./selecciones.json"));
            
            inout.escribir("ingrese nombre seleccion:");
            nombre_Seleccion=inout.Pedir_dato();

            try{
                    Seleccion Sembra= Selecciones.First(j => j.Nombre == nombre_Seleccion);
                    throw new LoseForUsed(nombre_Seleccion);
                }
            catch (InvalidOperationException)
            {      
            Selec=new Seleccion(){Nombre = nombre_Seleccion};
            inout.escribir("---INGRESO JUGADORES------\n");
            for(int i=0;i<11;i++){
                inout.escribir("nombre:");
                nombre_jugador=inout.Pedir_dato();
                inout.escribir("edad:");
                Edad=Int32.Parse(inout.Pedir_dato());
                inout.escribir("posicion:");
                Posicion=Int32.Parse(inout.Pedir_dato());
                inout.escribir("ataque:");
                Ataque=System.Convert.ToDouble(inout.Pedir_dato());
                inout.escribir("defensa:");
                Defensa=System.Convert.ToDouble(inout.Pedir_dato());
                inout.escribir("goles:");
                Goles=Int32.Parse(inout.Pedir_dato());
                inout.escribir("asistencias:");
                Asistencias=Int32.Parse(inout.Pedir_dato());
                Jugadoresadd.Add(new Jugador(nombre_jugador, Edad,Posicion,Ataque ,Defensa,Goles ,Asistencias));
            }
            Selec=new Seleccion(){Nombre = nombre_Seleccion,Jugadores=Jugadoresadd};
            Selecciones.Add(Selec);
            var DatosSerializada = JsonConvert.SerializeObject(Selecciones);
            File.WriteAllText("./selecciones.json", DatosSerializada);
            }
        }
        #endregion Methods
    }
}