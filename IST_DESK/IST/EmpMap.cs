﻿using System;
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
    public partial class EmpMap : Form
    {
        public EmpMap()
        {
            InitializeComponent();
            emp_map.Navigate("http://ist.rit.edu/api/map/");
        }
    }
}
