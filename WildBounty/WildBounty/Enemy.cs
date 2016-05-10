using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Bullet bullets; 
        private Texture2D bImage; // texture2d to hold enemy bullet image
        private bool shooting;
   

        // properties
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public bool Shooting
        {
            get { return shooting; }
            set { shooting = value; }
        }

        //enemy bullet property
        public Bullet Bullets
        {
            get { return bullets; }
        }

        //enemy bullet image property
        public Texture2D BImage
        {
            get { return bImage; }
            set { bImage = value; }
        }
        
        // Paramterized constructor
        public Enemy(int pnts, Texture2D img, int x, int y, int wth, int hght, int hlth): base(img, x, y, wth, hght,hlth)
        {
            points = pnts;
            IsActive = true;
            Shooting = false;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive == true)
            {
                spriteBatch.Draw(Image,Rect,Color.White);
            }
        }

        //enemy shoot
        public void Shoot(Player player1)
        {
            //if player is in this box
            if (this.xRec - 300 < player1.xRec && player1.xRec < this.xRec + 300 && player1.yRec < this.yRec + 100 && this.yRec - 100 < player1.yRec )
            {
                //if this enemy hasn't shot a bullet recently
                if(Shooting == false)
                {

                    //enemy is shooting
                    Shooting = true;
                    //create new bullet
                    bullets = new Bullet(10, bImage, xRec + 50, yRec + 10, 10, 10);
                    //set it to active
                    bullets.IsActive = true;
                    //while active
                    while (bullets.IsActive)
                    {
                        //increment bullet x position
                        bullets.xRec += 10;
                        //if bullet goes too far
                        if (bullets.Rect.X > 300)
                        {
                            //set to inactive
                            bullets.IsActive = false;
                            //set shooting to false after bullet becomes inactive 
                            Shooting = false;
                        }

                    }
                   
                   
                }  
            }
            //if shooting is true and player is outside of box
            else if(Shooting == true)
            {
                //while active
                while (bullets.IsActive)
                {

                    //increment bullet x position
                    bullets.xRec += 10;
                    //if bullet goes too far
                    if (bullets.Rect.X > 300)
                    {
                        //set to inactive
                        bullets.IsActive = false;
                        //set shooting to false after bullet becomes inactive 
                        shooting = false;
                    }

                }
            }
        }
    }
}
