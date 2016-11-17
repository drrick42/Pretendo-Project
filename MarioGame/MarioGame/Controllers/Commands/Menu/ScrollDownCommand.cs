using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class ScrollDownCommand : MenuCommand
    {
        public ScrollDownCommand(Menu menu) : base(menu)
        {}

        public override void Execute()
        {
            receiver.ScrollDown();
        }
    }
}
