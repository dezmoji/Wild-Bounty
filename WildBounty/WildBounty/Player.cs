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
    class Player : GameObject
    {
        // Attributes 
        private int bountyScore;
        int bCount;
        private Bullet bullets;

        // Properties
        public int BountyScore
        {
            get { return bountyScore; }
            set { bountyScore = value; }
        }

        public Bullet Bullets
        {
            get { return bullets; }
            set { bullets = value; }
        }

        // Parameterized constructor
        public Player(Texture2D img, int x, int y, int wth, int hght, int hlth):base(img,x,y,wth,hght,hlth)
        {
            bCount = 10;
            bountyScore = 0;
            IsActive = true;
        }

        public int BCount
        {
            get { return bCount; }
            set { bCount = value; }
        }

        public void UseBullet()
        {
            if (bCount > 0)
            {
                bCount--;
            }
        }

        public void GainBullet()
        {
            bCount += 5;
        }
    }
}
