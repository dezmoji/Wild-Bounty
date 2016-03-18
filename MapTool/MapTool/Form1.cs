using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            //Texture2D FTexture = TextureBox.Value;
            
            //create scenery object
            Scenery sceneryObj = new Scenery(FX, FY, FWidth, FHeight, FHealth, FLoot);

            //select map texture
            try
            {
                // create a stream
                Stream str = File.OpenWrite("..\\..\\..\\..\\WildBounty\\WildBounty\\bin\\WindowsGL\\Debug\\map.dat");

                // create the binary writer object
                BinaryWriter output = new BinaryWriter(str);

                // populate the file with user selected texture
                switch(TextureChooser.SelectedIndex)
                {
                    case 0 :
                        output.Write("mapToolTest");
                        break;
                    case 1:
                        output.Write("defaultSand");
                        break;
                    default:
                        output.Write("defaultSand");
                        break;
                }

                // close the file since we are done
                output.Close();
            }
            catch (IOException ioe)
            {
            }

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
        }

        private void XposBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextureChooser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
