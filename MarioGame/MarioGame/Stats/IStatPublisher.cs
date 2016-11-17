using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{ 
    //Life interface
    public interface ILifePublisher
    {
        event LifeCounter Lifecounter;
        void OnLifeEvent(LifeEvent e);
        void OneUp();
        void DecLife();
    }
    //Coin interface
    public interface ICoinPublisher
    {
        event CoinCollector CoinCollector;
        void OnCoinEvent(CoinEvent e);
        void Coin();
    }
    //Points interface
    public interface IPointPublisher
    {
        event PointCollector PointCollector;
        void OnPointEvent(PointEvent e);
        void Points(int points);
    }
}
