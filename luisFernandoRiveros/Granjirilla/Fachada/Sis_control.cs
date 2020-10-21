using System;
using System.Linq;
using Granjirilla.Sistema;
using Granjirilla.Interfaz;
using Granjirilla.Hacienda;
namespace Granjirilla.Fachada
{
    public class Sis_control{
        
        #region Properties
        public Control control_panel = new Control();
        public Info_mostrar salida = new Info_mostrar();
        #endregion Properties
        #region Initialize
        public Sis_control()
        {
            
        }
        
        #endregion Initialize
        #region Methods
        public void inicio(){
            //control_panel.myfarm.add_robot("10006","mantenimiento");
            Console.Clear(); 
            Console.WriteLine("Bienvenido al panel de control");
            salida.Menu();
            switch(Int32.Parse(salida.Leer())){
                case 1:
                    salida.Consultas();
                    reg_consul(Int32.Parse(Console.ReadLine()));
                    break;
                case 2:
                    salida.Operaciones();
                    reg_Oper(Int32.Parse(Console.ReadLine()));
                    break;
                default:
                    
                    salida.Aviso("Opcion no valida");
                    System.Threading.Thread.Sleep(2000);
                    inicio();
                    
                    break;
            }
            
            //Sembrado lule=control_panel.myfarm.Sembrados.First(j => j.Name_semb == "siembra 1");
            //Robot pinpom=control_panel.myfarm.Robots_gran.First(j => j.Code == "10001");
            //salida.Grapich_Sembrado(lule);
            //salida.Grapich_Robot(pinpom);
            //salida.Grapich_Bodega(control_panel.myfarm.Bodega_gran);
            //salida.Grapich_Plantas(control_panel.myfarm.Plantas_gran);
        }
        public void reg_consul(int pe){
            switch(pe){
                case 1:
                    salida.Grapich_Plantas(control_panel.myfarm.Plantas_gran);
                    break;
                case 2:
                    salida.info_sembrados(control_panel.myfarm.Sembrados);
                    break;
                case 3:
                    salida.info_robots(control_panel.myfarm.Robots_gran);
                    break;
                case 4:
                    salida.Grapich_Bodega(control_panel.myfarm.Bodega_gran);
                    break;
                case 5:
                    inicio();
                    break;
                default:
                    salida.Aviso("Opcion no valida");
                    break;
            }
            salida.Aviso("Volver a menu(x)");
            if(salida.Leer()=="x"){inicio();}
        }
        public void reg_Oper(int pe){
            string siem1,siem2,siem3,siem4,siem5,siem6,siem7,siem8,siem9;
            switch(pe){
                case 1:
                    salida.Operaciones_Hacienda();
                    Oper_Hacienda(Int32.Parse(Console.ReadLine()));
                    break;
                case 2:
                    salida.Operaciones_Robots();
                    Oper_Robots(Int32.Parse(Console.ReadLine()));
                    break;
                case 3:
                    salida.Operaciones_Bodega();
                    Oper_Bodega(Int32.Parse(Console.ReadLine()));
                    break;
                case 4:
                    salida.Aviso("iNGRESE NOMBRE Semilla:");
                    siem1=salida.Leer();
                    
                    if(control_panel.Consultar_planta(siem1)){
                        salida.Aviso("Tasa de crecimiento:");
                        siem3=salida.Leer();
                        salida.Aviso("horas de luz por dia:");
                        siem4=salida.Leer();
                        salida.Aviso("litros de agua por dia::");
                        siem5=salida.Leer();
                        salida.Aviso("bolsas abono a la semana:");
                        siem6=salida.Leer();
                        salida.Aviso("Espacio necesario(m^2):");
                        siem7=salida.Leer();
                        salida.Aviso("kg de produccion promedio:");
                        siem8=salida.Leer();
                        salida.Aviso("semillas por kg de produccion:");
                        siem9=salida.Leer();
                        control_panel.Agregar_planta(siem1,Int32.Parse(siem3),Int32.Parse(siem4),Int32.Parse(siem5),
                        Int32.Parse(siem6),Int32.Parse(siem7),Int32.Parse(siem8),Int32.Parse(siem9));
                    }
                    else{salida.Aviso("Tipo de planta ya existe");}
                    break;
                case 5:
                    salida.Aviso("iNGRESE NOMBRE SEMBRADO:");
                    siem1=salida.Leer();
                    salida.Aviso("Planta a Cultivar:");
                    siem2=salida.Leer();
                    if(control_panel.Consultar_planta(siem2)){
                        control_panel.Agregar_sembrado(siem1,siem2);
                    }
                    else{salida.Aviso("Planta a Cultivar no valida:");}
                    break;
                case 6:
                    salida.Aviso("iNGRESE NOMBRE SEMBRADO:");
                    siem1=salida.Leer();
                    salida.Aviso("Planta a Cultivar:");
                    siem2=salida.Leer();
                    if(control_panel.Consultar_planta(siem2)){
                        control_panel.Agregar_sembradoReserva(siem1,siem2);
                    }
                    else{salida.Aviso("Planta a Cultivar no valida:");}
                    break;
                case 7:
                    inicio();
                    break;
                 
                default:
                    salida.Aviso("Opcion no valida");
                    break;
            }
            salida.Aviso("Volver a menu(x)");
            if(salida.Leer()=="x"){inicio();}
        }
        public void Oper_Hacienda(int pe){
            salida.Aviso("iNGRESE NOMBRE SEMBRADO:");
            string siem=salida.Leer();
            int siem2;
            if(control_panel.Consultar_siembra(siem)){
            Sembrado siembra_act=control_panel.myfarm.Sembrados.First(j =>(j.Name_semb==siem));
            switch(pe){
                
                case 1:
                //semilla,germinando,primordio final,maduro
                    if(siembra_act.Estado!="maduro"){alarm_system("intentar cosechar cultivo no maduro");}
                    if(siembra_act.riego){alarm_system("intentar cosechar cultivo en riego");}
                    else{
                    try{Robot pepo=control_panel.myfarm.Robots_gran.First(j => (j.Type == "recoleccion"&&j.Ubicacion=="Bodega"));
                    control_panel.Mandar_Trabajar(siem,pepo.Code);
                     }
                    catch (InvalidOperationException){
                        salida.Aviso("No Hay robots disponibles");
                    }}
                    break;
                case 2:
                    if(siembra_act.Estado!="vacio"){alarm_system("intentar sembrar en un cultivo iniciado");}
                    else{
                        //Comprueba que hay suficientes semillas para hacer el sembrado de 1 hectarea(10000m^2), teniendo en cuenta espacio 
                        //necesario por el tipo de planta
                        if(control_panel.Consultar_bodegaSemilla(siembra_act.Plantas.Type)>=(10000/siembra_act.Plantas.conditions_size))
                            try{
                                Robot pepo=control_panel.myfarm.Robots_gran.First(j => (j.Type == "sembrado"&&(j.Ubicacion=="Bodega"||j.Ubicacion=="Descanso")));
                                control_panel.Mandar_Trabajar(siem,pepo.Code);
                                //se restan la cantidad de semillas en stock que el robot va a sembrar
                                control_panel.add_bodegasemilla(siembra_act.Plantas.Type,-10000/siembra_act.Plantas.conditions_size);
                            }
                            catch (InvalidOperationException){
                                salida.Aviso("No Hay robots disponibles");
                            }
                        else{alarm_system("falta de semillas o no existe en stock");}
                    }
                    break;
                    
                case 3:
                    try{Robot pepo=control_panel.myfarm.Robots_gran.First(j => (j.Type == "limpieza"&&(j.Ubicacion=="Bodega"||j.Ubicacion=="Descanso")));
                    control_panel.Mandar_Trabajar(siem,pepo.Code);
                     }
                    catch (InvalidOperationException){
                        salida.Aviso("No Hay robots disponibles");
                    }
                    break;
                    
                case 4:
                    salida.Aviso("1.Luces Uv:");
                    salida.Aviso("2.Techo:");
                    salida.Aviso("3.RiegoAgua:");
                    siem2=Int32.Parse(salida.Leer());
                    if(siem2==1){
                        if(siembra_act.UV){salida.Aviso("ya esta activado");}
                        else{control_panel.OnOff_UV(siem,true);}
                    }
                    else if(siem2==2){
                        if(siembra_act.techo){salida.Aviso("ya esta activado");}
                        else{control_panel.OnOff_Techo(siem,true);}
                    }
                    else if(siem2==3){
                        if(siembra_act.riego){salida.Aviso("ya esta activado");}
                        else{control_panel.OnOff_Riego(siem,true);}
                    }
                    else{salida.Aviso("Opcion no valida");}
                    break;
                case 5:
                    salida.Aviso("1.Luces Uv:");
                    salida.Aviso("2.Techo:");
                    salida.Aviso("3.RiegoAgua:");
                    siem2=Int32.Parse(salida.Leer());
                    if(siem2==1){
                        if(!siembra_act.UV){salida.Aviso("ya esta apagado");}
                        else{control_panel.OnOff_UV(siem,false);}
                    }
                    else if(siem2==2){
                        if(!siembra_act.techo){salida.Aviso("ya esta desactivado");}
                        else{control_panel.OnOff_Techo(siem,false);}
                    }
                    else if(siem2==3){
                        if(!siembra_act.riego){salida.Aviso("ya esta desactivado");}
                        else{control_panel.OnOff_Riego(siem,false);}
                    }
                    else{salida.Aviso("Opcion no valida");}
                    break;
                case 6:
                    inicio();
                    break;
                
                default:
                    salida.Aviso("Opcion no valida");
                    break;
            }
            }
            else{salida.Aviso("siembrado inexistente");}
            salida.Aviso("Volver a menu(x)");
            if(salida.Leer()=="x"){inicio();}
        }
        public void Oper_Robots(int pe){
            string temp1;
            int temp2;
            switch(pe){
                case 1:
                    salida.Aviso("ingrese serial:");
                    temp1=salida.Leer();
                    if(!control_panel.Consultar_Robot(temp1)){
                        //tipo de robot (sembrado, recoleccion, limpieza)
                        salida.Aviso("Seleccione tipo:");
                        salida.Aviso("1.sembrado:");
                        salida.Aviso("2.recoleccion:");
                        salida.Aviso("3.limpieza:");
                        temp2=Int32.Parse(salida.Leer());
                        if(temp2==1){control_panel.Agregar_robot(temp1,"sembrado");}
                        else if(temp2==2){control_panel.Agregar_robot(temp1,"recoleccion");}
                        else if(temp2==3){control_panel.Agregar_robot(temp1,"limpieza");}
                        else{salida.Aviso("seeleccion invalida");}
                    
                    }
                    else{salida.Aviso("Serial ya existente");}
                    break;
                case 2:
                    salida.Aviso("ingrese serial:");
                    temp1=salida.Leer();
                    if(control_panel.Consultar_Robot(temp1)){control_panel.Mandar_Descansar(temp1);}
                    else{salida.Aviso("Robot no existe");}
                    
                    break;
                case 3:
                    salida.Aviso("ingrese serial:");
                    temp1=salida.Leer();
                    salida.Menu_ubicaciones();
                    temp2=Int32.Parse(salida.Leer());
                    Oper_Ubications(temp1,temp2);
                    break;
                case 4:
                    inicio();
                    break;
                default:
                    salida.Aviso("Opcion no valida");
                    inicio();
                    break;
            }
            salida.Aviso("Volver a menu(x)");
            if(salida.Leer()=="x"){inicio();}
        }
        public void Oper_Bodega(int pe){
            string pla;
            int cantidad;
            switch(pe){
                case 1:
                    salida.Aviso("ingresar nombre semilla");
                    pla=salida.Leer();
                    if(control_panel.Consultar_planta(pla)){
                        salida.Aviso("ingresar cantidad:");
                        cantidad=Int16.Parse(salida.Leer());
                        control_panel.add_bodegasemilla(pla,cantidad);
                    }
                    else{salida.Aviso("No se tiene informacion acerca de la semilla, por favor dirijase a menu->operaciones->agregar nuevo tipo de semilla");}
                    break;
                case 2:
                    salida.Aviso("ingresar serial  robot");
                    pla=salida.Leer();
                    if(control_panel.Consultar_Robot(pla)){
                        control_panel.Agregar_robotBodega(pla);
                    }
                    else{salida.Aviso("El robot que quiere guardar en bodega no existe");}
                    break;
                case 3:
                    inicio();
                    break;
                default:
                    salida.Aviso("Opcion no valida");
                    inicio();
                    break;
            }
            salida.Aviso("Volver a menu(x)");
            if(salida.Leer()=="x"){inicio();}
        }
        public void Oper_Ubications(string ser,int pe){
            
            switch(pe){
                case 1:
                    control_panel.Mandar_Ubicacion(ser,"bodega");
                    break;
                case 2:
                    control_panel.Mandar_Ubicacion(ser,".Descanzar");
                    break;
                case 3:
                    control_panel.Mandar_Ubicacion(ser,"Centro_carga");
                    break;
                case 4:
                    control_panel.Mandar_Ubicacion(ser,"Mantenimiento");
                    
                    break;
                case 5:
                    inicio();
                    break;
                default:
                    salida.Aviso("Opcion no valida");
                    inicio();
                    break;
            }
            salida.Aviso("Volver a menu(x)");
            if(salida.Leer()=="x"){inicio();}
        }
        
        public void alarm_system(string pel){
            salida.Aviso("se activo sistema de alarma por "+pel);
            salida.Aviso("cierre de la operacion");
            Console.Beep();
        }

        #endregion  Methods

    }
}