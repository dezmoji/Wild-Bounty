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
     * Purpose: class for the enemy
     * Caveats: none
     */
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

        // Paramterized constructor
        public Enemy(int pnts, Texture2D img, int x, int y, int wth, int hght, int hlth): base(img, x, y, wth, hght,hlth)
        {
            points = pnts;
        }

        // method to make the enemy move toward the player
        public void Movement(Player player)
        {
            int xValue = player.Rect.X - Rect.X;
            int yValue = player.Rect.Y - Rect.Y;
            Vector2 direction = new Vector2(xValue, yValue);
            direction.Normalize();
        }
    }
}
