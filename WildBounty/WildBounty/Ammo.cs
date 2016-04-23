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
     * Purpose: Handles the amount of ammo you have and how much ammo each gun has. 
     * Caveats: Needs to be expanded on. 
     */
    class Ammo : Drop
    {
        // Parameterized constructor
        public Ammo(Texture2D img, int x, int y, int wth, int hght):base(img,x,y,wth,hght)
        {
  
        }
    }
}
