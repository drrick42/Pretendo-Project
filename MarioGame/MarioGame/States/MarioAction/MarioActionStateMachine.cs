using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class MarioActionStateMachine
    {
        public MarioIdleState Idle { get; private set; }
        public MarioRunningState Run { get; private set; }
        public MarioCrouchingState Crouch { get; private set; }
        public MarioJumpingState Jump { get; private set; }
        public MarioFallingState Fall { get; private set; }
        public MarioDeadActionState Death { get; private set; }

        public MarioActionStateMachine(PlayerChar player)
        {
            Idle = new MarioIdleState(this, player);
            Run = new MarioRunningState(this, player);
            Crouch = new MarioCrouchingState(this, player);
            Jump = new MarioJumpingState(this, player);
            Fall = new MarioFallingState(this, player);
            Death = new MarioDeadActionState(this, player);
        }

    }
}
