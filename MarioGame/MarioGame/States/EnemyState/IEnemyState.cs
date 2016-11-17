using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace MarioGame
{
    public interface IEnemyState
    {
        void ActiveTransition();
        void HitTransition();
        void TurnTransition();
        void Update(float elapsed);
    }
}
