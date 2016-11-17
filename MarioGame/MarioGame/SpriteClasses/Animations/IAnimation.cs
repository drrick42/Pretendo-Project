using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface IAnimation
    {
        int GetNextFrame(int previousFrame);
    }
}
