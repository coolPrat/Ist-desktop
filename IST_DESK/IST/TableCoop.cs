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
    public partial class TableCoop : Form
    {
        List<CoopInformation> coops;
        public TableCoop(List<CoopInformation> coopInfo)
        {
            coops = coopInfo;
            InitializeComponent();
            _showTab();
        }

        private void _showTab()
        {
            for (var i = 0; i < coops.Count; i++)
            {
                ListViewItem item = new ListViewItem(new String[]
                {
                    coops[i].employer,
                    coops[i].degree,
                    coops[i].city,
                    coops[i].term
                });
                coop_list.Items.Add(item);
            }
        }
    }
}
