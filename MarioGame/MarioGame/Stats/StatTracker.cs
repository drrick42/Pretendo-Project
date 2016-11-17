using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{

    /// <summary>
    /// changes lives based on event
    /// </summary>
    public class LifeTracker
    {
        Scene scene;

        public int Lives;

        public bool Dead { get; set;}

        public LifeTracker(Scene scene)
        {
            this.scene = scene;
            Lives = 3;
            Dead = false;
        }

        public void ChangeLife(LifeEvent e)
        {
            Lives += e.Lives;
            if (Lives == 0)
            {
                scene.GameOver();
            }
            else if (e is DecEvent)
            {
                Dead = true;
            }
        }
        public void Subscribe(ILifePublisher publisher)
        {
            publisher.Lifecounter += new LifeCounter(ChangeLife);
        }
    }

    /// <summary>
    /// increments points
    /// </summary>
    public class PointTracker
    {
        public int Points = 0;
        public void AddPoints(PointEvent e)
        {
            Points += e.Points;
            Console.WriteLine("Points: " + Points);
        }
        public void Subscribe(IPointPublisher publisher)
        {
            publisher.PointCollector += new PointCollector(AddPoints);
        }
    }

    /// <summary>
    /// increments coins
    /// </summary>
    public class CoinTracker : ILifePublisher
    {
        public event LifeCounter Lifecounter;
        public CoinTracker()
        {
            HUD.MarioLifeTracker.Subscribe(this);
            if (HUD.LuigiLifeTracker != null) HUD.LuigiLifeTracker.Subscribe(this);
        }

        public int Coins = 0;
        
        public void AddCoins(CoinEvent e)
        {
            Coins += e.Coin;
            if (Coins % 100 == 0)
            {
                OneUp();
            }
            Console.WriteLine("Coins: " + Coins);
            
        }

        public void OnLifeEvent(LifeEvent args)
        {
            Lifecounter(args);
        }
        public void DecLife()
        {
            LifeEvent e = new DecEvent();
            OnLifeEvent(e);
        }
        public void OneUp()
        {
            LifeEvent e = new IncEvent();
            OnLifeEvent(e);
        }
        public void Subscribe(ICoinPublisher publisher)
        {
            publisher.CoinCollector += new CoinCollector(AddCoins);
        }
    }
   
}
