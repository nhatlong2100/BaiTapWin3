using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Remote;
namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private MyDatabase obj;
        private void Form1_Load(object sender, EventArgs e)
        {
            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, true);
            obj = (MyDatabase)Activator.GetObject(typeof(MyDatabase), "tcp://localhost:2100/Database");
            obj.MoKetNoi();

            DataTable dt = obj.AllPosition();
            cbbListPos.DataSource = obj.AllPosition();
            cbbListPos.ValueMember = "TypeUser";
            cbbListPos.DisplayMember = "TypeName";
            ListStaff(cbbListPos.SelectedValue.ToString());
        }

        public void ListStaff(string chucvu)
        {
            dgvListStaff.DataSource= obj.SelectStaffWhere(chucvu);
        }

        private void cbbListPos_SelectedValueChanged(object sender, EventArgs e)
        {
            ListStaff(cbbListPos.SelectedValue.ToString());
        }
    }
}
