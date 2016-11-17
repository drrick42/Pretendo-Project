using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class MarioJumpingAnimation : IAnimation
    {
        public int GetNextFrame(int previousFrame)
        {
            return 4;
        }
    }
}
