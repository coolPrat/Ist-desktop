namespace IST
{
    partial class UnderInfo
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
            this.major_head = new System.Windows.Forms.Label();
            this.con_table = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // major_head
            // 
            this.major_head.AutoSize = true;
            this.major_head.Location = new System.Drawing.Point(85, 30);
            this.major_head.Name = "major_head";
            this.major_head.Size = new System.Drawing.Size(46, 17);
            this.major_head.TabIndex = 0;
            this.major_head.Text = "label1";
            // 
            // con_table
            // 
            this.con_table.ColumnCount = 1;
            this.con_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.con_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.con_table.Location = new System.Drawing.Point(149, 127);
            this.con_table.Name = "con_table";
            this.con_table.RowCount = 2;
            this.con_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.con_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.con_table.Size = new System.Drawing.Size(300, 100);
            this.con_table.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Concentrations :";
            // 
            // UnderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 311);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.con_table);
            this.Controls.Add(this.major_head);
            this.MaximumSize = new System.Drawing.Size(500, 900);
            this.Name = "UnderInfo";
            this.Text = "UnderInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label major_head;
        private System.Windows.Forms.TableLayoutPanel con_table;
        private System.Windows.Forms.Label label2;
    }
}