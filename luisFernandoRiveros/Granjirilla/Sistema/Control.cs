using System;
using System.Linq;
using Granjirilla.Hacienda;
using Excepciones.CustomExceptions;
namespace Granjirilla.Sistema
{
    public class Control{
        
        #region Properties
        public Granja myfarm = new Granja();
        #endregion Properties
        #region Initialize
        
        
        #endregion Initialize
        #region Methods
        //metodos de agregar
        public void Agregar_sembrado(string nombresin, string plantita){
            Planta plantu= myfarm.Plantas_gran.First(j => j.Type == plantita);
            try{myfarm.add_sembrado(nombresin,plantu);}
            catch (LoseForWException ex){Console.WriteLine("ta lleno {0}\n",ex.Message);}
            catch (LoseForUsed){Console.WriteLine("ta ocupado el nombre, No se pudo realizar");}
        }
        public void Agregar_sembradoReserva(string nombresin, string plantita){
            Planta plantu= myfarm.Plantas_gran.First(j => j.Type == plantita);
            try{myfarm.add_sembradoReserva(nombresin,plantu);}
            catch(LoseForWException ex){Console.WriteLine("No se pudo porque {0}\n",ex.Message);}
            catch(LoseForUsed){Console.WriteLine("ta ocupado el nombre, No se pudo realizar");}
        }
        
        public void Agregar_planta(string nombre,int g, int l, int w, int f, int sz, int p, int s){
            try{myfarm.add_planta(nombre, g, l, w, f, sz, p,s);}
            catch (LoseForUsed){Console.WriteLine("Ya existe");}
        }
        public void Agregar_robot(string serial,string tipo){
            try{
                myfarm.add_robot(serial,tipo);
                
            }
            catch (LoseForUsed){Console.WriteLine("Ya existe el serial");}
        }
        public void Agregar_robotBodega(string serial){
            Robot robo= myfarm.Robots_gran.First(j => j.Code == serial);
            myfarm.Robots_gran.Remove(robo);
            robo.Ubicacion="Bodega";
            myfarm.Robots_gran.Add(robo);
            myfarm.Bodega_gran.Robots_almacenados.Add(serial);
        }
        //METODOS ROBOT
        //lleva el robot a realizar su tarea en un sembrado
        public void Mandar_Trabajar(string sembrado, string serialbot){
            Robot robo= myfarm.Robots_gran.First(j => j.Code == serialbot);
            myfarm.Robots_gran.Remove(robo);
            robo.Ubicacion=sembrado;
            robo.Durability-=10;
            robo.Energy-=1;
            myfarm.Robots_gran.Add(robo);
        }
        //lleva al rbot al area de descanso
        public void Mandar_Descansar(string serialbot){
            Robot robo= myfarm.Robots_gran.First(j => j.Code == serialbot);
            myfarm.Robots_gran.Remove(robo);
            robo.Ubicacion="Descanso";
            
            myfarm.Robots_gran.Add(robo);
        }
        //  manda a el robot a una ubicacion ya sea, mantenimiento,recarga,bodega etc.
        public void Mandar_Ubicacion( string serialbot,string ubica){
            Robot robo= myfarm.Robots_gran.First(j => j.Code == serialbot);
            myfarm.Robots_gran.Remove(robo);
            robo.Ubicacion=ubica;
            //si se manda a cargar, su eneria llega al maximo y asi mismo con mantenimiento y durabilidad
            if(ubica=="Centro_carga"){robo.Energy=2;}
            if(ubica=="Mantenimiento"){robo.Durability=100;}
            
            myfarm.Robots_gran.Add(robo);
        }
        //Metodos consulta
        //consulta si exsite un sembrado con ese nombre
        public bool Consultar_siembra(string nombre){
            try{Sembrado lule=myfarm.Sembrados.First(j => j.Name_semb == nombre);return true;}
            catch (InvalidOperationException){return false;}
        }
        //consulta si existe planta con ese nombre
        public bool Consultar_planta(string nombre){
            try{Planta lule=myfarm.Plantas_gran.First(j => j.Type == nombre);return true;}
            catch (InvalidOperationException){return false;}
        }
        //consulta si existe robot con ese serial
        public bool Consultar_Robot(string nombre){
            try{Robot lule=myfarm.Robots_gran.First(j => j.Type == nombre);return true;}
            catch (InvalidOperationException){return false;}
        }
        //me dice cuantas semillas hay de un tipo de planta en bodega
        public int Consultar_bodegaSemilla(string semi){
            try{Tuple<string,string> lulen=myfarm.Bodega_gran.Semillas_almacenada.First(j => j.Item1 == semi);return Int32.Parse(lulen.Item2);}
            catch (InvalidOperationException){return 0;}

        }
        //metodos de cambiar estados
        //agrega o resta semillas de una planta a la bodega
        public void add_bodegasemilla(string nombre,int cantidad){
            int actual;
            try{Tuple<string,string> lulen=myfarm.Bodega_gran.Semillas_almacenada.First(j => j.Item1 == nombre);
            myfarm.Bodega_gran.Semillas_almacenada.Remove(lulen);
            actual=Int32.Parse(lulen.Item2);
            myfarm.Bodega_gran.Semillas_almacenada.Add(new Tuple<string, string>(nombre,(actual+cantidad).ToString()));
            }
            catch (InvalidOperationException){
            myfarm.Bodega_gran.Semillas_almacenada.Add(new Tuple<string, string>(nombre,cantidad.ToString()));
            }
            
        }
        //enciende o apaga los diferentes artefactos(UV, TECHO,RIEGO)
        public void OnOff_UV(string sem,bool enc){
            Sembrado semim= myfarm.Sembrados.First(j => j.Name_semb == sem);
            myfarm.Sembrados.Remove(semim);
            semim.UV =enc;
            
            myfarm.Sembrados.Add(semim);

        }
        public void OnOff_Riego(string sem,bool enc){
            Sembrado semim= myfarm.Sembrados.First(j => j.Name_semb == sem);
            myfarm.Sembrados.Remove(semim);
            semim.riego =enc;
            
            myfarm.Sembrados.Add(semim);

        }
        public void OnOff_Techo(string sem,bool enc){
            Sembrado semim= myfarm.Sembrados.First(j => j.Name_semb == sem);
            myfarm.Sembrados.Remove(semim);
            semim.techo =enc;
            myfarm.Sembrados.Add(semim);
        }
        public void Actualizar_crecimiento(string nombre,string esta){
            Sembrado lule=myfarm.Sembrados.First(j => j.Name_semb == nombre);
            myfarm.Sembrados.Remove(lule);
            lule.Estado =esta;
            myfarm.Sembrados.Add(lule);
            
        }
        
        #endregion  Methods

    }
}