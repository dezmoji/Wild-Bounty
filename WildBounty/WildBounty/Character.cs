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
     * Purpose: Parent class for player and enemies
     * Caveats: none
     * */
    class Character : GameObject
    {
        // attributs
        private int health; // health of character
        
        // properties 
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Character(int hlth,Texture2D img, int x, int y, int wth, int hght):base(img,x,y,wth,hght)
        {
            health = hlth;
        }
        // Property to get the x value of the retangle

        // Property to get the y value of the rectangle


        // Move the characters by making new rectangle upon keypress 
            // Use the properties for the coordinates when making new Rectangles

    }
}
