using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lession_18
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Proccessor Time", "_Total");
            bunifuCircleProgressbar1.Value = Convert.ToInt32(performanceCounter1.NextValue());
        }
    }
}
