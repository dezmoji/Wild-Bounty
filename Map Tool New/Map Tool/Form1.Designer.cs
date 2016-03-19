namespace Map_Tool
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
            this.TextureBox = new System.Windows.Forms.ComboBox();
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
            this.Save = new System.Windows.Forms.Button();
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
            this.TexturePreview.Location = new System.Drawing.Point(16, 473);
            this.TexturePreview.Name = "TexturePreview";
            this.TexturePreview.Size = new System.Drawing.Size(214, 171);
            this.TexturePreview.TabIndex = 0;
            this.TexturePreview.TabStop = false;
            // 
            // TextureBox
            // 
            this.TextureBox.FormattingEnabled = true;
            this.TextureBox.Items.AddRange(new object[] {
            "Barrel",
            "Cactus"});
            this.TextureBox.Location = new System.Drawing.Point(16, 396);
            this.TextureBox.Name = "TextureBox";
            this.TextureBox.Size = new System.Drawing.Size(214, 28);
            this.TextureBox.TabIndex = 1;
            this.TextureBox.SelectedIndexChanged += new System.EventHandler(this.TextureBox_SelectedIndexChanged);
            this.TextureBox.TextUpdate += new System.EventHandler(this.TextureBox_TextUpdate);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(16, 696);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(214, 92);
            this.Confirm.TabIndex = 2;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // HealthBox
            // 
            this.HealthBox.Location = new System.Drawing.Point(16, 226);
            this.HealthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HealthBox.Name = "HealthBox";
            this.HealthBox.Size = new System.Drawing.Size(214, 26);
            this.HealthBox.TabIndex = 3;
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(131, 142);
            this.HeightBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(99, 26);
            this.HeightBox.TabIndex = 4;
            // 
            // XposBox
            // 
            this.XposBox.Location = new System.Drawing.Point(16, 61);
            this.XposBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XposBox.Name = "XposBox";
            this.XposBox.Size = new System.Drawing.Size(99, 26);
            this.XposBox.TabIndex = 5;
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(16, 142);
            this.WidthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(99, 26);
            this.WidthBox.TabIndex = 6;
            // 
            // YposBox
            // 
            this.YposBox.Location = new System.Drawing.Point(131, 61);
            this.YposBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YposBox.Name = "YposBox";
            this.YposBox.Size = new System.Drawing.Size(99, 26);
            this.YposBox.TabIndex = 7;
            // 
            // LootChanceBox
            // 
            this.LootChanceBox.Location = new System.Drawing.Point(16, 309);
            this.LootChanceBox.Name = "LootChanceBox";
            this.LootChanceBox.Size = new System.Drawing.Size(214, 26);
            this.LootChanceBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Texture:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Preview:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loot Chance (0-99):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Health:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Width:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Height:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "X Position:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Y Position:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(16, 834);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(214, 43);
            this.Save.TabIndex = 18;
            this.Save.Text = "Save Map";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 890);
            this.Controls.Add(this.Save);
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
            this.Controls.Add(this.TextureBox);
            this.Controls.Add(this.TexturePreview);
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
        private System.Windows.Forms.ComboBox TextureBox;
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
        private System.Windows.Forms.Button Save;
    }
}