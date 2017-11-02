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
using System.Threading;
namespace TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            GetProcess();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Process[] processes;


        void GetProcess()
        {
            processes = Process.GetProcesses();
            listView1.Items.Clear();
            foreach (Process item in processes)
            {
                // Get memory used
                double memsize = 0; // memsize in Megabyte
                double cpu = 0;
                PerformanceCounter PCRam = new PerformanceCounter();
                PCRam.CategoryName = "Process";
                PCRam.CounterName = "Working Set - Private";
                PCRam.InstanceName = item.ProcessName;


                memsize = (PCRam.NextValue() / (1024))/1024;
                //Show List View
                ListViewItem newItem = new ListViewItem() { Text = item.ProcessName };
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Id.ToString() });
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = cpu.ToString()+" %" });
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Math.Round(memsize,2).ToString() + " MB" });
                listView1.Items.Add(newItem);
            }
            sttLabelCountProcesses.Text = "Processes: " + processes.Count().ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (processes.Length != Process.GetProcesses().Length)
            {
                Thread t = new Thread(GetProcess);
                t.Start();
                t.Join();
                Thread.Sleep(1000);
            }
        }
        private void KillTask()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = 0;
                foreach (var item in processes)
                {
                    if (item.ProcessName == listView1.SelectedItems[0].Text)
                    {
                        index = processes.ToList().IndexOf(item);
                        break;
                    }
                }
                processes[index].Kill();
            }
        }
        private void endTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KillTask();
        }

        private void btnEndTask_Click(object sender, EventArgs e)
        {
            KillTask();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Code by : Hồ Nhật Long");
        }
    }
}
