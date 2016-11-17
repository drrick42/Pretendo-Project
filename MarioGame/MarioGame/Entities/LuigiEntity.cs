using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class LuigiEntity : PlayerChar
    {
        public LuigiFireBallEntity FBall { get; set; }
        public Luigi luigi { get; set; }

        public override Vector2 Position
        {
            get { return luigi.Position; }
            set 
            { 
                luigi.Position = value;
                Sprite.Position = value;
            }
        }
        public override Direction Direction {
            get { return luigi.Direction; }
            set { luigi.Direction = value; }
        }
        public override Vector2 Velocity
        {
            get { return luigi.Velocity; }
            set { luigi.Velocity = value; }
        }
        public override Vector2 Acceleration { get; set; }
        public override IAnimation Animation
        {
            get { return luigi.Animation; }
            set { luigi.Animation = value; }
        }

        public override int Width
        {
            get { return luigi.Width; }
            set { }
        }

        public override int Height
        {
            get { return luigi.Height; }
            set { }
        }
        LuigiFactory spriteFactory;

        public LuigiEntity(LuigiFactory factory, Vector2 position) : base()
        {
            spriteFactory = factory;
            HUD.LuigiLifeTracker.Subscribe(this);
            luigi = (Luigi)spriteFactory.getSprite((int)MarioTypes.NORMAL);
            luigi.Position = position;
            Sprite.Position = position;
            luigi.Velocity = new Vector2(0f, 0f);
        }

        public override void ChangeSprite()
        {
            MarioTypes type = CurrentPowerState.TypeEnum;

            if (type == MarioTypes.DEAD)
            {
                PlayBGM("death");
                DeathActionTransition();
            }
            else
            {
                // Get current sprite info
                Vector2 position = Position;
                Vector2 speed = Velocity;
                IAnimation animation = Animation;
                Vector2 accel = Acceleration;

                this.luigi = (Luigi)spriteFactory.getSprite((int)type);

                luigi.Position = position;
                luigi.Velocity = speed;
                luigi.Animation = animation;
            }         
        }
        
        public override void Update(float elapsed)
        {
            CurrentActionState.Update(elapsed);
            CurrentPowerState.Update(elapsed);
            luigi.Update(elapsed);
            Sprite.Position = luigi.Position;
            base.Update(elapsed);

        }

        public override void Draw(SpriteBatch batch)
        {
            luigi.Draw(batch);
            base.Draw(batch);
        }

        public override void ShootFireBall()
        {
            if (CurrentPowerState is MarioFireState)
            {
                FBall = new LuigiFireBallEntity(spriteFactory, Position);
            }
        }
    }
}
