using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class EnemyEntity : Entity, IEnemyState, IPointPublisher
    {
        public EnemyStateMachine enemySM;
        public IEnemyState CurrentEnemyState { get; set; }
        public Enemy1 enemy { get; set; }
        public Direction Direction
        {
            get { return enemy.Direction; }
            set { enemy.Direction = value; }
        }
        public override int Width { get; set; }

        public override int Height { get; set; }

        public override Vector2 Position
        {
            get { return enemy.Position; }
            set 
            { 
                enemy.Position = value;
                Sprite.Position = value;
            }
        }
        public override Vector2 Velocity
        {
            get { return enemy.Velocity; }
            set { enemy.Velocity = value; }
        }
        public override Vector2 Acceleration
        {
            get { return enemy.Acceleration; }
            set { enemy.Acceleration = value; }
        }
        public IAnimation Animation
        {
            get { return enemy.Animation; }
            set { enemy.Animation = value; }
        }
        public EnemyFactory spriteFactory;

        protected EnemyEntity(EnemyFactory factory) : base()
        {
            spriteFactory = factory;
            HUD.PointTracker.Subscribe(this);
        }
        public override void HandleCollision(Vector2 vector, AABB collisionArea, Entity collider)
        {
            Side result = AABB.SideHit(BoundingBox, collisionArea);
            {
                if (collider is MarioFireBallEntity | collider is LuigiFireBallEntity) { this.HitTransition(); }
                else if (collider is PlayerChar)
                    {
                        if (result == Side.TOP)
                        {
                            if(CurrentEnemyState is ShellState && this is GreenKoopaChar)
                            {
                                
                            }
                            Bounce(result, collisionArea, collider);
                            PlaySFX("enemy_bounce");
                            Points(100);
                            this.HitTransition();
                        }
                        else if (((PlayerChar)collider).IsStar())
                        {
                            Bounce(result, collisionArea, collider);
                            PlaySFX("enemy_bounce");
                            Points(100);
                            this.HitTransition();
                        }
                        else if(this.CurrentEnemyState is ShellState && collider is PlayerChar)
                        {
                            if(collider.Velocity.X*this.Velocity.X < 0){}
                        }
                    }
                    else if (collider is EnemyEntity)
                    {
                        if ((result == Side.LEFT && Direction == Direction.LEFT) || (result == Side.RIGHT && Direction == Direction.RIGHT))
                        {
                            Bounce(result, collisionArea, collider);
                            this.TurnTransition();
                        }
                    }
                    else if (collider is BlockForm)
                    {
                        if ((result == Side.LEFT && Direction == Direction.LEFT) || (result == Side.RIGHT && Direction == Direction.RIGHT))
                        {
                            this.TurnTransition();
                            Velocity = new Vector2(Velocity.X, Velocity.Y);
                        }
                        else
                        {
                            Velocity = new Vector2(Velocity.X, 0);
                        }
                    }

            }
        }
        public event PointCollector PointCollector;

        public void OnPointEvent(PointEvent args)
        {
            PointCollector(args);
        }
        public void Points(int points)
        {
            PointEvent e = new PointEvent(points);
            OnPointEvent(e);
        }
        public override void Update(float elapsed)
        {
            CurrentEnemyState.Update(elapsed);
            enemy.Update(elapsed);
            Sprite.Position = enemy.Position;

            base.Update(elapsed);
        }

        public override void Draw(SpriteBatch batch)
        {
            enemy.Draw(batch);
            base.Draw(batch);
        }

        public virtual void ActiveTransition()
        {
            CurrentEnemyState.ActiveTransition();
        }
        public virtual void HitTransition()
        {
            CurrentEnemyState.HitTransition();
        }
        public virtual void TurnTransition()
        {
            CurrentEnemyState.TurnTransition();
        }
        public virtual void ChangeState(AbstractEnemyState newState)
        {
            CurrentEnemyState = newState;
        }
    }

}
