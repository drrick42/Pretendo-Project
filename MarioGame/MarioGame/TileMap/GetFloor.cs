using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    static class GetFloor
    {
        public static int GetFloorKind(String value)
        {
            int floorKind;
            switch (value)
            {
                case "NFLOOR":
                    floorKind = (int)floorTypes.NFLOOR;
                    break;
                case "NWFLOOR":
                    floorKind = (int)floorTypes.NWFLOOR;
                    break;
                case "WFLOOR":
                    floorKind = (int)floorTypes.WFLOOR;
                    break;
                case "SWFLOOR":
                    floorKind = (int)floorTypes.SWFLOOR;
                    break;
                case "SFLOOR":
                    floorKind = (int)floorTypes.SFLOOR;
                    break;
                case "SEFLOOR":
                    floorKind = (int)floorTypes.SEFLOOR;
                    break;
                case "EFLOOR":
                    floorKind = (int)floorTypes.EFLOOR;
                    break;
                case "NEFLOOR":
                    floorKind = (int)floorTypes.NEFLOOR;
                    break;
                case "GROUND":
                    floorKind = (int)floorTypes.GROUND;
                    break;
                case "LCEDGE":
                    floorKind = (int)floorTypes.LCEDGE;
                    break;
                case "LEDGE":
                    floorKind = (int)floorTypes.LEDGE;
                    break;
                case "RCEDGE":
                    floorKind = (int)floorTypes.RCEDGE;
                    break;
                case "REDGE":
                    floorKind = (int)floorTypes.REDGE;
                    break;
                default:
                    floorKind = (int)floorTypes.NFLOOR;
                    break;
            }
            return floorKind;
        }
    }
}