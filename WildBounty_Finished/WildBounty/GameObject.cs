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
     * Authors: Alex Pierce, Dezmon Gilbert, Niko Bazos
     * Purpose: game object class
     * Caveats: None
     */
    public class GameObject
    {
        // attributes
        private Texture2D image;
        private Rectangle rect;
        private int health;
        private bool isActive;

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

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        // Not sure if needed

        public int xRec
        {
            set { rect.X = value; }
            get { return rect.X; }
        }

        public int yRec
        {
            set { rect.Y = value; }
            get { return rect.Y; }
        }
 
        public int hRec
        {
            get { return rect.Height; }
            set { rect.Height = value; }
        }
        // Most GameObjects will have a health including obstacles
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        // Parameterized constructor to set Rectangles and health attributes
        public GameObject(Texture2D img, int x, int y, int wth, int hght, int hlth)
        {
            image = img;
            rect = new Rectangle(x, y, wth, hght);
            health = hlth;
        }

        // constuctor just to set Rectangles
        public GameObject(Texture2D img, int x, int y, int wth, int hght)
        {
            image = img;
            rect = new Rectangle(x, y, wth, hght);
        }
    }
}
