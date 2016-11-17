using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class FloorBlock : AbstractObstacle
    {
        public FloorKind FloorKind { get; set; }
        public FloorBlock(ContentManager content, int floorType)
            : base(content)
        {
            FloorKind = new FloorKind(floorType);
        }

        public override void Update(float elapsed)
        {
            this.FrameX = this.FloorKind.FloorX;
            this.FrameY = this.FloorKind.FloorY;
        }

    }
}
