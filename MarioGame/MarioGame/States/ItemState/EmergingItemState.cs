using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace MarioGame
{
    public class EmergingItemState : AbstractItemState
    {
        public EmergingItemState(ItemStateMachine sm, ItemEntity item)
            : base(sm, item)
        { }

        public override void ActiveTransition()
        {
            base.ActiveTransition();
        }
        public override void EmergingTransition()
        {
            base.EmergingTransition();
        }
        public override void InactiveTransition()
        {
            base.InactiveTransition();
        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }
    }
}
