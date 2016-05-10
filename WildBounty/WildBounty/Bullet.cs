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
     * Authors: Niko Bazos, Dezmon Gilbert, Alex Martinelli
     * Purpose: Supposed to handle the collision of a bullet with another object and the existence of the bullet itself. 
     * Caveats: Not fully developed. 
     */
    class Bullet : Character
    {
        // Bullet Rectangle
        Rectangle bCollision;
        private int timer;
        private bool side; //bool to determine the direction of the bullet. Only for enemy bullets, player bullets do not use this. {{RIGHT IS TRUE | LEFT IS FALSE}} 

        //side property
        public bool Side
        {
            get { return side; }
        }


        // Parameterized constructor
        public Bullet(int hlth, Texture2D img, int x, int y, int wth, int hght):base(img,x,y,wth,hght,hlth)
        {
            IsActive = true;
            timer = 0;
        }

        //overloaded constructor for enemy bullets
        public Bullet(int hlth, Texture2D img, int x, int y, int wth, int hght, bool sde): base(img, x, y, wth, hght, hlth)
        {
            side = sde;
            IsActive = true;
            timer = 0;
        }

        // @param Character object
        // Check to see if rectangles intersect with a character object
        public void Collision(GameObject obj)
        {
            if(IsActive == true)
            {
                // Subtract the health from a general GameObject value without specifying because all GameObjects will have a health
                if (this.Rect.Intersects(obj.Rect)) // Property for game object rectangle
                {
                    // Use property and subtract 10 health from that
                    obj.Health = obj.Health - 25;
                    this.IsActive = false;
                }
            }
        }

        public void Travel(GameObject obj)//makes the bullet move until it hits something or travels too far. uses collision method as well
        {
            if(IsActive == true)
            {
                Collision(obj); // check for collisions
                timer++;
   
                if(timer > 250)
                {
                    IsActive = false;
                }
            }
        }

    }
}
