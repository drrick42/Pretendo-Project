using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class MarioRunningAnimation : IAnimation
    {
        public int GetNextFrame(int previousFrame)
        {
            int nextFrame = 0;
            if (previousFrame == 0)
            {
                nextFrame = 2;
            }
            return nextFrame;
        }
    }
}
