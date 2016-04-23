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
     * Authors: Niko Bazos, Dezmon Gilbert
     * Purpose: Supposed to handle the collision of a bullet with another object and the existence of the bullet itself. 
     * Caveats: Not fully developed. 
     */
    class Bullet : Character
    {
        // Bullet Rectangle
        Rectangle bCollision;

        // Parameterized constructor
        public Bullet(int hlth, Texture2D img, int x, int y, int wth, int hght):base(img,x,y,wth,hght,hlth)
        {
            IsActive = true;
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
    }
}
