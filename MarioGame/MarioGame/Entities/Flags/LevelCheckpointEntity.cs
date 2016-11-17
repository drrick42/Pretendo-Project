using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class LevelCheckpointEntity : FlagEntity
    {
        public int ID { get; set; }
        public LevelCheckpointEntity(Scene scene, ObstacleFactory factory, Vector2 position, int ID)
            : base(scene,factory, position)
        {
            Flag = (AbstractObstacle)Factory.getFlag((int)flagTypes.CHECKPOINT);
            Flag.Position = position;
            Sprite.Position = position;
            this.ID = ID;
        }
        public override void SetHit()
        {
            if (!isHit)
            {
                PlaySFX("checkpoint");
                Scene.Checkpoint = this.Position;
                Scene.LastCheckpoint = this.ID;
                Collidable = false;
            }
                
            base.SetHit();
        }

    }
}