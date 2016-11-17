using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class MarioDamageCommand : MarioPowerUpCommand
    {
        public MarioDamageCommand(PlayerChar character)
            : base(character)
        { }

        public override void Execute()
        {
            receiver.DamageTransition();
        }
    }
}
