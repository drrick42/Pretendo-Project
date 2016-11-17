using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{ 
    /// <summary>
    /// Delegate for changing lives
    /// </summary>
    /// <param name="e"></param>
    public delegate void LifeCounter(LifeEvent e);
    public abstract class LifeEvent : EventArgs
    {
        public int Lives { get; set; }
        public LifeEvent()
        {
        }
    }

    public class IncEvent : LifeEvent
    {
        public IncEvent() : base() 
        {
            Lives = 1;
        }
    }

    public class DecEvent : LifeEvent
    {
        public DecEvent() : base() 
        {
            Lives = -1;
        }
    }

    /// <summary>
    /// Delegate for Collecting coins
    /// </summary>
    /// <param name="e"></param>
    public delegate void CoinCollector(CoinEvent e);
    public class CoinEvent : EventArgs
    {
        public int Coin = 1;
        public CoinEvent()
        {
        }
    }

    /// <summary>
    /// Delegate for collecting points
    /// </summary>
    /// <param name="e"></param>
    public delegate void PointCollector(PointEvent e);
    public class PointEvent : EventArgs
    {
        public int Points { get; set; }
        public PointEvent(int points)
        {
            Points = points;
        }
    }
}
