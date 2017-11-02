using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Remote;
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServerChannel channel = new TcpServerChannel(2100);
            ChannelServices.RegisterChannel(channel, true);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyDatabase), "Database", WellKnownObjectMode.SingleCall);
            Console.WriteLine("Server running");
            Console.ReadKey();
        }
    }
}
