using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class GoombaDead : IAnimation
    {
        public int GetNextFrame(int previousFrame)
        {
            int newFrame = 3;
            return newFrame;
        }
    }
}