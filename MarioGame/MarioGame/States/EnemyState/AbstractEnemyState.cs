using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public abstract class AbstractEnemyState : IEnemyState
    {
        protected EnemyStateMachine StateMachine { get; set; }

        protected EnemyEntity Enemy { get; set; }
        protected virtual Vector2 stateAccel
        {
            get
            {
                return new Vector2(0.0f, Constants.GRAVITY);
            }
        }
        protected Direction Direction
        {
            get { return Enemy.Direction; }
            set { Enemy.Direction = value; }
        }
        protected virtual Vector2 Velocity
        {
            get { return Enemy.Velocity; }
            set { Enemy.Velocity = value; }
        }

        protected virtual Vector2 Position
        {
            get { return Enemy.Position; }
            set { Enemy.Position = value; }
        }

        protected IAnimation Animation { get; set; }

        protected Vector2 Acceleration
        {
            get { return Enemy.Acceleration; }
            set { Enemy.Acceleration = value; }
        }

        protected AbstractEnemyState(EnemyStateMachine sm, EnemyEntity enemyEnt)
        {
            StateMachine = sm;
            Enemy = enemyEnt;
        }

        public virtual void ActiveTransition()
        {
            if (Scene.mario.Sprite.Position.X < Enemy.Sprite.Position.X)
            {
                Direction = Direction.LEFT;
            }
            else
            {
                Direction = Direction.RIGHT;
            }
            this.Enter(StateMachine.Active);
        }
        public virtual void HitTransition()
        {
            Velocity = Vector2.Zero;
            if (this is ActiveGoombaState)
            {
                this.Enter(StateMachine.Dead);
            }
            else if(this is ActiveGKoopaState)
            {
                this.Enter(StateMachine.Shell);
            }
            else
            {
                this.Enter(StateMachine.Shell2);
            }
        }

        public virtual void TurnTransition()
        {
            if (Direction == Direction.RIGHT)
            {
                Direction = Direction.LEFT;
            }
            else if (Direction == Direction.LEFT)
            {
                Direction = Direction.RIGHT;
            }
        }
        public void Enter(AbstractEnemyState state)
        {
            Enemy.CurrentEnemyState = state;
            Enemy.Acceleration = state.stateAccel;
            Enemy.Animation = state.Animation;
        }

        public virtual void Update(float elapsed)
        {
            if (Scene.camera.BelowMap(Enemy.Position))
            {
                Enemy.Removed = true;
            }
            Velocity += Acceleration * elapsed;
        }
    }

}
