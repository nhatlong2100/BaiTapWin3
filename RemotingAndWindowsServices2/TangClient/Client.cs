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
using ProxyObject;

namespace TangClient
{
    public partial class Client : Form
    {
        
        string URL = "";
        Type type;
        PrimeProxy primeObject;
        public Client()
        {
            InitializeComponent();
        }

        private void EnableControl(bool b)
        {
            btnGetResult.Enabled = b;
            txtClient.Enabled = b;
            txtN.Enabled = b;
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                URL = "tcp://" + txtIP.Text + ":" + txtPort.Text + "/PRIME_URI";
                type = typeof(PrimeProxy);
                RemotingConfiguration.RegisterWellKnownClientType(type, URL);

                primeObject = new PrimeProxy();
                lblStatus.Text = "Đã tạo xong proxy, vui lòng nhập tên client và số n.";
                EnableControl(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                EnableControl(false);
                URL = "";
                throw;
            }
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            string client = txtClient.Text;
            int n = Convert.ToInt32(txtN.Text);

            primeObject.setConnectClient(client);

            List<int> lstPrime = primeObject.getListPrime(n);

            lsbListPrime.Items.Clear();
            foreach (int x in lstPrime)
                lsbListPrime.Items.Add(x);

            List<string> lstClient = primeObject.ListClient;

            lsbListClient.Items.Clear();
            foreach (string y in lstClient)
                lsbListClient.Items.Add(y);

            //string message = "";

            //message = "Hello [" + primeObject.CurrentClient + "] Hàm này được triệu gọi "+primeObject.RequestNumber+"\n";
            //if (primeObject.RequestNumber==1)
            //{
            //    message += "Bạn là người đầu tiên gọi hàm";
            //}
            //else
            //{
            //    message += "Người gọi hàm trước đó là [" + lstClient[lstClient.Count-1] +"]";
            //}
            //lblMessage.Text = message;
        }
    }
}