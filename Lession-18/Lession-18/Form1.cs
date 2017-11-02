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

namespace Lession_18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        ServiceController sc = new ServiceController("MSSQL$SQLEXPRESS");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (sc.Status ==ServiceControllerStatus.Stopped)
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //ServiceController sc = new ServiceController("MSSQL$SQLEXPRESS");
            lblDisplayName.Text = sc.DisplayName;
            lblServiceName.Text = sc.ServiceName;
            
            lblStatus.Text = sc.Status.ToString();

            if (sc.Status==ServiceControllerStatus.Running)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (sc.Status==ServiceControllerStatus.Running)
            {
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
            }
        }
    }
}
