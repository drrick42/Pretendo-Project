using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public abstract class AbstractActionState : IMarioActionState
    {
        protected MarioActionStateMachine StateMachine { get; set; }

        protected PlayerChar PlayerChar { get; set; }

        protected virtual Vector2 stateAccel 
        { 
            get
            {
                if (Direction == Direction.RIGHT) return new Vector2(-1 * Constants.FRICTION, Constants.GRAVITY);
                else return new Vector2(Constants.FRICTION, Constants.GRAVITY);
            }
        }

        protected Vector2 Position
        {
            get { return PlayerChar.Position; }
            set { PlayerChar.Position = value; }
        }
        protected Direction Direction
        {
            get { return PlayerChar.Direction; }
            set { PlayerChar.Direction = value; }
        }
        protected Vector2 Velocity
        {
            get { return PlayerChar.Velocity; }
            set { PlayerChar.Velocity = value; }
        }

        protected IAnimation Animation { get; set; }

        protected Vector2 Acceleration
        {
            get { return PlayerChar.Acceleration;  }
            set { PlayerChar.Acceleration = value; }
        }

        protected AbstractActionState(MarioActionStateMachine sm, PlayerChar player)
        {
            StateMachine = sm;
            PlayerChar = player;
        }

        public virtual void RightTransition()
        {
            this.Enter(StateMachine.Run);
            Direction = Direction.RIGHT;
        }

        public virtual void LeftTransition()
        {
            this.Enter(StateMachine.Run);
            Direction = Direction.LEFT;
        }

        public virtual void UpTransition()
        {
            this.Enter(StateMachine.Jump);
            Velocity = new Vector2(Velocity.X, Constants.MARIO_JUMP_SPEED);
        }

        public virtual void DownTransition()
        {
            if (!PlayerChar.IsSmall())
            {
                this.Enter(StateMachine.Crouch);
            }
        }

        public virtual void DeathActionTransition()
        {
            this.Enter(StateMachine.Death);
            Velocity = new Vector2(0f, Constants.MARIO_JUMP_SPEED);
            PlayerChar.Collidable = false;
        }

        public virtual void HopTransition()
        {
            this.Enter(StateMachine.Jump);
            Velocity = new Vector2(Velocity.X, Constants.MARIO_HOP_SPEED);
        }

        public void Enter(AbstractActionState state)
        {
            PlayerChar.ChangeActionState(state);
            PlayerChar.Acceleration = state.stateAccel;
            PlayerChar.Animation = state.Animation;
        }

        public virtual void Update(float elapsed) {
            Velocity += Acceleration * elapsed;
            BoundPosition();
        }

        protected void BoundPosition()
        {
            Vector2 result = new Vector2(Position.X, Position.Y);

            float rightEdge = Position.X + PlayerChar.Width;

            // Check horizontal Scene.Bound
            if (rightEdge > Scene.Bound.Width)
            {
                result.X -= rightEdge - Scene.Bound.Width;
                Velocity = new Vector2(0f, Velocity.Y);
            }
            else if (Position.X < 0)
            {
                result.X += 0 - Position.X;
                Velocity = new Vector2(0f, Velocity.Y);
            }

            float topEdge = Position.Y - PlayerChar.Height;
            // Check vertical Scene.Bound
            if (Position.Y > Scene.Bound.Height)
            {
                PlayerChar.DeathPowerTransition();
            }
            else if (topEdge < 0)
            {
                result.Y += 0 - topEdge;
                Velocity = new Vector2(Velocity.X, 0f);
            }

            Position = result;
        }
    }
}
