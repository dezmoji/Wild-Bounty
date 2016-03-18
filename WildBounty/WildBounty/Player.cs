using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Authors: Alex Pierce, Dezmon Gilbert
 * Purpose: Player Class
 * Caveats: Score feature is not fully implemented. 
 */
namespace WildBounty
{
    class Player : Character
    {
        // Attributes 
        private int bountyScore;

        // Properties
        public int BountyScore
        {
            get { return bountyScore; }
            set { bountyScore = value; }
        }

        // Parameterized constructor
        public Player(int hlth, Texture2D img, int x, int y, int wth, int hght):base(hlth,img,x,y,wth,hght)
        {
            bountyScore = 0;
        }
    }
}
