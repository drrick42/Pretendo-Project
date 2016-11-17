using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    static class Constants
    {
        public static readonly float MARIO_RUN_SPEED = 30f;
        public static readonly float MARIO_MAX_RUN_SPEED = 75f;

        public static readonly float MARIO_JUMP_SPEED = -180f;
        public static readonly float MARIO_BOOST_SPEED = -10f;
        public static readonly float MARIO_HOP_SPEED = -100f;
        public static readonly float MARIO_MAX_JUMP_SPEED = -230f;

        public static readonly float MARIO_FALL_SPEED = 20f;
        public static readonly float MARIO_MAX_FALL_SPEED = 50f;

        public static readonly float GRAVITY = 200f;
        public static readonly float FRICTION = 60f;

        public static readonly int FRAMES_PER_SECOND = 60;

        public static readonly int INPUT_TIME_FACTOR = 6;
        public static readonly float CROUCH_TIME = .25f;

        public static readonly int SPATIAL_GRID_SIZE = 32;

        public static readonly int STAR_TIME = 8;
        public static readonly int INVUL_TIME = 2;
        public static readonly int GAME_TIME_FACTOR = 1;
        public static readonly int GAME_TIME_LIMIT = 400;
        public static readonly float GAME_TIME_DANGER = .25f;

        public static readonly float MARIO_DEAD_TIME = 4.5f;

        public static readonly float COIN_EMERGE = 0.3f;
        public static readonly float ITEM_EMERGE = 2.0f;
        public static readonly float ITEM_SPEED = 40.0f;
        public static readonly float STAR_SPEED = -80.0f;
    }
}
