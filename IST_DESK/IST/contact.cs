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
    public partial class contact : Form
    {
        public contact()
        {
            InitializeComponent();
            webBrowser1.Navigate("http://ist.rit.edu/api/contactForm/");
        }
    }
}
