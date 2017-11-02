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
using System.Management;
using System.Threading;

namespace Services
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// Lấy danh sách các services đưa lên listview
        /// </summary>
        void GetListServices()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            lvwListServices.Items.Clear();
            ListViewItem item;
            foreach (ServiceController sc in ServiceController.GetServices())
            {
                item = new ListViewItem(sc.ServiceName);
                item.SubItems.Add(sc.DisplayName);
                item.SubItems.Add(GetServiceDescription(sc.ServiceName));
                item.SubItems.Add(sc.Status.ToString());
                item.SubItems.Add(GetStartupType(sc.ServiceName));
                item.SubItems.Add(GetLogOnAs(sc.ServiceName));
                
                lvwListServices.Items.Add(item);
            }

        }

        /// <summary>
        /// Lấy Description
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static string GetServiceDescription(string serviceName)
        {
            try
            {
                using (ManagementObject service = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", serviceName))))
                {
                    return service["Description"].ToString();
                }
            }
            catch (Exception)
            {
               
                return "";
            }
        }

        /// <summary>
        /// Lấy startup type
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string GetStartupType(string serviceName)
        {
            try
            {
                string logonas = "";
                SelectQuery query = new System.Management.SelectQuery(string.Format(
        "select name, startmode from Win32_Service where name = '{0}'", serviceName));
                using (ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query))
                {
                    foreach (ManagementObject service in searcher.Get())
                    {
                        logonas = service["startmode"].ToString();
                    }
                }
                return logonas;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        /// <summary>
        /// Lấy Log On As
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string GetLogOnAs(string serviceName)
        {
            try
            {
                string logonas = "";
                SelectQuery query = new System.Management.SelectQuery(string.Format(
        "select name, startname from Win32_Service where name = '{0}'", serviceName));
                using (ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query))
                {
                    foreach (ManagementObject service in searcher.Get())
                    {
                        logonas = service["startname"].ToString();
                    }
                }
                return logonas;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(GetListServices));
            t.IsBackground = true;
            t.Start();
            Thread.Sleep(5);
        }

        private void lvwListServices_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                if (lvwListServices.FocusedItem.Bounds.Contains(e.Location)==true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                    //Vô hiệu hóa pause, resume
                    pauseToolStripMenuItem.Enabled = false;
                    pauseToolStripMenuItem1.Enabled = false;
                    resumeToolStripMenuItem.Enabled = false;
                    resumeToolStripMenuItem1.Enabled = false;
                    restartToolStripMenuItem.Enabled = false;
                    restartToolStripMenuItem1.Enabled = false;
                    //Kiểm tra stop start
                }
            }
        }

        void StartService(string serviceName)
        {
            ServiceController sc = new ServiceController(serviceName);
            sc.Start();
        }

        void StopService(string serviceName)
        {
            ServiceController sc = new ServiceController(serviceName);
            sc.Stop();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = lvwListServices.Items[0].Text;
            if (new ServiceController(name).Status==ServiceControllerStatus.Running)
            {
                MessageBox.Show("Service is running");
            }
            else
            {
                StartService(name);
            }
            
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = lvwListServices.Items[0].Text;
            if (new ServiceController(name).Status == ServiceControllerStatus.Stopped)
            {
                MessageBox.Show("Service is stopped");
            }
            else
            {
                StopService(name);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(GetListServices));
            t.IsBackground = true;
            t.Start();
            Thread.Sleep(5);
        }
    }
}
