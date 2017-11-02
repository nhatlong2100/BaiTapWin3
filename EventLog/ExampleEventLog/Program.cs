using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ExampleEventLog
{
    class Program
    {
        static void Main(string[] args)
        {
            string sSource;
            string sLog;
            string sEvent;

            sSource = "dotNET Sample App";
            sLog = "Application";
            sEvent = "Sample Event";

            if (!EventLog.SourceExists(sSource))
            {
                EventLog.CreateEventSource(sSource, sLog);
            }
            string str = Console.ReadLine();
            EventLog.WriteEntry(sSource,str);

        }
    }
}
