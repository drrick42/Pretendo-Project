using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public interface IPowerUpState
    {
        void SuperTransition();

        void FireTransition();

        void StarTransition();

        void DamageTransition();

        void DeathPowerTransition();

        void ResetTransition();

        void Update(float elapsed);
    }
}
