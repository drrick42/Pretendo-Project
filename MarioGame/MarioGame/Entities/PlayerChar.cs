using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class PlayerChar : Entity, IMarioActionState, IPowerUpState, ILifePublisher, IPointPublisher
    {

        public virtual Direction Direction { get; set; }

        public virtual IAnimation Animation { get; set; }

        public AbstractFireBallEntity FBall { get; set; }

        public AbstractActionState CurrentActionState { get; set; }
        public MarioActionStateMachine actionSM;

        public AbstractPowerUpState PreviousPowerState { get; set; }
        public AbstractPowerUpState CurrentPowerState { get; set; }
        public MarioPowerUpStateMachine powerSM;

        public float StarTimer { get; set; }

        public PlayerChar()
            : base()
        {
            actionSM = new MarioActionStateMachine(this);
            powerSM = new MarioPowerUpStateMachine(this);
            CurrentActionState = actionSM.Idle;

            CurrentPowerState = powerSM.Standard;
            HUD.PointTracker.Subscribe(this);
            StarTimer = 0;
        }

        public virtual void ChangeSprite()
        {
        }
        
        public override void HandleCollision(Vector2 vector, AABB collision, Entity collider)
        {
            Side result = AABB.SideHit(BoundingBox, collision);

            if (collider is EnemyEntity)
            {
                if(collider is GreenKoopaChar && collider.Velocity == Vector2.Zero & result != Side.TOP)
                {
                    Vector2 vel = new Vector2(5f, 0f);
                    collider.Velocity = vel;
                }
                else if (result != Side.BOTTOM)
                {
                    this.DamageTransition();
                    this.StarTransition();
                }
                else
                {
                    this.HopTransition();
                }
            }
            else if (collider is BlockForm)
            {
                if (result == Side.LEFT || result == Side.RIGHT)
                {
                    Velocity = new Vector2(0, Velocity.Y);
                }
                else
                {
                    Velocity = new Vector2(Velocity.X, 0);
                }
            }
            else if (collider is ItemEntity && !(CurrentPowerState is InvulnerableState))
            {
                if (collider is OneUpMushroomEntity) { OneUp(); }
                if (collider is StarEntity) { StarTransition(); Points(1000); }
                if (collider is MushroomEntity) { SuperTransition(); Points(1000); }
                if (collider is FlowerEntity) { FireTransition(); Points(1000); }
            }
           
        }

        public event LifeCounter Lifecounter;
        public event PointCollector PointCollector;

        public void OnLifeEvent(LifeEvent args)
        {
            Lifecounter(args);
        }
        public void OnPointEvent(PointEvent args)
        {
            PointCollector(args);
        }
        
        public void DecLife()
        {
            LifeEvent e = new DecEvent();
            OnLifeEvent(e);
        }
        public void OneUp()
        {
            PlaySFX("1_up");
            LifeEvent e = new IncEvent();
            OnLifeEvent(e);
        }


        public void Points(int points)
        {
            PointEvent e = new PointEvent(points);
            OnPointEvent(e);
        }

        public Boolean IsSmall()
        {
            return (CurrentPowerState is MarioStandardState) || (CurrentPowerState is MarioMiniStarState);
        }

        public Boolean IsStar()
        {
            return (CurrentPowerState is MarioBigStarState || CurrentPowerState is MarioMiniStarState);
        }

        public void ChangeActionState(AbstractActionState newState)
        {
            if (newState is MarioJumpingState && !(CurrentActionState is MarioFallingState))
            {
                PlaySFX("jump");
            }
            CurrentActionState = newState;
        }

        public void ChangePowerUpState(AbstractPowerUpState newState)
        {
            PreviousPowerState = CurrentPowerState;
            if (newState is MarioSuperState || newState is MarioFireState) PlaySFX("power_up");
            CurrentPowerState = newState;
        }

        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

        public void RightTransition()
        { CurrentActionState.RightTransition(); }

        public void LeftTransition()
        { CurrentActionState.LeftTransition(); }

        public void UpTransition()
        { CurrentActionState.UpTransition(); }

        public void DownTransition()
        { CurrentActionState.DownTransition(); }

        public void DeathActionTransition()
        { CurrentActionState.DeathActionTransition(); }

        public void HopTransition()
        { CurrentActionState.HopTransition(); }

        public void SuperTransition()
        { CurrentPowerState.SuperTransition(); }

        public void FireTransition()
        { CurrentPowerState.FireTransition(); }

        public void StarTransition()
        { CurrentPowerState.StarTransition(); }

        public void DamageTransition()
        {
            CurrentPowerState.DamageTransition();
        }

        public void DeathPowerTransition()
        { CurrentPowerState.DeathPowerTransition(); }
        public void ResetTransition()
        { CurrentPowerState.ResetTransition(); }

        public virtual void ShootFireBall()
        {
            Console.WriteLine("shoot");
            
        }
    }
}
