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
    public partial class TableEmp : Form
    {
        List<ProfessionalEmploymentInformation> emps;
        public TableEmp(List<ProfessionalEmploymentInformation> empsInfo)
        {
            emps = empsInfo;
            InitializeComponent();
            _showTab();
        }

        private void _showTab()
        {
            for (var i = 0; i < emps.Count; i++)
            {
                ListViewItem item = new ListViewItem(new String[]
                {
                    emps[i].employer,
                    emps[i].degree,
                    emps[i].city,
                    emps[i].title,
                    emps[i].startDate
                });
                emp_table.Items.Add(item);
            }
        }
    }
}
