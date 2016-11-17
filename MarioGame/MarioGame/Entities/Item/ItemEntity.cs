using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public abstract class ItemEntity : Entity
    {
        private float timer;
        public ItemStateMachine ItemSM;
        public IItemState CurrentItemState { get; private set; }
        public AbstractItem item { get; set; }
        public Direction Direction
        {
            get { return item.Direction;  }
            set { item.Direction = value; }
        }
        public override int Width
        {
            get { return item.Width; }
            set { }
        }

        public override int Height
        {
            get { return item.Height; }
            set { }
        }

        public override Vector2 Position
        {
            get { return item.Position; }
            set 
            { 
                item.Position = value;
                Sprite.Position = value;
            }
        }
        public override Vector2 Velocity
        {
            get { return item.Velocity; }
            set { item.Velocity = value; }
        }
        public override Vector2 Acceleration
        {
            get { return item.Acceleration; }
            set { item.Acceleration = value;  }
        }

        public ItemFactory spriteFactory;

        protected ItemEntity(ItemFactory factory) : base()
        {
            spriteFactory = factory;
            timer = 0;
        }
        public override void Update(float elapsed)
        {
            if (CurrentItemState is EmergingItemState)
            {
                float EmergeTime = 0;
                if (this is CoinEntity) EmergeTime = Constants.COIN_EMERGE;
                else EmergeTime = Constants.ITEM_EMERGE;
                timer += elapsed;
                if (timer > EmergeTime)
                {
                    ActiveTransition();
                    timer = 0;
                }
            }
            CurrentItemState.Update(elapsed);
            item.Update(elapsed);
            Sprite.Position = item.Position;
            base.Update(elapsed);
        }

        public override void Draw(SpriteBatch batch)
        {
            item.Draw(batch);
            base.Draw(batch);
        }

        public virtual void ActiveTransition()
        {
            ChangeItemState(this.ItemSM.Active);
            CurrentItemState.ActiveTransition();
        }
        public virtual void EmergingTransition()
        {
            ChangeItemState(this.ItemSM.Emerging);
            CurrentItemState.EmergingTransition();
        }
        public virtual void InactiveTransition()
        {
            ChangeItemState(this.ItemSM.Inactive);
            CurrentItemState.InactiveTransition();
        }
        public virtual void TurnTransition()
        {
            CurrentItemState.TurnTransition();
        }

        public void ChangeItemState(IItemState newState)
        {
            CurrentItemState = newState;
        }

        public override void HandleCollision(Vector2 vector, AABB collision, Entity collider)
        {
            Side result = AABB.SideHit(BoundingBox, collision);
                    
            if (collider is BlockForm)
            {
                if (result == Side.LEFT && Direction == Direction.LEFT)
                {

                    this.TurnTransition();
                }
                else if (result == Side.RIGHT && Direction == Direction.RIGHT)
                {
                    this.TurnTransition();
                }
                else if (result == Side.BOTTOM)
                {
                    Velocity = new Vector2(Velocity.X, 0.0f);
                }
            }
            else if (collider is PlayerChar)
            {
                Removed = true;
            }
        }
    }
}