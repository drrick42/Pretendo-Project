using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface IMarioActionState
    {
        void RightTransition();

        void LeftTransition();

        void UpTransition();

        void DownTransition();

        void DeathActionTransition();

        void HopTransition();

        void Update(float elapsed);
    }
}
