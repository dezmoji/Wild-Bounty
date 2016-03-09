using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        // Property to get the x value of the retangle

        // Property to get the y value of the rectangle


        // Move the characters by making new rectangle upon keypress 
            // Use the properties for the coordinates when making new Rectangles

    }
}
