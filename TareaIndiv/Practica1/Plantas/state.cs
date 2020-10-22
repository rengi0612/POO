using System;
using System.Text;

namespace Practica1.Plantas
{
    public class state
    {
        int[] etapas = {2,1,1,1};
        public string estado(int minuto, int tasa)
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < 4; i++){
                etapas[i] = etapas[i] * tasa;
            }
            if((now.Minute - minuto)<etapas[0])
            {
                return "Semilla";
            }
            else if ((now.Minute - minuto)<(etapas[1]+etapas[0]) && (now.Minute - minuto)>=etapas[0])
            {
                return "Brote";
            }
            else if ((now.Minute - minuto)<(etapas[2]+etapas[1]+etapas[0]) && (now.Minute - minuto)>=(etapas[1]+etapas[0]))
            {
                return "Floración";
            }
            else if ((now.Minute - minuto)<(etapas[3]+etapas[2]+etapas[1]+etapas[0]) && (now.Minute - minuto)>=(etapas[2]+etapas[1]+etapas[0]))
            {
                return "Maduración";
            }
            else
            {
                return "sacar";
            }
        }
    }
}