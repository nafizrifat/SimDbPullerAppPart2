using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimDbPullerAppPart2
{
    class LogWriter
    {
        internal static void WriteLog(string msg)
        {
            DateTime dateTime = DateTime.Now.Date;

            string path = @"Application Log\";
            string fileName = dateTime.ToString("dd.MM.yyyy") + ".txt";

            if (!System.IO.File.Exists(path + fileName))
            {
                Directory.CreateDirectory(path);
                TextWriter tw = new StreamWriter(path + fileName);
                tw.WriteLine(DateTime.Now + " : " + msg);
                tw.Close();
            }
            else if (File.Exists(path + fileName))
            {
                using (var tw = new StreamWriter(path + fileName, true))
                {
                    tw.WriteLine(DateTime.Now + " : " + msg);
                }
            }
        }

        internal static void LogApplicationClosing()
        {
            WriteLog("----------------------------Application Closed---------------------");
        }

        internal static void LogWithMessage(string msg)
        {
            WriteLog(msg);
        }

        internal static void LogApplicationRunning()
        {
            WriteLog("----------------------------Application Starts---------------------");
        }
    }
}
