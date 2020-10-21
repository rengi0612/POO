using System;
using Granjirilla.Hacienda;
using System.Collections.Generic;
namespace Granjirilla.Interfaz
{
    public class Info_mostrar{
        
        #region Properties
        
        #endregion Properties
        #region Initialize
        //public Sis_control(){}
        
        #endregion Initialize
        #region Methods
        public void Menu(){
            
            Console.WriteLine("1.Consultas");
            Console.WriteLine("2.Operaciones");
            Console.Write("Seleccion:");
            

        }
        public void Aviso(string mensaje){
            Console.WriteLine("{0}",mensaje);
        }
        public string Leer(){
            return Console.ReadLine();
        }
        public void Consultas(){
            Console.Clear();            
            Console.WriteLine("Informacion");
            Console.WriteLine("1.Plantas");
            Console.WriteLine("2.Sembrados");
            Console.WriteLine("3.Robots");
            Console.WriteLine("4.Bodega");
            Console.WriteLine("Volver menu(5)");
            Console.Write("Seleccion:");
            
        }
        public void Operaciones(){
            Console.Clear();
            Console.WriteLine("Operaciones");
            Console.WriteLine("1.Hacienda");
            Console.WriteLine("2.Robots");
            Console.WriteLine("3.Bodega");
            Console.WriteLine("4.Agregar nuevo tipo Semilla");
            Console.WriteLine("5.Agregar sembrado");
            Console.WriteLine("6.Agregar en area sembrados de reserva");
            Console.WriteLine("Volver menu(7)");
            Console.Write("Seleccion:");
            //
        }
        public void Operaciones_Hacienda(){
            Console.Clear();
            Console.WriteLine("Operaciones Hacienda");
            Console.WriteLine("1.Cosechar");
            Console.WriteLine("2.Sembrar");
            Console.WriteLine("3.Limpiar");
            Console.WriteLine("4.Encender (Uv,Techo,Agua) sembrado");
            Console.WriteLine("5.Apagar (Uv,Techo,Agua) sembrado");
            Console.WriteLine("Volver menu(7)");
            Console.Write("Seleccion:");
            //
        }
        public void Operaciones_Robots(){
            Console.Clear();
            Console.WriteLine("Operaciones Robots");
            Console.WriteLine("1.Crear nuevo");
            Console.WriteLine("2.Mandar a descanzar");
            Console.WriteLine("3.Mandar a ubicacion");
            Console.WriteLine("Volver menu(4)");
            Console.Write("Seleccion:");
            //
        }
        public void Menu_ubicaciones(){
            Console.Clear();
            Console.WriteLine("Ubicaciones Robots");
            Console.WriteLine("1.Bodega");
            Console.WriteLine("2.Descanzar");
            Console.WriteLine("3.Centro_carga");
            Console.WriteLine("4.Mantenimiento");
            Console.WriteLine("Volver menu(5)");
            Console.Write("Seleccion:");
            //
        }

        public void Operaciones_Bodega(){
            Console.Clear();
            Console.WriteLine("Operaciones Bodega");
            Console.WriteLine("1.Agregar stock semillas");
            Console.WriteLine("2.Agregar Robot");
            Console.WriteLine("Volver menu(3)");
            Console.Write("Seleccion:");
            //
        }
        public void Grapich_Sembrado(Sembrado migra){
            
            Console.WriteLine("-----------------------");
            Console.WriteLine("|Nombre:{0,16}|",migra.Name_semb);
            Console.WriteLine("|Cultivo:{0,15}|",migra.Plantas.Type);
            Console.WriteLine("|Riego: {0,16}|",migra.riego ? "Activado" : "Desactivado");
            Console.WriteLine("|Techo: {0,16}|",migra.techo ? "Activado" : "Desactivado");
            Console.WriteLine("|Luces UV: {0,13}|",migra.UV ? "Activadas" : "Desactivadas");
            
        }
        public void Grapich_Robot(Robot milo){
            
            Console.WriteLine("-----------------------");
            Console.WriteLine("|Serial:{0,16}|",milo.Code);
            Console.WriteLine("|Tipo:{0,18}|",milo.Type);
            Console.WriteLine("|Energia:{0,15}|",milo.Energy);
            Console.WriteLine("|Durabilidad:{0,11}|",milo.Durability);
            Console.WriteLine("|Ubicacion:{0,13}|",milo.Ubicacion);
            
        }
        public void Grapich_Bodega(Bodega bode){
            Console.Clear();
            Console.WriteLine("-----BODEGA-----");
            Console.WriteLine("Produccion_almacenada:");
            foreach(Tuple<string,string> produc in bode.Produccion_almacenada){
                Console.WriteLine(("").PadRight(23, '-'));
                Console.WriteLine("|Tipo:{0,16}|",produc.Item1);
                Console.WriteLine("|Cantidad:{0,10}Kg|",produc.Item2);
            }
            Console.WriteLine(("").PadRight(23, '-'));
            Console.WriteLine("Semillas_almacenadas:");
            foreach(Tuple<string,string> semil in bode.Semillas_almacenada){
                Console.WriteLine(("").PadRight(21, '-'));
                Console.WriteLine("|Tipo:{0,14}|",semil.Item1);
                Console.WriteLine("|Cantidad:{0,10}|",semil.Item2);
            }
            Console.WriteLine(("").PadRight(21, '-'));
            Console.WriteLine("Robots_almacenadas:");
            foreach(string robotin in bode.Robots_almacenados){
                Console.WriteLine(("").PadRight(21, '-'));
                Console.WriteLine("|Serial:{0,12}|",robotin);
                
            }
            Console.WriteLine(("").PadRight(21, '-'));
            
        }
        public void Grapich_Plantas(List<Planta> migra){
            Console.Clear();
            Console.WriteLine("-----PLANTAS-----");
            foreach(Planta planti in migra){
                Console.WriteLine(("").PadRight(23, '-'));
                Console.WriteLine("|Tipo:{0,16}|",planti.Type);
            }
            Console.WriteLine(("").PadRight(23, '-'));
            
        }
        public void info_sembrados(List<Sembrado> migra){
            Console.Clear();
            Console.WriteLine("-----SEMBRADOS-----");
            foreach(Sembrado planti in migra){
                Console.WriteLine(("").PadRight(23, '-'));
                Grapich_Sembrado(planti);
            }
            Console.WriteLine(("").PadRight(23, '-'));
            
        }
        public void info_robots(List<Robot> migra){
            Console.Clear();
            Console.WriteLine("-----ROBOTS-----");
            foreach(Robot planti in migra){
                Console.WriteLine(("").PadRight(23, '-'));
                Grapich_Robot(planti);
            }
            Console.WriteLine(("").PadRight(23, '-'));
            
        }
        #endregion  Methods

    }
}