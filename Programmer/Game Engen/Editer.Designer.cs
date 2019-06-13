namespace Programmer.Game_Engen
{
    partial class Editer
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
            this.X = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.NumericUpDown();
            this.lable4 = new System.Windows.Forms.Label();
            this.Heith = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.NumericUpDown();
            this.Tree = new System.Windows.Forms.Panel();
            this.Shop = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Stock = new System.Windows.Forms.DataGridView();
            this.StockIthem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heith)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width)).BeginInit();
            this.Shop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stock)).BeginInit();
            this.SuspendLayout();
            // 
            // X
            // 
            this.X.Location = new System.Drawing.Point(12, 25);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(131, 20);
            this.X.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // Y
            // 
            this.Y.Location = new System.Drawing.Point(149, 25);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(131, 20);
            this.Y.TabIndex = 2;
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Location = new System.Drawing.Point(146, 52);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(32, 13);
            this.lable4.TabIndex = 7;
            this.lable4.Text = "Heith";
            // 
            // Heith
            // 
            this.Heith.Location = new System.Drawing.Point(149, 68);
            this.Heith.Name = "Heith";
            this.Heith.Size = new System.Drawing.Size(131, 20);
            this.Heith.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Width";
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(12, 68);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(131, 20);
            this.Width.TabIndex = 4;
            // 
            // Tree
            // 
            this.Tree.Location = new System.Drawing.Point(-400, -436);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(268, 327);
            this.Tree.TabIndex = 8;
            // 
            // Shop
            // 
            this.Shop.Controls.Add(this.Stock);
            this.Shop.Controls.Add(this.label3);
            this.Shop.Location = new System.Drawing.Point(-400, -432);
            this.Shop.Name = "Shop";
            this.Shop.Size = new System.Drawing.Size(268, 327);
            this.Shop.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stock";
            // 
            // Stock
            // 
            this.Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Stock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockIthem,
            this.Amount});
            this.Stock.Location = new System.Drawing.Point(3, 16);
            this.Stock.Name = "Stock";
            this.Stock.Size = new System.Drawing.Size(262, 308);
            this.Stock.TabIndex = 1;
            // 
            // StockIthem
            // 
            this.StockIthem.HeaderText = "StockIthem";
            this.StockIthem.Name = "StockIthem";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Editer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 450);
            this.Controls.Add(this.Shop);
            this.Controls.Add(this.Tree);
            this.Controls.Add(this.lable4);
            this.Controls.Add(this.Heith);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.X);
            this.Name = "Editer";
            this.Text = "Editer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heith)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width)).EndInit();
            this.Shop.ResumeLayout(false);
            this.Shop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Y;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.NumericUpDown Heith;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Width;
        private System.Windows.Forms.Panel Tree;
        private System.Windows.Forms.Panel Shop;
        private System.Windows.Forms.DataGridView Stock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewComboBoxColumn StockIthem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}