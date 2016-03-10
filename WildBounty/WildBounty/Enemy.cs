using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WildBounty
{
    /*Authors: Dezmon Gilbert
     * Purpose: class for the enemy
     * Caveats: none
     * */
    class Enemy : Character
    {
        // attributes
        private int points; // points that are added to the players bounty 

        // properties
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        // paramterized constructor
       /* public Enemy(Texture2D img,int x, int y, int wth, int hght,int pnts):base(img,x,y,wth,hght)
        {
            points = pnts;
        }*/
    }
}
