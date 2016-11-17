using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    class CoinEntity : ItemEntity, ICoinPublisher, IPointPublisher
    {
         public CoinEntity(ItemFactory factory, Vector2 position) : base(factory)
        {
            item = (Coin)spriteFactory.getSprite((int)itemTypes.COINS);
            item.Position = position;
            item.Velocity = Vector2.Zero;
            ItemSM = new ItemStateMachine(this);
            ActiveTransition();
            HUD.CoinTracker.Subscribe(this);
            HUD.PointTracker.Subscribe(this);
        }

         public event CoinCollector CoinCollector;
         public event PointCollector PointCollector;

         public void OnCoinEvent(CoinEvent args)
         {
             CoinCollector(args);
         }
         public void OnPointEvent(PointEvent args)
         {
             PointCollector(args);
         }
         public void Points(int points)
         {
             PointEvent e = new PointEvent(points);
             OnPointEvent(e);
         }
         public override void HandleCollision(Vector2 vector, AABB collisionArea, Entity collider)
         {
             if (CurrentItemState is ActiveItemState)
             {
                 if (collider is PlayerChar)
                 {
                     Coin();
                 }   
             }
         }

        public override void ActiveTransition()
        {
            if (this.CurrentItemState is EmergingItemState) Coin();
            else
            {
                ChangeItemState(this.ItemSM.Active);
                CurrentItemState.ActiveTransition();
            }
        }

        public void Coin()
        {
             PlaySFX("coin");
             CoinEvent e = new CoinEvent();
             OnCoinEvent(e);
             Points(200);
             Removed = true;
         }

    }

}
