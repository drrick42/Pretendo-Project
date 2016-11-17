using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class BrickSmooshAnimation : IAnimation
    {
        public int GetNextFrame(int prevFrame)
        {
            return 10;
        }
    }
}
