using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!EventLog.SourceExists("TestEventLogS"))
            {
                EventLog.CreateEventSource("GiamSatThuMuc_Source", "GiamSatThuMuc_Log");
            }
            eventLog1.Source = "GiamSatThuMuc_Source";
            eventLog1.Log = "GiamSatThuMuc_Log";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eventLog1.WriteEntry(textBox1.Text);
            MessageBox.Show("success");
        }
    }
}
