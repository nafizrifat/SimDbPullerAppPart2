using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimDbPullerAppPart2.Entities
{
   public class RevenueCenterClass
    {
       public int revenueCenterID;
        public int organizationID;
        public int locationID;
        public string name;

        public static RevenueCenterClass FromCsv(string csvLine)
        {

            string[] values = csvLine.Split(',');
            RevenueCenterClass aRevenueCenter = new RevenueCenterClass();

            aRevenueCenter.revenueCenterID = values[0] == null ? 0 : values[0] == "" ? 0 : Convert.ToInt32(values[0]);
            aRevenueCenter.organizationID = values[1] == null ? 0 : values[1] == "" ? 0 : Convert.ToInt32(values[1]);
            aRevenueCenter.locationID = values[2] == null ? 0 : values[2] == "" ? 0 : Convert.ToInt32(values[2]);
            aRevenueCenter.name = Convert.ToString(values[3]);
            

            return aRevenueCenter;
        }

    }
}
