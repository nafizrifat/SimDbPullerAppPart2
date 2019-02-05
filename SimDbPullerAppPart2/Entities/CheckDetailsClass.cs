using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimDbPullerAppPart2.Entities
{
  class CheckDetailsClass
    {
        public int guestchecklineitemid;
        public int guestcheckid;
        public int organizationid;
        public int locationid;
        public int revenuecenterid;
        public int ordertypeid;
        public DateTime businessdate;
        public DateTime transdatetime;
        public int daypartid;
        public int fixedperiod;
        public int uwsid;
        public string checkEmpName;
        public int checkEmpNumber;
        public string transactionType;
        public int linenum;
        public int linecount;
        public double linetotal;
        public string itemName;
        public int itemNumber;
        public string familyGroupName;
        public string majorGroupName;
        public int pricelevel;
        public double costtotal;
        public string discountName;
        public int discountNumber;
        public string serviceChargeName;
        public int serviceChargeNumber;
        public string taxexemptref;
        public int activetaxes;
        public double reportincltaxtotal;
        public double tax1total;
        public double tax2total;
        public double tax3total;
        public string tenderName;
        public int tenderNumber;
        public bool voidFlagTF;
        public bool returnFlagTF;
        public string reasonName;
        public string reasonCode;
        public DateTime ETL_ExtractTimeStamp;


        public static CheckDetailsClass FromCsv(string csvLine)
        {

            string[] values = csvLine.Split(',');
            CheckDetailsClass aCheckDetails = new CheckDetailsClass();

            aCheckDetails.guestchecklineitemid = values[0] == null ? 0 : values[0] == "" ? 0 : Convert.ToInt32(values[0]);
            aCheckDetails.guestcheckid = values[1] == null ? 0 : values[1] == "" ? 0 : Convert.ToInt32(values[1]);
            aCheckDetails.organizationid = values[2] == null ? 0 : values[2] == "" ? 0 : Convert.ToInt32(values[2]);
            aCheckDetails.locationid = values[3] == null ? 0 : values[3] == "" ? 0 : Convert.ToInt32(values[3]);
            aCheckDetails.revenuecenterid = values[4] == null ? 0 : values[4] == "" ? 0 : Convert.ToInt32(values[4]);
            aCheckDetails.ordertypeid = values[5] == null ? 0 : values[5] == "" ? 0 : Convert.ToInt32(values[5]);
            aCheckDetails.businessdate = Convert.ToDateTime(values[6]);
            aCheckDetails.transdatetime = Convert.ToDateTime(values[7]);
            aCheckDetails.daypartid = values[8] == null ? 0 : values[8] == "" ? 0 : Convert.ToInt32(values[8]);
            aCheckDetails.fixedperiod = values[9] == null ? 0 : values[9] == "" ? 0 : Convert.ToInt32(values[9]);
            aCheckDetails.uwsid = values[10] == null ? 0 : values[10] == "" ? 0 : Convert.ToInt32(values[10]);
            aCheckDetails.checkEmpName = Convert.ToString(values[11]);
            aCheckDetails.checkEmpNumber = values[12] == null ? 0 : values[12] == "" ? 0 : Convert.ToInt32(values[12]);
            aCheckDetails.transactionType = Convert.ToString(values[13]);
            aCheckDetails.linenum = values[14] == null ? 0 : values[14] == "" ? 0 : Convert.ToInt32(values[14]);
            aCheckDetails.linecount = values[15] == null ? 0 : values[15] == "" ? 0 : Convert.ToInt32(values[15]);
            aCheckDetails.linetotal = values[16] == null ? 0 : values[16] == "" ? 0 : Convert.ToDouble(values[16]);
            aCheckDetails.itemName = Convert.ToString(values[17]);
            aCheckDetails.itemNumber = values[18] == null ? 0 : values[18] == "" ? 0 : Convert.ToInt32(values[18]);
            aCheckDetails.familyGroupName = Convert.ToString(values[19]);
            aCheckDetails.majorGroupName = Convert.ToString(values[20]);
            aCheckDetails.pricelevel = values[21] == null ? 0 : values[21] == "" ? 0 : Convert.ToInt32(values[21]);
            aCheckDetails.costtotal = values[22] == null ? 0 : values[22] == "" ? 0 : Convert.ToDouble(values[22]);
            aCheckDetails.discountName = Convert.ToString(values[23]);
            aCheckDetails.discountNumber = values[24] == null ? 0 : values[24] == "" ? 0 : Convert.ToInt32(values[24]);
            aCheckDetails.serviceChargeName = Convert.ToString(values[25]);
            aCheckDetails.serviceChargeNumber = values[26] == null ? 0 : values[26] == "" ? 0 : Convert.ToInt32(values[26]);
            aCheckDetails.taxexemptref = Convert.ToString(values[27]);
            aCheckDetails.activetaxes = values[28] == null ? 0 : values[28] == "" ? 0 : Convert.ToInt32(values[28]);
            aCheckDetails.reportincltaxtotal = values[29] == null ? 0 : values[29] == "" ? 0 : Convert.ToDouble(values[29]);
            aCheckDetails.tax1total = values[30] == null ? 0 : values[30] == "" ? 0 : Convert.ToDouble(values[30]);
            aCheckDetails.tax2total = values[31] == null ? 0 : values[31] == "" ? 0 : Convert.ToDouble(values[31]);
            aCheckDetails.tax3total = values[32] == null ? 0 : values[32] == "" ? 0 : Convert.ToDouble(values[32]);
            aCheckDetails.tenderName = Convert.ToString(values[33]);
            aCheckDetails.tenderNumber = values[34] == null ? 0 : values[34] == "" ? 0 : Convert.ToInt32(values[34]);
            aCheckDetails.voidFlagTF = values[35] == "" ? false : Convert.ToBoolean(values[35]);
            aCheckDetails.returnFlagTF = values[36] == "" ? false : Convert.ToBoolean(values[36]);
            aCheckDetails.reasonName = Convert.ToString(values[37]);
            aCheckDetails.reasonCode = Convert.ToString(values[38]);
            aCheckDetails.ETL_ExtractTimeStamp = Convert.ToDateTime(values[39]);


            return aCheckDetails;
        }
    }
}
