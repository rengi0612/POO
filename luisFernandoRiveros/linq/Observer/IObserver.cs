using linq.Torneo;
namespace linq.Observer
{
    public interface IObserver
    {
        void update(int pun,int gol,int asi);
        
    }
}