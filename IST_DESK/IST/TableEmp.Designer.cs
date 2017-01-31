namespace IST
{
    partial class TableEmp
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
            this.emp_table = new System.Windows.Forms.ListView();
            this.employer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.degree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.city = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.start_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // emp_table
            // 
            this.emp_table.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.employer,
            this.degree,
            this.city,
            this.title,
            this.start_date});
            this.emp_table.Location = new System.Drawing.Point(12, 12);
            this.emp_table.Name = "emp_table";
            this.emp_table.Size = new System.Drawing.Size(662, 669);
            this.emp_table.TabIndex = 0;
            this.emp_table.UseCompatibleStateImageBehavior = false;
            this.emp_table.View = System.Windows.Forms.View.Details;
            // 
            // employer
            // 
            this.employer.Text = "Employer";
            this.employer.Width = 150;
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
            // title
            // 
            this.title.Text = "Title";
            this.title.Width = 112;
            // 
            // start_date
            // 
            this.start_date.Text = "Start Date";
            this.start_date.Width = 150;
            // 
            // TableEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 693);
            this.Controls.Add(this.emp_table);
            this.Name = "TableEmp";
            this.Text = "TableEmp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView emp_table;
        private System.Windows.Forms.ColumnHeader employer;
        private System.Windows.Forms.ColumnHeader degree;
        private System.Windows.Forms.ColumnHeader city;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader start_date;
    }
}