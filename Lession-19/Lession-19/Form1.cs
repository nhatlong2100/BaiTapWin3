using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrivateAssemblyPrivatel;
namespace Lession_19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WindowsService ws = new WindowsService();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string item in ws.GetServices())
            {
                bunifuDropdown1.AddItem(item);
            }
        }


        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            lblStatus.Text = ws.ServiceStatus(bunifuDropdown1.selectedValue.ToString());
        }
    }
}
