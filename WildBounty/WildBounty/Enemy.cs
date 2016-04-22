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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive == true)
            {
                spriteBatch.Draw(Image,Rect,Color.White);
            }
        }
    }
}
