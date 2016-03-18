namespace MapTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TexturePreview = new System.Windows.Forms.PictureBox();
            this.TextureChooser = new System.Windows.Forms.ComboBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.HealthBox = new System.Windows.Forms.NumericUpDown();
            this.HeightBox = new System.Windows.Forms.NumericUpDown();
            this.XposBox = new System.Windows.Forms.NumericUpDown();
            this.WidthBox = new System.Windows.Forms.NumericUpDown();
            this.YposBox = new System.Windows.Forms.NumericUpDown();
            this.LootChanceBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TexturePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XposBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YposBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LootChanceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TexturePreview
            // 
            this.TexturePreview.Location = new System.Drawing.Point(11, 307);
            this.TexturePreview.Margin = new System.Windows.Forms.Padding(2);
            this.TexturePreview.Name = "TexturePreview";
            this.TexturePreview.Size = new System.Drawing.Size(143, 111);
            this.TexturePreview.TabIndex = 0;
            this.TexturePreview.TabStop = false;
            this.TexturePreview.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // TextureChooser
            // 
            this.TextureChooser.FormattingEnabled = true;
            this.TextureChooser.Items.AddRange(new object[] {
            "Dark Sand",
            "Light Sand"});
            this.TextureChooser.Location = new System.Drawing.Point(11, 257);
            this.TextureChooser.Margin = new System.Windows.Forms.Padding(2);
            this.TextureChooser.Name = "TextureChooser";
            this.TextureChooser.Size = new System.Drawing.Size(144, 21);
            this.TextureChooser.TabIndex = 1;
            this.TextureChooser.SelectedIndexChanged += new System.EventHandler(this.TextureChooser_SelectedIndexChanged);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(11, 452);
            this.Confirm.Margin = new System.Windows.Forms.Padding(2);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(143, 60);
            this.Confirm.TabIndex = 2;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // HealthBox
            // 
            this.HealthBox.Location = new System.Drawing.Point(11, 147);
            this.HealthBox.Margin = new System.Windows.Forms.Padding(2);
            this.HealthBox.Name = "HealthBox";
            this.HealthBox.Size = new System.Drawing.Size(143, 20);
            this.HealthBox.TabIndex = 3;
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(87, 92);
            this.HeightBox.Margin = new System.Windows.Forms.Padding(2);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(66, 20);
            this.HeightBox.TabIndex = 4;
            // 
            // XposBox
            // 
            this.XposBox.Location = new System.Drawing.Point(11, 40);
            this.XposBox.Margin = new System.Windows.Forms.Padding(2);
            this.XposBox.Name = "XposBox";
            this.XposBox.Size = new System.Drawing.Size(66, 20);
            this.XposBox.TabIndex = 5;
            this.XposBox.ValueChanged += new System.EventHandler(this.XposBox_ValueChanged);
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(11, 92);
            this.WidthBox.Margin = new System.Windows.Forms.Padding(2);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(66, 20);
            this.WidthBox.TabIndex = 6;
            // 
            // YposBox
            // 
            this.YposBox.Location = new System.Drawing.Point(87, 40);
            this.YposBox.Margin = new System.Windows.Forms.Padding(2);
            this.YposBox.Name = "YposBox";
            this.YposBox.Size = new System.Drawing.Size(66, 20);
            this.YposBox.TabIndex = 7;
            // 
            // LootChanceBox
            // 
            this.LootChanceBox.Location = new System.Drawing.Point(11, 201);
            this.LootChanceBox.Margin = new System.Windows.Forms.Padding(2);
            this.LootChanceBox.Name = "LootChanceBox";
            this.LootChanceBox.Size = new System.Drawing.Size(143, 20);
            this.LootChanceBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 242);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Texture:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 292);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Preview:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loot Chance (0-99):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Health:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Width:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Height:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "X Position:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Y Position:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 538);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.YposBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.XposBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LootChanceBox);
            this.Controls.Add(this.WidthBox);
            this.Controls.Add(this.HeightBox);
            this.Controls.Add(this.HealthBox);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.TextureChooser);
            this.Controls.Add(this.TexturePreview);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TexturePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XposBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YposBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LootChanceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TexturePreview;
        private System.Windows.Forms.ComboBox TextureChooser;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.NumericUpDown HealthBox;
        private System.Windows.Forms.NumericUpDown HeightBox;
        private System.Windows.Forms.NumericUpDown XposBox;
        private System.Windows.Forms.NumericUpDown WidthBox;
        private System.Windows.Forms.NumericUpDown YposBox;
        private System.Windows.Forms.NumericUpDown LootChanceBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

