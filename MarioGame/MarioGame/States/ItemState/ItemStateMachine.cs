using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace MarioGame
{
    public class ItemStateMachine
    {
        public ActiveItemState Active { get; private set; }
        public InactiveItemState Inactive { get; private set; }
        public EmergingItemState Emerging { get; private set; }

        public ItemStateMachine(ItemEntity item)
        {
            Active = new ActiveItemState(this, item);
            Inactive = new InactiveItemState(this, item);
            Emerging = new EmergingItemState(this, item);
        }

    }
}
