using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);
            TcpListener server = new TcpListener(ipep);
            server.Start();

            TcpClient client = server.AcceptTcpClient();

            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            while (true)
            {
                string[] input = sr.ReadLine().Split('_');
                string cong = (Convert.ToInt32(input[0]) + Convert.ToInt32(input[1])).ToString();
                string tru = (Convert.ToInt32(input[0]) - Convert.ToInt32(input[1])).ToString();
                string nhan = (Convert.ToInt32(input[0]) * Convert.ToInt32(input[1])).ToString();
                string chia = "";
                if (Convert.ToInt32(input[1]) != 0)
                {
                     chia = (Convert.ToInt32(input[0]) / Convert.ToInt32(input[1])).ToString();
                }
                else
                {
                     chia = "Khong chia cho 0";
                }
                string kq = cong + "_" + tru + "_" + nhan + "_" + chia;
                sw.WriteLine(kq.ToString());
                sw.Flush();
            }
            sr.Close();
            sw.Close();
            client.Close();
        }
    }
}
