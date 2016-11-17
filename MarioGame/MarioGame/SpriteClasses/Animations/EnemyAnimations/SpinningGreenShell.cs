using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class SpinningGreenShell : IAnimation
    {
        public int GetNextFrame(int previousFrame)
        {
            int nextFrame = 9;
            if (previousFrame == 9)
            {
                nextFrame = 10;
            }
            else if (previousFrame == 10)
            {
                nextFrame = 11;
            }
            else if (previousFrame == 11)
            {
                nextFrame = 12;
            }
            else if (previousFrame == 12)
            {
                nextFrame = 13;
            }
            return nextFrame;
        }
    }
}