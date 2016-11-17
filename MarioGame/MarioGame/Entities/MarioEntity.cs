using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class MarioEntity : PlayerChar
    {
        public  Mario1 Mario { get; set; }
        public override Vector2 Position
        {
            get { return Mario.Position; }
            set 
            { 
                Mario.Position = value;
                Sprite.Position = value;
            }
        }
        public override Direction Direction {
            get {   return Mario.Direction;     }
            set {   Mario.Direction = value;    }
        }
        public override Vector2 Velocity
        {
            get {   return Mario.Velocity;     }
            set {   Mario.Velocity = value;    }
        }
        public override Vector2 Acceleration { get; set; }
        public override IAnimation Animation
        {
            get { return Mario.Animation; }
            set { Mario.Animation = value; }
        }

        public override int Width
        {
            get { return Mario.Width; }
            set { }
        }

        public override int Height
        {
            get { return Mario.Height; }
            set { }
        }
        MarioFactory spriteFactory;



        public MarioEntity(MarioFactory factory, Vector2 position) : base()
        {
            spriteFactory = factory;
            HUD.MarioLifeTracker.Subscribe(this);
            Mario = (Mario1)spriteFactory.getSprite((int)MarioTypes.NORMAL);
            Mario.Position = position;
            Sprite.Position = position;
            Mario.Velocity = new Vector2(0f, 0f);
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

                this.Mario = (Mario1)spriteFactory.getSprite((int)type);

                Mario.Position = position;
                Mario.Velocity = speed;
                Mario.Animation = animation;
            }         
        }

        public override void Update(float elapsed)
        {
            CurrentActionState.Update(elapsed);
            CurrentPowerState.Update(elapsed);
            Mario.Update(elapsed);
            Sprite.Position = Mario.Position;
            base.Update(elapsed);
        }

        public override void Draw(SpriteBatch batch)
        {
            Mario.Draw(batch);
            base.Draw(batch);
        }

        public override void ShootFireBall()
        {
            Console.WriteLine("shootMario");
            if (CurrentPowerState is MarioFireState)
            {
                FBall = new MarioFireBallEntity(spriteFactory, Position);
                FBall.Position = Position;
            }
        }
    }
}
