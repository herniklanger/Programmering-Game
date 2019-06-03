namespace Programmer
{
    partial class Form2
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
            this.Ithems = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Width = new System.Windows.Forms.NumericUpDown();
            this.Height = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Ithems
            // 
            this.Ithems.FormattingEnabled = true;
            this.Ithems.Items.AddRange(new object[] {
            "Store",
            "Tree"});
            this.Ithems.Location = new System.Drawing.Point(9, 74);
            this.Ithems.Name = "Ithems";
            this.Ithems.Size = new System.Drawing.Size(100, 21);
            this.Ithems.TabIndex = 0;
            this.Ithems.SelectedIndexChanged += new System.EventHandler(this.Ithems_SelectedIndexChanged);
            this.Ithems.SelectedValueChanged += new System.EventHandler(this.Ithems_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ithem";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(145, 74);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.Ithems_SelectedIndexChanged);
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(9, 32);
            this.Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(120, 20);
            this.Width.TabIndex = 8;
            this.Width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Width.ValueChanged += new System.EventHandler(this.Ithems_SelectedIndexChanged);
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(145, 32);
            this.Height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(120, 20);
            this.Height.TabIndex = 9;
            this.Height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Height.ValueChanged += new System.EventHandler(this.Ithems_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(9, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 318);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(285, 455);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ithems);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox Ithems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        public System.Windows.Forms.NumericUpDown Width;
        public System.Windows.Forms.NumericUpDown Height;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}