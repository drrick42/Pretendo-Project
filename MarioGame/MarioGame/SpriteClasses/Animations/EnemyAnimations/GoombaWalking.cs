using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class GoombaWalking : IAnimation
    {
        
        public int GetNextFrame(int previousFrame)
        {
            int nextFrame = 2;
            if(previousFrame == 2)
            {
                nextFrame = 3;
            }
            return nextFrame;
        }
        
    }
}
