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
        // Health value
        private int covHealth;

        // Health property
        public int CovHealth
        {
            get { return covHealth; }
            set { covHealth = value; }
        }
        
        // Parameterized Constructor
        public Cover(int ch,Texture2D img, int x, int y, int wth, int hght):base(img,x,y,wth,hght)
        {
            covHealth = ch;
        }

        // If the health of the object is below zero, disappear
    }
}
