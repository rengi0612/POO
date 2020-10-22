using System;

namespace Practica1.Plantas
{
    public class Planta
    {
        public string nombre { get; set; } // Nombre de la planta
        public int necesidadLuz { get; set; } // cantidad de horas de luz al día
        public int produccionTotal { get; set; } // Cantidad de producción en total en Kg
        public int semillas { get; set; } // Cantidad de semilla dadas por la planta #
        public int tasaCrecimiento { get; set; } // Velocidad de desarrollo #
    }
}