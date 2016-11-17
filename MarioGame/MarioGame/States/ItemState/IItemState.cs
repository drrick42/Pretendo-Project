using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace MarioGame
{
    public interface IItemState
    {
        void ActiveTransition();
        void EmergingTransition();
        void InactiveTransition();
        void Update(float elapsed);
        void TurnTransition();

    }
}
