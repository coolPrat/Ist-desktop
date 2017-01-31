using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IST
{
    public partial class ResearchWin : Form
    {
        List<string> citations;
        public ResearchWin(List<string> citations)
        {
            this.citations = citations;
            InitializeComponent();
            setCitations();
        }

        private void setCitations()
        {
            for(int i = 0; i < citations.Count; i++)
            {
                Label l1 = new Label();
                l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                l1.MaximumSize = new Size(800, 100);
                l1.AutoSize = true;
                l1.Text = (i + 1) + " : " + citations[i];
                researchFlowArea.Controls.Add(l1);
            }
        }
    }
}
