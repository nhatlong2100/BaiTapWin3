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
namespace Lession_20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListServiceStart();
            ListServiceStop();
        }

        void ListServiceStart()
        {
            lvListServiceRunning.Items.Clear();
            ListViewItem item;
            foreach (ServiceController sc in ServiceController.GetServices())
            {
                if (sc.Status==ServiceControllerStatus.Running)
                {
                    item = new ListViewItem(sc.ServiceName);
                    lvListServiceRunning.Items.Add(item);
                }
            }
            
        }

        void ListServiceStop()
        {
            lvListServiceStopped.Items.Clear();
            ListViewItem item;
            foreach (ServiceController sc in ServiceController.GetServices())
            {
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    item = new ListViewItem(sc.ServiceName);
                    lvListServiceStopped.Items.Add(item);
                }
            }
        }

        private void btnReFresh_Click(object sender, EventArgs e)
        {
            ListServiceStart();
            ListServiceStop();
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            int index = lvListServiceStopped.SelectedIndices[0];
            if (index==0)
            {
                btnStartService.Enabled = false;
            }
            else
            {
                ServiceController sc = new ServiceController(lvListServiceStopped.Items[index].Text);
                sc.Start();
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            int index = lvListServiceRunning.SelectedIndices[0];
            if (index == 0)
            {
                lvListServiceRunning.Enabled = false;
            }
            else
            {
                ServiceController sc = new ServiceController(lvListServiceRunning.Items[index].Text);
                sc.Stop();
            }
        }
    }
}
