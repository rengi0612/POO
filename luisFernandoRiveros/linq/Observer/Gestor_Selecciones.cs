  
using System;
using System.Collections.Generic;
using linq.Torneo;
namespace linq.Observer
{
    public class Gestor_Selecciones
    {
        #region Properties
        private List<IObserver> suscribers;
        public List<IObserver> Suscribers
        {
            get { return suscribers; }
            set { suscribers = value; }
        }
        #endregion Properties

        #region Initialize
        public Gestor_Selecciones()
        {
            Suscribers = new List<IObserver>();
        }
        #endregion Initialize


        #region Methods
        public void Suscribe(IObserver suscriber)
        {
            Suscribers.Add(suscriber);
        }
        public void Unsuscribe(IObserver suscriber)
        {
            Suscribers.Remove(suscriber);
        }
        public void Notify(int G,int A,int P)
        {
            Suscribers.ForEach(s => {
                s.update(G,A,P);
            });
        }
        #endregion Methods
    }
}