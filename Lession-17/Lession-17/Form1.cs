using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.IO;
namespace Lession_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string path = Application.StartupPath + "\\status.log";
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8);
            ServiceController sc = new ServiceController("MSSQL$SQLEXPRESS");
            string str = DateTime.Now.ToString() + " | " + sc.Status.ToString();
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            
        }
    }
}
