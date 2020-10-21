using System.Collections.Generic;
using Excepciones.CustomExceptions;
using System.Linq;
using System;
namespace Granjirilla.Hacienda
{
    public class Granja{
        #region Properties
        public int hec_pincipales=10;
        private int hec_reserva=4;
        public List<Sembrado> Sembrados { get; set; }
        public List<Sembrado> Sembrados_reserva { get; set; }
        public List<Planta> Plantas_gran=new List<Planta>();
        public List<Robot> Robots_gran=new List<Robot>();
        public Bodega Bodega_gran=new Bodega();
        //Plantas_gran.Add(new Planta("caña_azucar", 3, 8, 2, 1, 1, 5,5));
        //public Planta Tomate=new Planta("tomate", 2, 8, 1, 1, 1, 2,20);
        
        #endregion Properties

        #region Initialize
        public Granja()
        {   
            Crear_plantas();
            Crear_robots();
            Crear_bodega();
            Sembrados = CrearEspacios();
        }
        #endregion Initialize

        #region Methods
        
        private void Crear_plantas(){
            Plantas_gran.Add(new Planta("tomate", 2, 8, 1, 1, 1, 2,20){});
            Plantas_gran.Add(new Planta("caña_azucar", 3, 8, 2, 1, 1, 5,5){});
        }
        private void Crear_robots(){
            Robots_gran.Add(new Robot("10001", "sembrado"){});
            Robots_gran.Add(new Robot("10002", "recoleccion"){});
            Robots_gran.Add(new Robot("10003", "limpieza"){});
            Robots_gran.Add(new Robot("10006","recoleccion"){});  
        }
        private void Crear_bodega(){
            
            Bodega_gran.Semillas_almacenada.Add(new Tuple<string,string>("tomate","20000"));
            Bodega_gran.Semillas_almacenada.Add(new Tuple<string,string>("caña_azucar","10"));
        }
        private List<Sembrado> CrearEspacios(){
            List<Sembrado> sembrados_ini = new List<Sembrado>();
            Planta plantu= Plantas_gran.First(j => j.Type == "tomate");
            sembrados_ini.Add(new Sembrado(){Name_semb = "siembra 1",Plantas =plantu});
            sembrados_ini.Add(new Sembrado(){Name_semb = "siembra 2",Plantas =plantu});
            sembrados_ini.Add(new Sembrado(){Name_semb = "siembra 3",Plantas =plantu});
            Planta plantu2= Plantas_gran.First(j => j.Type == "caña_azucar");
            sembrados_ini.Add(new Sembrado(){Name_semb = "siembra 4",Plantas =plantu2});
            return sembrados_ini;
        }
        public void add_sembrado(string nombre, Planta plant){
            int cel;
            try{
                cel=Sembrados.Count();
            }
            catch(ArgumentNullException){
                cel=0;
            }
            if(cel>=hec_pincipales){
                throw new LoseForWException("Solicite permiso en reserva");
                
            }
            else{
                try
                {
                    Sembrado Sembra= Sembrados.First(j => j.Name_semb == nombre);
                    throw new LoseForUsed(nombre);
                }
                catch (InvalidOperationException)
                {
                    Sembrados.Add(new Sembrado(){Name_semb = nombre,Plantas =plant});
                }
            }
        }
        public void add_sembradoReserva(string nombre, Planta plant){
            int cel;
            try{
                cel=Sembrados_reserva.Count();
            }
            catch(ArgumentNullException){
                cel=0;
            }
            if(Sembrados.Count()<hec_pincipales){
                throw new LoseForWException("Aun hay espacio disponiple en sembrados principales");
                
            }
            else if(cel>=hec_reserva){
                throw new LoseForWException("No hay espacios de sembrado disponibles");
                
            }
            else{
                try
                {
                    Sembrado Sembra= Sembrados_reserva.First(j => j.Name_semb == nombre);
                    throw new LoseForUsed(nombre);
                }
                catch (InvalidOperationException)
                {
                    Sembrados.Add(new Sembrado(){Name_semb = nombre,Plantas =plant});
                }
            }
        }
        public void add_planta(string nombre,int g, int l, int w, int f, int sz, int p, int s){
            try
            {
                Planta plantu= Plantas_gran.First(j => j.Type == nombre);
                throw new LoseForUsed(nombre);
            }
            catch (InvalidOperationException)
            {
                Plantas_gran.Add(new Planta(nombre, g, l, w, f, sz, p,s){});
                
            }
        }
        public void add_robot(string serial,string tipo){
            try
            {
                Robot robotin= Robots_gran.First(j => j.Code == serial);
                throw new LoseForUsed(serial);
            }
            catch (InvalidOperationException)
            {
                Robots_gran.Add(new Robot(serial, tipo){});
                Bodega_gran.Robots_almacenados.Add(serial);
            }
        }
        
        
        #endregion  Methods

    }
}