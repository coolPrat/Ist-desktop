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
    public partial class UnderInfo : Form
    {
        public UnderInfo(string lab1, List<string> concentrations)
        {
            InitializeComponent();
            major_head.Text = lab1;
            con_table.RowCount = concentrations.Count;
            con_table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            for (int i = 0; i < concentrations.Count; i++)
            {
                con_table.Controls.Add(new Label() { Text = concentrations[i], AutoSize = true }, 0, i);
            }
        }
    }
}
