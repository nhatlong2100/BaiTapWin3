using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ProxyObject;
namespace TangService
{
    public partial class KiemTraSoNgTo : ServiceBase
    {
        private TcpChannel tcpChannel = null;
        private int port = 6606;
        private Type type;
        private WellKnownObjectMode wellKnownMode;
        private string objURI;

        public KiemTraSoNgTo()
        {
            InitializeComponent();
            if (EventLog.SourceExists("Prime6606") == false)
            {
                EventLog.CreateEventSource("Prime6606", "Log6606");
            }
            eventLog1.Source = "Prime6606";
            eventLog1.Log = "Log6606";
        }

        private void myServerStart()
        {
            try
            {
                myServerStop();
                //Tạo kênh
                tcpChannel = new TcpChannel(port);
                ChannelServices.RegisterChannel(tcpChannel, false);
                //Dang ky
                type = typeof(PrimeProxy);
                objURI = "PRIME_URI";
                wellKnownMode = WellKnownObjectMode.Singleton;
                RemotingConfiguration.RegisterWellKnownServiceType(type, objURI, wellKnownMode);
                eventLog1.WriteEntry("Server khởi động tại port " + port.ToString() + " lúc " + DateTime.Now.ToString());

            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("Lỗi: " + ex.Message);
            }
        }

        private void myServerStop()
        {
            try
            {
                if (ChannelServices.GetChannel("tcp")!=null)
                {
                    ChannelServices.UnregisterChannel(tcpChannel);
                    eventLog1.WriteEntry("Server tắt tại port " + port.ToString() + " lúc " + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("Lỗi: " + ex.Message);
            }
        }

        protected override void OnStart(string[] args)
        {
            myServerStart();
        }

        protected override void OnStop()
        {
            myServerStop();
        }
    }
}
