using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class GreenKoopaWalking : IAnimation
    {
        public int GetNextFrame(int previousFrame)
        {
            int nextFrame = 7;
            if(previousFrame == 7)
            {
                nextFrame = 8;
            }
            return nextFrame;
        }
    }
}
