using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapTool
{
    class Scenery
    {
        //scenery attributes
        private Rectangle objPos;
        private int health;
        private int lootChance;
        private bool active;
        private bool looted;
        Random rng = new Random();
        //private Texture2D objTexture;

        //properties
        public int Health
        {
            get { return health; }
            set { 
                    health = value;
                    //health should not fall below 0
                    if(health < 0)
                    {
                       health = 0;
                    }
                }
        }

        public int LootChance
        {
            get { return lootChance; }
            set { 
                    lootChance = value;
                    //loot chance should not be below 0 or above 99 (because of the next() method, the upper limit will be +1)
                    if(lootChance < 0)
                    {
                        lootChance = 0;
                    }
                    else if(lootChance > 99)
                    {
                        lootChance = 99;
                    }
                }
        }
        public Rectangle ObjPos
        {
            get { return objPos; }
            set { objPos = value; }
        }

        public int Y
        {
            get { return objPos.Y; }
            set { objPos.Y = value;}
        }

        public int X
        {
            get { return objPos.X; }
            set { objPos.X = value; }
        }

        public int Width
        {
            get { return objPos.Width; }
            set { objPos.Width = value; }
        }

        public int Height
        {
            get { return objPos.Height; }
            set { objPos.Height = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public bool Looted
        {
            get { return looted; }
            set { looted = value; }
        }

        //constructor
        public Scenery(int x,int y, int width,int height, int hp,int loot)
        {
            Height = height;
            X = x;
            Y = y;
            Width = width;
            Health = hp;
            LootChance = loot;
            Looted = false;
        }


        /* // can't implement yet
        //draw method
        public void Draw(SpriteBatch sprBatch)
        {
            if( Health > 0)
            {
                sprBatch.Draw(objTexture, ObjPos, Color.White);
            }
            else
            {
                sprBatch.Draw( --rubble texture--,ObjPos, Color.White)
            }
         
        }
         */

        //loot drop method
        public void LootDrop()
        {
            if(Health == 0 && Looted == false)
            {
                //code to create loot(ie ammo) goes here

                //set looted to true
                Looted = true;
            }
        }

    }
}
