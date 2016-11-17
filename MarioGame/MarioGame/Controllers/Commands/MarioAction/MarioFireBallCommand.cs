using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    class MarioFireBallCommand : MarioActionCommand
    {
        public MarioFireBallCommand(PlayerChar player)
            : base(player)
        { }

        public override void Execute()
        {
            receiver.ShootFireBall();
        }
    }
}