﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Bai_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", @"D:/Code/SaleSystem-Administrator-Html/admin-animation.html");
        }
    }
}
