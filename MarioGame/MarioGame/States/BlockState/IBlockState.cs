using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface IBlockState
    {
        void HitTransition();
        void BigHitTransition();
        void ResetTransition();

        void Update(float elapsed);
    }
}
