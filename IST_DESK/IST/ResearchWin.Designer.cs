﻿namespace IST
{
    partial class ResearchWin
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
            this.researchFlowArea = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // researchFlowArea
            // 
            this.researchFlowArea.AutoScroll = true;
            this.researchFlowArea.Location = new System.Drawing.Point(12, 12);
            this.researchFlowArea.Name = "researchFlowArea";
            this.researchFlowArea.Size = new System.Drawing.Size(997, 607);
            this.researchFlowArea.TabIndex = 0;
            // 
            // ResearchWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 631);
            this.Controls.Add(this.researchFlowArea);
            this.Name = "ResearchWin";
            this.Text = "ResearchWin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel researchFlowArea;
    }
}