using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WildBounty
{
    class Bullet : Character
    {
        // Authors: Niko Bazos, Dezmon Gilbert
        // Purpose: Bullet Class
        // Date: 3/15/16
        // Collision rectangles 
        Rectangle bCollision;

        public Bullet(int hlth, Texture2D img, int x, int y, int wth, int hght):base(hlth,img,x,y,wth,hght)
        {
            
        }
        // @param Character object
        // Check to see if rectangles intersect with a character object
        public void Collision(GameObject obj)
        {
            // Maybe just subtract the health from a general GameObject value without specifying
            if(bCollision.Intersects(obj.Rect))// Property for game object rectangle
            {
                // Use property and subtract 10 health from that
                obj.Health = obj.Health - 10; 
            }

            // Not using:
            // if bullet intersects with Enemy 
            // kill enemy

            // if bullet intersects with Character
            // Bring down health

            // if it hits an obstacle
            // Bring down health of the object
        }

        
    }
}
