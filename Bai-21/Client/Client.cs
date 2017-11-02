using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Remote;
using System.Runtime;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        MyClass obj;
        private void btnRunSQL_Click(object sender, EventArgs e)
        {
            //DataTable dtab = new DataTable("tbl_NewCategory");
            //MyClass ob = new MyClass();
            dgvDispay.DataSource = null;
            dgvDispay.Rows.Clear();
            DataTable dt = obj.Select(txtSQL.Text);
            
            dgvDispay.DataSource = dt;   
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Client_Load(object sender, EventArgs e)
        {
            TcpChannel c_Channel = new TcpChannel();
            ChannelServices.RegisterChannel(c_Channel, true);
            obj = Activator.GetObject(typeof(MyClass), "tcp://localhost:2100/MyClass") as MyClass;
            obj.MoKetNoi();
        }
    }
}
