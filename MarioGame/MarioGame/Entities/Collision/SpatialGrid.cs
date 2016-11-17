using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MarioGame
{

    public struct Index
    {
        public int Row;
        public int Col;

        public Index(int col, int row)
        {
            this.Col = col;
            this.Row = row;
        }
    }

    public class SpatialGrid
    {
        List<Entity>[,] grid;
        List<Entity> colliders;

        private int width;
        private int height;

        public SpatialGrid(Bound screen)
        {
            width = screen.Width / Constants.SPATIAL_GRID_SIZE;
            height = screen.Height / Constants.SPATIAL_GRID_SIZE;

            grid = new List<Entity>[height, width];

            colliders = new List<Entity>();
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < colliders.Count; i++ )
            {
                Entity collider = colliders[i];
                List<Index> boxes = collider.SpatialGridBoxes;

                foreach (Index box in boxes)
                {
                    if (this.Contains(box))
                    {
                        DetectCollisions(collider, box);
                    }
                }
            }
        }

        private void DetectCollisions(Entity collider, Index box)
        {
            for (int i = 0; i < grid[box.Row, box.Col].Count; i++)
            {
                Entity collidableEntity = grid[box.Row, box.Col][i];
                AABB collision;
                if (!collider.Seen.Contains(collidableEntity) && collider.Collide(collidableEntity, out collision))
                {
                    // collision response
                    Vector2 vector = collider.Velocity;
                    collidableEntity.HandleCollision(vector, collision, collider);

                    // Opposite reaction
                    collider.HandleCollision(Vector2.Negate(vector), collision, collidableEntity);

                    collider.Seen.Add(collidableEntity);
                    collidableEntity.Seen.Add(collider);
                }
            }
        }

        public void Add(Entity entity)
        {
            foreach (Index box in entity.SpatialGridBoxes)
            {
                if (this.Contains(box))
                {
                    if (grid[box.Row, box.Col] == null)
                    {
                        grid[box.Row, box.Col] = new List<Entity>();
                    }
                    grid[box.Row, box.Col].Add(entity);
                } 
            }

            // Detect whether the entity can move or not
            if (!entity.Velocity.Equals(Vector2.Zero))
            {
                colliders.Add((Entity)entity);
            }

        }

        private bool Contains(Index index)
        {
            return ((index.Col >= 0) && (index.Col < width)) && ((index.Row >= 0) && (index.Row < height));
        }

    }
}
