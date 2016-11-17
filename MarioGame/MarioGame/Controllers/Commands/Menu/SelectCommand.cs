using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class SelectCommand : MenuCommand
    {
        public SelectCommand(Menu menu) : base(menu)
        {}

        public override void Execute()
        {
            receiver.Select();
        }
    }
}
