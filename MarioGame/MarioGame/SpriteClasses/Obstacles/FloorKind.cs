using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class FloorKind
    {
        public int FloorX { get; private set; }
        public int FloorY { get; private set; }

        public FloorKind(int floorType)
        {
            switch (floorType)
            {
                case (int)floorTypes.NFLOOR:
                    FloorX = 1;
                    FloorY = 0;
                    break;
                case (int)floorTypes.NWFLOOR:
                    FloorX = 0;
                    FloorY = 0;
                    break;
                case (int)floorTypes.WFLOOR:
                    FloorX = 0;
                    FloorY = 1;
                    break;
                case (int)floorTypes.SWFLOOR:
                    FloorX = 0;
                    FloorY = 2;
                    break;
                case (int)floorTypes.SFLOOR:
                    FloorX = 1;
                    FloorY = 2;
                    break;
                case (int)floorTypes.SEFLOOR:
                    FloorX = 2;
                    FloorY = 2;
                    break;
                case (int)floorTypes.EFLOOR:
                    FloorX = 2;
                    FloorY = 1;
                    break;
                case (int)floorTypes.NEFLOOR:
                    FloorX = 2;
                    FloorY = 0;
                    break;
                case (int)floorTypes.GROUND:
                    FloorX = 1;
                    FloorY = 1;
                    break;
                case (int)floorTypes.LCEDGE:
                    FloorX = 3;
                    FloorY = 0;
                    break;
                case (int)floorTypes.LEDGE:
                    FloorX = 3;
                    FloorY = 1;
                    break;
                case (int)floorTypes.RCEDGE:
                    FloorX = 5;
                    FloorY = 0;
                    break;
                case (int)floorTypes.REDGE:
                    FloorX = 5;
                    FloorY = 1;
                    break;
                default:
                    FloorX = 1;
                    FloorY = 1;
                    break;
            }
        }
    }
}