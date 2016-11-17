using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class BrickAnimation : IAnimation
    {
        public int GetNextFrame(int prevFrame)
        {
            return 5;
        }
    }
}
