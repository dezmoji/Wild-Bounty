using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildBounty
{
    class Bullet : Character
    {
        // Author: Niko Bazos
        // Purpose: Bullet Class
        // Date: 3/15/16
        // Collision rectangles 
        Rectangle bCollision;

        // @param Character object
        // Check to see if rectangles intersect with a character object
        public void Collision(GameObject obj)
        {
            // Maybe just subtract the health from a general GameObject value without specifying
            if(bCollision.Intersects(obj.Rec) // Property for game object rectangle
            {
                // Use property and subtract 10 health from that
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
