using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace MarioGame
{
    public abstract class AbstractItemState : IItemState
    {
        protected ItemStateMachine StateMachine { get; set; }

        protected ItemEntity Item { get; set; }
        protected virtual Vector2 stateAccel
        {
            get
            {
                return new Vector2(0.0f, Constants.GRAVITY);
            }
        }
        protected Direction Direction
        {
            get { return Item.Direction; }
            set { Item.Direction = value; }
        }

        protected virtual Vector2 Velocity
        {
            get { return Item.Velocity; }
            set { Item.Velocity = value; }
        }

        protected Vector2 Acceleration
        {
            get { return Item.Acceleration; }
            set { Item.Acceleration = value; }
        }
        protected AbstractItemState(ItemStateMachine sm, ItemEntity itemEnt)
        {
            StateMachine = sm;
            Item = itemEnt;
        }

        public virtual void ActiveTransition()
        {
            Item.Velocity = Vector2.Zero;
            if (Item is CoinEntity) { }
            else Item.Acceleration = new Vector2(0.0f, 60.0f);
            Item.Collidable = true;
        }
        public virtual void EmergingTransition()
        {
            Item.Acceleration = Vector2.Zero;
            if (Item is CoinEntity) Item.Velocity = new Vector2(0.0f, -40.0f);
            else Item.Velocity = new Vector2(0.0f, -8.0f);

            Item.Collidable = false;
        }
        public virtual void InactiveTransition()
        {
            Item.Acceleration = Vector2.Zero;
            Item.Velocity = Vector2.Zero;
            Item.Collidable = false;
        }
        public virtual void Update(float elapsed)
        {
            if (Scene.camera.BelowMap(Item.Position))
            {
                Item.Removed = true;
            }
            if (Item is CoinEntity) { }
            else Velocity += Acceleration * elapsed;
        }
        public virtual void TurnTransition()
        {
            if (Direction == Direction.RIGHT)
            {
                Direction = Direction.LEFT;
            }
            else if (Direction == Direction.LEFT)
            {
                Direction = Direction.RIGHT;
            }
        }

    }
}
