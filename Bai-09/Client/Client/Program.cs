using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);
            TcpClient client = new TcpClient();
            client.Connect(ipep);

            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            while (true)
            {
                Console.Write("Moi nhap so a: ");
                string a = Console.ReadLine();
                Console.Write("Moi nhap so b: ");
                string b = Console.ReadLine();
                string input = a + "_" + b;
                sw.WriteLine(input);
                sw.Flush();
                string[] kq = sr.ReadLine().Split('_');

                Console.WriteLine("Cong: {0}", kq[0]);
                Console.WriteLine("Tru: {0}", kq[1]);
                Console.WriteLine("Nhan: {0}", kq[2]);
                Console.WriteLine("Chia: {0}", kq[3]);
            }
            sr.Close();
            sw.Close();
            client.Close();
        }
    }
}
