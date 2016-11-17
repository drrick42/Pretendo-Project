using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class ScrollUpCommand : MenuCommand
    {
        public ScrollUpCommand(Menu menu) : base(menu)
        {}

        public override void Execute()
        {
            receiver.ScrollUp();
        }
    }
}
