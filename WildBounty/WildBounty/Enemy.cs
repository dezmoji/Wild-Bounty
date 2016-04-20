using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WildBounty
{
    /*
     * Authors: Dezmon Gilbert
     * Purpose: class for the enemy
     * Caveats: none
     */
    class Enemy : Character
    {
        // attributes
        private int points; // points that are added to the players bounty 

   

        // properties
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        // Paramterized constructor
        public Enemy(int pnts, Texture2D img, int x, int y, int wth, int hght, int hlth): base(img, x, y, wth, hght,hlth)
        {
            points = pnts;
            IsActive = true;
        }

        // method to make the enemy move toward the player 
        //* work in progress
        public void Movement(Player player)
        {
            
            
            int xDist = player.Rect.X - Rect.X;
            int yDist = player.Rect.Y - Rect.Y;
            this.Rect = new Rectangle(xDist +100, yDist + 100, Rect.Width, Rect.Height);
            Vector2 direction = new Vector2(xDist, yDist);
            direction.Normalize();
        }

        // handles when the enemy dies
        public bool EnemyDeath()
        {
            if(Health <= 0)
            {
                IsActive = false;
                return true;
            }
            return false;
        }

        public void BulletCollision(Bullet bullet)
        {
            if (this.Rect.Intersects(bullet.Rect) == true) // Property for game object rectangle
            {
                // Use property and subtract 10 health from that
                this.Health -= 10;
                bullet.IsActive = false;
            }
        }
    }
}
