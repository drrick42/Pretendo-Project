using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class GreenKoopaChar : EnemyEntity
    {

        public GreenKoopaChar(EnemyFactory factory, Vector2 position)
            : base(factory)
        {

            enemy = (Enemy1)spriteFactory.getSprite((int)enemyTypes.GREENKOOPA);
            enemy.Position = position;
            enemy.Velocity = Vector2.Zero;
            enemy.Acceleration = Vector2.Zero;

            enemySM = new GKoopaStateMachine(this);
            CurrentEnemyState = enemySM.Inactive;

            Width = enemy.Width;
            Height = enemy.Height;
        }
        public override void HitTransition()
        {
            base.HitTransition();
            Height = 15;
        }

    }

}
