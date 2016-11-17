using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class GoombaChar : EnemyEntity
    {
        
        public GoombaChar(EnemyFactory factory, Vector2 position)
            : base(factory)
        {

            enemy = (Enemy1)spriteFactory.getSprite((int)enemyTypes.GOOMBA);
            enemy.Position = position;
            enemy.Velocity = Vector2.Zero;
            enemy.Acceleration = Vector2.Zero;

            enemySM = new GoombaStateMachine(this);
            CurrentEnemyState = enemySM.Inactive;

            Width = enemy.Width;
            Height = 16;
        }
        public override void HitTransition()
        {
            this.Collidable = false;
            base.HitTransition();
        }
    }

}
