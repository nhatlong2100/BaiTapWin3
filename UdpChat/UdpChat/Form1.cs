using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using myStruct;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace UdpChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DataReceive()
        {
            UdpClient receive = new UdpClient(int.Parse(txtLocalPort.Text));
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] data = new byte[1024];
                data = receive.Receive(ref ipep);
                //string s = Encoding.UTF8.GetString(data);
                //rtxtDataReceive.Text += "Receive: " + s + "\r\n";
                HamMaHoa(data,"Receive: ");
            }
        }

        private void HamMaHoa(byte[] data,string Title)
        {
            myStruct.Structure str = new Structure();
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter bformat = new BinaryFormatter();
            str = (Structure)bformat.Deserialize(stream);

            rtxtDataReceive.SelectionFont = str.MyFont;
            rtxtDataReceive.SelectionColor = str.MyColor;
            //rtxtDataReceive.Text += "Receive: " + str.TextChat + "\r\n";
            rtxtDataReceive.AppendText(Title);
            rtxtDataReceive.AppendText(str.TextChat);
            rtxtDataReceive.AppendText(Environment.NewLine);
            rtxtDataReceive.ScrollToCaret();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Thread receivedata = new Thread(new ThreadStart(DataReceive));
            receivedata.IsBackground = true;
            receivedata.Start();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UdpClient send = new UdpClient();
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(txtRemoteIP.Text), Convert.ToInt32(txtRemotePort.Text));
            //Mã hóa
            myStruct.Structure str = new Structure();
            str.TextChat = txtDataSend.Text;
            str.MyFont = txtDataSend.Font;
            str.MyColor = txtDataSend.ForeColor;
            MemoryStream stream = new MemoryStream();
            BinaryFormatter bformat = new BinaryFormatter();
            bformat.Serialize(stream, str);
            //Gửi
            byte[] data = new byte[1024];
            data = stream.ToArray();

            //byte[] data = new byte[1024];
            //data = Encoding.UTF8.GetBytes(txtDataSend.Text);
            send.Send(data, data.Length, ipep);
            //rtxtDataReceive.Text += "Sender: " + txtDataSend.Text + "\r\n";
            //Show
            HamMaHoa(data, "Sender: ");

            txtDataSend.Clear();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDataSend.ForeColor = colorDialog1.Color;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDataSend.Font = fontDialog1.Font;
            }
        }

        private void lklblClearLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rtxtDataReceive.Clear();
        }

        private void lklblSaveLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.Filter = "RTF Files|*.rtf";
            if (saveFileDialog1.ShowDialog()==DialogResult.OK && saveFileDialog1.FileName.Length>0)
            {
                rtxtDataReceive.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }
    }
}
