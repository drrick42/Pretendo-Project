using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    public interface ISprite
    {
        void Update(float elapsed);

        void Draw(SpriteBatch batch);
    }

    public enum Direction { RIGHT = 1, LEFT = -1, NONE = 0};
}