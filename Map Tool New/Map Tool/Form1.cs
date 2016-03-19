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
            int FX = Convert.ToInt32(XposBox.Value);
            int FY = Convert.ToInt32(YposBox.Value);
            int FWidth = Convert.ToInt32(WidthBox.Value);
            int FHeight = Convert.ToInt32(HeightBox.Value);
            string FTexture = TextureBox.Text;

            //check if necessary fields are filled
            if (FY != 0 && FX != 0 && FWidth != 0 && FHeight != 0)
            {
                //then check if it's a proper texture name
                if (TextureBox.Items.Contains(TextureBox.Text))
                {
                    //create scenery object
                    Scenery sceneryObj = new Scenery(FX, FY, FWidth, FHeight, FHealth, FLoot, FTexture);

                    bool conflicts = false;
                    //check if this object collides with any others
                    foreach(var sObj in sceneryColl)
                    {
                        if(sObj.ObjPos.Intersects(sceneryObj.ObjPos))
                        {
                            conflicts = true;
                        }
                    }

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
            
            //try to create a binary file to contain all objects on the map
           // try
           // {
                //create a stream
               // Stream str = File.OpenWrite("Map.dat");

                //create the binarywriter
                //BinaryWriter output = new BinaryWriter(str);

                //create file path
                string dir = @"c:\temp";
                string serializationFile = Path.Combine(dir, "Map.bin");

                //serialize 
                using (Stream stream = File.Open(serializationFile, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, sceneryColl);
                }

            //}
           // catch(IOException)
            //{

           // }

           
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
