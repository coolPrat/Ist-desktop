namespace IST
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
            this.newsLable = new System.Windows.Forms.Label();
            this.newsTabs = new System.Windows.Forms.TabControl();
            this.year = new System.Windows.Forms.TabPage();
            this.quarter = new System.Windows.Forms.TabPage();
            this.month = new System.Windows.Forms.TabPage();
            this.old = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.newsTabs.SuspendLayout();
            this.year.SuspendLayout();
            this.quarter.SuspendLayout();
            this.month.SuspendLayout();
            this.old.SuspendLayout();
            this.SuspendLayout();
            // 
            // newsLable
            // 
            this.newsLable.AutoSize = true;
            this.newsLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsLable.Location = new System.Drawing.Point(48, 33);
            this.newsLable.Name = "newsLable";
            this.newsLable.Size = new System.Drawing.Size(55, 20);
            this.newsLable.TabIndex = 1;
            this.newsLable.Text = "News";
            // 
            // newsTabs
            // 
            this.newsTabs.Controls.Add(this.year);
            this.newsTabs.Controls.Add(this.quarter);
            this.newsTabs.Controls.Add(this.month);
            this.newsTabs.Controls.Add(this.old);
            this.newsTabs.Location = new System.Drawing.Point(31, 78);
            this.newsTabs.Name = "newsTabs";
            this.newsTabs.SelectedIndex = 0;
            this.newsTabs.Size = new System.Drawing.Size(960, 459);
            this.newsTabs.TabIndex = 2;
            this.newsTabs.SelectedIndexChanged += new System.EventHandler(this.newsTabs_SelectedIndexChanged);
            // 
            // year
            // 
            this.year.Controls.Add(this.flowLayoutPanel1);
            this.year.Location = new System.Drawing.Point(4, 25);
            this.year.Name = "year";
            this.year.Padding = new System.Windows.Forms.Padding(3);
            this.year.Size = new System.Drawing.Size(952, 430);
            this.year.TabIndex = 0;
            this.year.Text = "This Year";
            this.year.UseVisualStyleBackColor = true;
            // 
            // quarter
            // 
            this.quarter.Controls.Add(this.flowLayoutPanel4);
            this.quarter.Location = new System.Drawing.Point(4, 25);
            this.quarter.Name = "quarter";
            this.quarter.Padding = new System.Windows.Forms.Padding(3);
            this.quarter.Size = new System.Drawing.Size(952, 430);
            this.quarter.TabIndex = 1;
            this.quarter.Text = "This Quarter";
            this.quarter.UseVisualStyleBackColor = true;
            // 
            // month
            // 
            this.month.Controls.Add(this.flowLayoutPanel3);
            this.month.Location = new System.Drawing.Point(4, 25);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(952, 430);
            this.month.TabIndex = 2;
            this.month.Text = "This Month";
            this.month.UseVisualStyleBackColor = true;
            // 
            // old
            // 
            this.old.Controls.Add(this.flowLayoutPanel2);
            this.old.Location = new System.Drawing.Point(4, 25);
            this.old.Name = "old";
            this.old.Size = new System.Drawing.Size(952, 430);
            this.old.TabIndex = 3;
            this.old.Text = "Old";
            this.old.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(943, 421);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(943, 421);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(6, 5);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(943, 421);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoScroll = true;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(6, 5);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(940, 421);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 569);
            this.Controls.Add(this.newsTabs);
            this.Controls.Add(this.newsLable);
            this.Name = "Form2";
            this.Text = "Form2";
            this.newsTabs.ResumeLayout(false);
            this.year.ResumeLayout(false);
            this.quarter.ResumeLayout(false);
            this.month.ResumeLayout(false);
            this.old.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label newsLable;
        private System.Windows.Forms.TabControl newsTabs;
        private System.Windows.Forms.TabPage year;
        private System.Windows.Forms.TabPage quarter;
        private System.Windows.Forms.TabPage month;
        private System.Windows.Forms.TabPage old;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}