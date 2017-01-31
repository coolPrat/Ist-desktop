namespace IST
{
    partial class EmpMap
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
            this.emp_map = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // emp_map
            // 
            this.emp_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emp_map.Location = new System.Drawing.Point(0, 0);
            this.emp_map.MinimumSize = new System.Drawing.Size(20, 20);
            this.emp_map.Name = "emp_map";
            this.emp_map.ScriptErrorsSuppressed = true;
            this.emp_map.Size = new System.Drawing.Size(1048, 635);
            this.emp_map.TabIndex = 0;
            // 
            // EmpMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 635);
            this.Controls.Add(this.emp_map);
            this.Name = "EmpMap";
            this.Text = "EmpMap";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser emp_map;
    }
}