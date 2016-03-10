using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * Authors: Alex Pierce, Dezmon Gilbert
 * Purpose: player class
 * Date: 3/2/2016
 */
namespace WildBounty
{
    class Player : Character
    {
        // attributes 
        private int bountyScore;

        // properties
        public int BountyScore
        {
            get { return bountyScore; }
            set { bountyScore = value; }
        }

        // parameterized constructor
        /* public Player(Texture2D img,int x, int y, int wth, int hght):base(img,x,y,wth,hght)
        {
        }*/
    }
}
