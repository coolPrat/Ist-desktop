namespace IST
{
    partial class TableCoop
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
            this.coop_list = new System.Windows.Forms.ListView();
            this.emp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.degree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.city = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.term = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // coop_list
            // 
            this.coop_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.emp,
            this.degree,
            this.city,
            this.term});
            this.coop_list.Location = new System.Drawing.Point(12, 12);
            this.coop_list.Name = "coop_list";
            this.coop_list.Size = new System.Drawing.Size(490, 672);
            this.coop_list.TabIndex = 0;
            this.coop_list.UseCompatibleStateImageBehavior = false;
            this.coop_list.View = System.Windows.Forms.View.Details;
            // 
            // emp
            // 
            this.emp.Text = "Employer";
            this.emp.Width = 150;
            // 
            // degree
            // 
            this.degree.Text = "Degree";
            this.degree.Width = 100;
            // 
            // city
            // 
            this.city.Text = "City";
            this.city.Width = 125;
            // 
            // term
            // 
            this.term.Text = "Term";
            this.term.Width = 75;
            // 
            // TableCoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 696);
            this.Controls.Add(this.coop_list);
            this.Name = "TableCoop";
            this.Text = "TableCoop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView coop_list;
        private System.Windows.Forms.ColumnHeader emp;
        private System.Windows.Forms.ColumnHeader degree;
        private System.Windows.Forms.ColumnHeader city;
        private System.Windows.Forms.ColumnHeader term;
    }
}