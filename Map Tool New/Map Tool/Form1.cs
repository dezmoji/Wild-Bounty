using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Map_Tool
{
    public partial class Form1 : Form
    {
        //list to hold all objects
        private List<Scenery> sceneryColl = new List<Scenery>();
        private List<Array> sceneConColl = new List<Array>();
        int fx;
        int fy;

        //x and y properties
        public int FX
        {
            get { return fx; }
            set 
            { //set the xposbox whenever FX is set via property
                fx = value;
                XposBox.Value = value;
            }
        }

        public int FY
        {
            get { return fy; }
            set
            { //set the yposbox whenever FY is set via property
                fy = value;
                YposBox.Value = value;
            }
        }

        //property of list
        public List<Scenery> SceneryColl
        {
            get { return sceneryColl;}
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            //get and store all variables (F is for form)
            int FHealth = Convert.ToInt32(HealthBox.Value);
            int FLoot = Convert.ToInt32(LootChanceBox.Value);
            FX = Convert.ToInt32(XposBox.Value);
            FY = Convert.ToInt32(YposBox.Value);
            int FWidth = Convert.ToInt32(WidthBox.Value);
            int FHeight = Convert.ToInt32(HeightBox.Value);
            string FTexture = TextureBox.Text;
            int FTextNum = -1;
            if(FTexture == "Barrel")
            {
                FTextNum = 1;
            }
            if (FTexture == "Cactus") 
            {
                FTextNum = 0; 
            }

            //check if necessary fields are filled
            if (FY != 0 && FX != 0 && FWidth != 0 && FHeight != 0)
            {
                //then check if it's a proper texture name
                if (TextureBox.Items.Contains(TextureBox.Text))
                {
                    //create scenery object
                    Scenery sceneryObj = new Scenery(FX, FY, FWidth, FHeight, FHealth, FLoot, FTextNum);

                    bool conflicts = false;
                    //check if this object collides with any others
                    /*foreach(var sObj in sceneryColl)
                    {
                        Rectangle rect = new Rectangle(sObj.X, sObj.Y, sObj.Width, sObj.Height);
                        if(sObj.ObjPos.Intersects(sceneryObj.ObjPos))
                        {
                            conflicts = true;
                        }
                    }*/

                    //if it intersects with nothing, then it will finally be added
                    if(conflicts == false)
                    {
                        sceneryColl.Add(sceneryObj);

                        //clear all fields and above variables
                        FHealth = 0;
                        FLoot = 0;
                        FX = 0;
                        FY = 0;
                        FWidth = 0;
                        FHeight = 0;
                        HealthBox.Value = 0;
                        LootChanceBox.Value = 0;
                        XposBox.Value = 0;
                        YposBox.Value = 0;
                        WidthBox.Value = 0;
                        HeightBox.Value = 0;
                        FTextNum = -1;
                        FTexture = "";
                        Confirm.Text = "Confirm";
                    }
                    else
                    {
                        Confirm.Text = "Object Conflicts with Another";
                    }
                    
                }
                else
                {
                    //message says select a texture
                    Confirm.Text = "Select a Texture";
                }
            }
            else
            {
                //message says fill out required fields
                Confirm.Text = "Fill Required Fields";
            }
        }

        private void TextureBox_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Stream str = File.OpenWrite("..\\..\\..\\..\\..\\WildBounty\\WildBounty\\bin\\WindowsGL\\Debug\\map.dat");
            str.Close();

            foreach(var obj in sceneryColl)
            {
                SceneConverter newObj = new SceneConverter(obj.X, obj.Y, obj.Width, obj.Height, obj.Health, obj.LootChance, obj.TextureNum);
                int[] array = new int[7];
                array[0] = obj.X;
                array[1] = obj.Y;
                array[2] = obj.Width;
                array[3] = obj.Height;
                array[4] = obj.Health;
                array[5] = obj.LootChance;
                array[6] = obj.TextureNum;
                sceneConColl.Add(array);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open("..\\..\\..\\..\\..\\WildBounty\\WildBounty\\bin\\WindowsGL\\Debug\\map.dat", FileMode.Create)))
            {
                for(int j = 0; j < sceneConColl.Count;j++)
                {
                    for(int k = 0; k < sceneConColl[j].Length; k++)
                    {
                        int[] n = (int[])sceneConColl[j];
                        writer.Write(n[k]);
                    }
                }
            }
            
            /*for (int i = 0; i < sceneConColl.Count; i++)
            {
                using (Stream stream = File.Open("..\\..\\..\\..\\..\\WildBounty\\WildBounty\\bin\\WindowsGL\\Debug\\map.dat", false ? FileMode.Append : FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, sceneConColl[i]);
                }
            }*/
        }

        private void TextureBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TextureBox.Items.Contains(TextureBox.Text))
            {
                TexturePreview.ImageLocation = TextureBox.Text + ".png";
                TexturePreview.SizeMode = PictureBoxSizeMode.StretchImage;
            }  
        }
    }
}
