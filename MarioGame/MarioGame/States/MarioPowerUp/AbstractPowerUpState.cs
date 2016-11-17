using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public abstract class AbstractPowerUpState : IPowerUpState
    {
        protected PlayerChar PlayerChar { get; set; }
        protected MarioPowerUpStateMachine StateMachine { get; set; }
        protected AbstractPowerUpState previousState
        {
            get { return PlayerChar.PreviousPowerState; }
        }
        protected float StarTimer
        {
            get { return PlayerChar.StarTimer; }
            set { PlayerChar.StarTimer = value; }
        }
        public MarioTypes TypeEnum { get; set; }

        protected AbstractPowerUpState(MarioPowerUpStateMachine sm, PlayerChar player)
        {
            StateMachine = sm;
            PlayerChar = player;
        }

        public virtual void SuperTransition()
        {
            this.Enter(StateMachine.Super);
        }

        public virtual void FireTransition()
        {
            this.Enter(StateMachine.Fire);
        }

        public virtual void StarTransition()
        {
            this.Enter(StateMachine.StarBig);
        }

        public virtual void DamageTransition()
        {
            this.Enter(StateMachine.Standard);
            PlayerChar.Velocity = Vector2.Zero;
        }

        public virtual void DeathPowerTransition()
        {
            this.Enter(StateMachine.Standard);
            this.Enter(StateMachine.Dead);
        }

        public virtual void ResetTransition()
        {
            this.Enter(StateMachine.Standard);
        }

        public virtual void Enter(AbstractPowerUpState state)
        {
            // Save direction
            Direction direction = PlayerChar.Direction;

            PlayerChar.ChangePowerUpState(state);
            PlayerChar.ChangeSprite();

            PlayerChar.Direction = direction;
        }

        
        public virtual void Update(float elapsed)
        {
            if (TimeLimit.TimeOut) DeathPowerTransition();
        }
    }
}
