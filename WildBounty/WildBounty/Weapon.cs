﻿using System;
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
     * Purpose: class for weapons
     * Caveats: none
     * */
    class Weapon : Drop
    {
        // attributes
        private int damage; // damage dealt

        // properties 
        public int Damage
        {
            get { return damage; }
        }

        public Weapon(Texture2D img, int x, int y, int wth, int hght):base(img,x,y,wth,hght)
        {
            
        }
    }
}

