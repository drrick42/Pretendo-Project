using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class MarioPowerUpStateMachine
    {
        public MarioStandardState Standard { get; private set; }
        public MarioSuperState Super { get; private set; }
        public MarioFireState Fire { get; private set; }
        public MarioMiniStarState StarMini { get; private set; }
        public MarioBigStarState StarBig { get; private set; }
        public MarioDeadState Dead { get; private set; }
        public InvulnerableState Invul { get; private set; }

        public MarioPowerUpStateMachine(PlayerChar player)
        {
            Standard = new MarioStandardState(this, player);
            Super = new MarioSuperState(this, player);
            Fire = new MarioFireState(this, player);
            StarMini = new MarioMiniStarState(this, player);
            StarBig = new MarioBigStarState(this, player);
            Dead = new MarioDeadState(this, player);
            Invul = new InvulnerableState(this, player);
        }
    }
}
