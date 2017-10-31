using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace wsGiamSatThuMuc
{
    public partial class GiamSatThuMuc : ServiceBase
    {
        public GiamSatThuMuc()
        {
            InitializeComponent();
            if (!EventLog.SourceExists("GiamSatThuMuc_Source"))
            {
                EventLog.CreateEventSource("GiamSatThuMuc_Source", "GiamSatThuMuc_Log");
            }
            SoGhiGiamSatThuMuc.Source = "GiamSatThuMuc_Source";
            SoGhiGiamSatThuMuc.Log = "GiamSatThuMuc_Log";
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                SoGhiGiamSatThuMuc.WriteEntry("Running");
                Thread _t = new Thread(new ThreadStart(DoWork));
                _t.IsBackground = true;
                _t.Start();

            }
            catch (Exception ex)
            {
                SoGhiGiamSatThuMuc.WriteEntry(ex.Message);
                SoGhiGiamSatThuMuc.Close();
            }

            Console.ReadLine();
        }
        public void DoWork()
        {
            FileSystemWatcher watch = new FileSystemWatcher();
            watch.Path = @"C:\GiamSat\";
            watch.Changed += new FileSystemEventHandler(OnChanged);
            watch.Created += new FileSystemEventHandler(OnChanged);
            watch.Deleted += new FileSystemEventHandler(OnChanged);
            watch.Renamed += new RenamedEventHandler(OnRenamed);

            watch.EnableRaisingEvents = true;
            watch.IncludeSubdirectories = true;
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            string dir = @"C:\GiamSat\" + e.Name;
            if (e.FullPath==dir)
            {
                Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
                SoGhiGiamSatThuMuc.WriteEntry("Da co thao tac Changed trong thu muc C:\\GiamSat");
            }
        }

        public void OnRenamed(object source,FileSystemEventArgs e)
        {
            string dir = @"C:\GiamSat\" + e.Name;
            if (e.FullPath == dir)
            {
                Console.WriteLine("File: {0} rename to {1}",dir,e.FullPath);
                SoGhiGiamSatThuMuc.WriteEntry("Da co thao tac Renamed trong thu muc C:\\GiamSat");
            }
        }

        protected override void OnStop()
        {
            SoGhiGiamSatThuMuc.WriteEntry("Stopped");
        }
    }
}
