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
using System.Threading;

namespace Bai_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            foreach (var item in Process.GetProcessesByName("UniKeyNT"))
            {
                item.Kill();
            }
            MessageBox.Show("Kill UniKeyNT success","Note");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in Process.GetProcessesByName("cmd"))
            {
                item.Kill();
            }
        }
    }
}
