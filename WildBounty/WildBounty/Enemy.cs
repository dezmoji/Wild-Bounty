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
     * Authors: Dezmon Gilbert, Alex Martinelli
     * Purpose: class for the enemy
     * Caveats: none
     */
    class Enemy : Character
    {
        // attributes
        private int points; // points that are added to the players bounty 
        private Bullet bullet; 
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
            get { return bullet; }
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
        public Bullet Shoot(Player player1)
        {
            //if player is in this box
            if (this.xRec - 300 < player1.xRec && player1.xRec < this.xRec + 300 && player1.yRec < this.yRec + 100 && this.yRec - 100 < player1.yRec )
            {
                //if this enemy hasn't shot a bullet recently
                if(Shooting == false)
                {
                    //set shooting to true
                    shooting = true;
                    
                    //determine the side of the enemy the bullet will appear on
                    if(player1.xRec > this.xRec)//player is on the right
                    {
                        //create bullet
                        bullet = new Bullet(1, bImage, xRec, yRec, 10, 10,true); //bullet will fire right
                    }
                    if(player1.xRec < this.xRec) //player is on the left
                    {
                        //create bullet
                        bullet = new Bullet(1, bImage, xRec, yRec, 10, 10,false); //bullet will fire left
                    }

                    //return the bullet
                    return bullet;

                }
                else
                {
                    return null;
                }
            }
            //if shooting is true and player is outside of box
            else if(Shooting == true)
            {
                //is the bullet active?
                if(bullet.IsActive == true)
                {
                    return null;
                }
                else
                {
                    shooting = false; // set shooting to false to allow for next bullet
                    return null;
                }
                
            }
            else
            {
                return null;
            }
        }
    }
}
