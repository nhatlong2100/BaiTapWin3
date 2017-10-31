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
using System.Runtime.Remoting.Channels.Tcp;using ProxyObject;
namespace TangServer
{
    public partial class Server : Form
    {
        private TcpChannel tcpChannel = null;
        private int port = 8998;
        private Type type;
        private WellKnownObjectMode wellKnownMode;
        private string objURI;

        public Server()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStop.PerformClick();
                port = Convert.ToInt32(txtPort.Text);
                //Tạo channel truyền dữ liệu
                tcpChannel = new TcpChannel(port);
                ChannelServices.RegisterChannel(tcpChannel, false);
                //Đăng ký remote object với Remoting framework
                type = typeof(PrimeProxy);
                objURI = "PRIME_URI";
                if (radSingleton.Checked)
                {
                    wellKnownMode = WellKnownObjectMode.Singleton;
                }
                else
                {
                    wellKnownMode = WellKnownObjectMode.SingleCall;
                }
                RemotingConfiguration.RegisterWellKnownServiceType(type, objURI, wellKnownMode);

                txtStatus.Text = "Start in Port: " + port.ToString() + " at: " + DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (ChannelServices.GetChannel("tcp")!=null)
            {
                ChannelServices.UnregisterChannel(tcpChannel);
                txtStatus.Text = "Stop in Port: " + port.ToString() + " at: " + DateTime.Now.ToString();
            }
        }
    }
}
