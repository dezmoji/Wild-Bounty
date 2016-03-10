using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Authors: Alex Pierce, Dezmon Gilbert
 * Purpose: game object class
 * Date: 3/2/2016
 */
namespace WildBounty
{
    class GameObject
    {
        // attributes
        private Texture2D image;
        private Rectangle rect;

        // properties
        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        // parameterized constructor to set Rectangles attribute
        public GameObject(Texture2D img, int x, int y, int wth, int hght)
        {
            image = img;
            rect = new Rectangle(x, y, wth, hght);
        }
    }
}
