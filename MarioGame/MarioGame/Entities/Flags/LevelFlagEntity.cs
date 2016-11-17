using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class LevelFlagEntity : FlagEntity
    {
        public LevelFlagEntity(Scene scene, ObstacleFactory factory, Vector2 position)
            : base(scene,factory, position)
        {
            Flag = (AbstractObstacle)Factory.getFlag((int)flagTypes.FLAG);
            Flag.Position = position;
            Sprite.Position = position;
        }

        public override void SetHit()
        {
            if (!isHit)
                PlayBGM("course_clear");
            scene.WinLevel();
            base.SetHit();
        }

    }
}