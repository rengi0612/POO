using System;

namespace Practica1.Robots
{
    public abstract class robotPadre
    {
        public int bateria = 30;  
        //la batería está de 1 a 30
        // nivel de arreglo de 1 a 10
        public int estado = 10;
        public int codigo;
        public abstract int verificarBateria();
        public abstract bool verificarEstado();

    }
}