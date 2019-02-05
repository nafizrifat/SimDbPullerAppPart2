using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimDbPullerAppPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            LogWriter.LogApplicationRunning();
            

            ExportDiningAnalytics();
            LogWriter.LogApplicationClosing();
        }

        private static void ExportDiningAnalytics()
        {
          
            DateTime lastCheckDetailsDate;
            DateTime todaysDate = DateTime.Now;
            //  lastCheckHeadersDate = DataLayer.GetLastCheckHeadersDate();
            LogWriter.LogWithMessage("ExportDiningAnalytics_ProcessDate "+ todaysDate);
            DataLayer.ImportExportCheckDetails(todaysDate);
            DataLayer.ImportExportCheckHeaders(todaysDate);
            DataLayer.ImportExportRevenueCenter(todaysDate);
        }
        
    }
}
