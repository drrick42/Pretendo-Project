using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class BlockStateMachine
    {
        public IBlockState QuestionBlock { get; private set; }
        public IBlockState UsedBlock { get; private set; }
        public IBlockState BrickBlock { get; private set; }
        public IBlockState FloorBlock { get; private set; }
        public IBlockState PyramidBlock { get; private set; }
        public IBlockState HiddenBlock { get; private set; }
        public IBlockState VMovingBlock { get; private set; }
        public IBlockState HMovingBlock { get; private set; }



        public BlockStateMachine(BlockForm block)
        {
            QuestionBlock = new QuestionBlockState(this, block);
            UsedBlock = new UsedBlockState(this, block);
            BrickBlock = new BrickBlockState(this, block);
            FloorBlock = new FloorBlockState(this, block);
            PyramidBlock = new PyramidBlockState(this, block);
            HiddenBlock = new HiddenBlockState(this, block);
            VMovingBlock = new VMovingBlockState(this, block);
            HMovingBlock = new HMovingBlockState(this, block);
        }

    }
}
