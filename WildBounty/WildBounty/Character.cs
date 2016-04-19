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
     * Caveats: Needs to be added on to for the purpose of AI. 
     */
    class Character : GameObject
    {
        // Parameterzied constructor
        public Character(Texture2D img, int x, int y, int wth, int hght, int hlth):base(img,x,y,wth,hght,hlth)
        {
            
        }
        // Property to get the x value of the retangle

        // Property to get the y value of the rectangle


        // Move the characters by making new rectangle upon keypress 
            // Use the properties for the coordinates when making new Rectangles

    }
}
