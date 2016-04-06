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
     * Authors: Alex Pierce, Dezmon Gilbert
     * Purpose: Suppposed to handle in-game obstacles and their deterioration.
     * Caveats: How the inanimate objects acti in game is not fully completed. 
     */
    class Cover : GameObject
    {
        
        
        // Parameterized Constructor
        public Cover(Texture2D img, int x, int y, int wth, int hght,int hlth):base(img,x,y,wth,hght,hlth)
        {
            // when the game first starts, the cover will exist
            IsActive = true;

            // calls the method to make cover disappear at certain point
            CoverActive();

        }

        // If the health of the object is below zero, disappear
        public void CoverActive()
        {
            if(this.Health <= 0)
            {
                // cover will be set to disappear
                IsActive = false;
            }
        }
    }
}
