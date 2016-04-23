using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Map_Tool
{
    [Serializable]
    class SceneConverter
    {
        private int health;
        private int lootChance;
        private int x;
        private int y;
        private int width;
        private int height;
        private int textureName; //used to set textures

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int TextureNum
        {
            get { return textureName; }
            set { textureName = value; }
        }

        public int LootChance
        {
            get { return lootChance; }
            set
            {
                lootChance = value;
                //loot chance should not be below 0 or above 99 (because of the next() method, the upper limit will be +1)
                if (lootChance < 0)
                {
                    lootChance = 0;
                }
                else if (lootChance > 99)
                {
                    lootChance = 99;
                }
            }
        }

        public int Health
        {
            get { return health; }
            set
            {
                health = value;
                //health should not fall below 0
                if (health < 0)
                {
                    health = 0;
                }
            }
        }

        public SceneConverter(int x, int y, int width, int height, int hp, int loot, int tex)
        {
            Height = height;
            X = x;
            Y = y;
            Width = width;
            Health = hp;
            LootChance = loot;
            TextureNum = tex;
        }
    }
}
