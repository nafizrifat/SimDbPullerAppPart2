using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimDbPullerAppPart2.Entities
{

    class CheckHeadersClass
    {
       public int guestcheckid;
       public  int organizationid;
        public int locationid;
        public int revenuecenterid;
        public DateTime businessdate;
        public DateTime opendatetime;
        public DateTime closedatetime;

        public string checknum;
        public double discounttotal;
        public double servicechargetotal;

        public double svcchargeexempttotal;
        public double taxtotal;
        public double tax1total;
        public double nettaxtotal;
        public double subtotal;
        public double checktotal;
        public double amountdue;

        public bool cashFlagTF;
        public double returntotal;
        public DateTime ETL_ExtractTimeStamp;



        public static CheckHeadersClass FromCsv(string csvLine)
        {

            string[] values = csvLine.Split(',');
            CheckHeadersClass aCheckHeaders = new CheckHeadersClass();

            aCheckHeaders.guestcheckid = values[0] == null ? 0 : values[0] == "" ? 0 : Convert.ToInt32(values[0]);
            aCheckHeaders.organizationid = values[1] == null ? 0 : values[1] == "" ? 0 : Convert.ToInt32(values[1]);
            aCheckHeaders.locationid = values[2] == null ? 0 : values[2] == "" ? 0 : Convert.ToInt32(values[2]);
            aCheckHeaders.revenuecenterid = values[3] == null ? 0 : values[3] == "" ? 0 : Convert.ToInt32(values[3]);
            aCheckHeaders.businessdate = Convert.ToDateTime(values[4]);
            aCheckHeaders.opendatetime = Convert.ToDateTime(values[5]);
            aCheckHeaders.closedatetime = Convert.ToDateTime(values[6]);
            aCheckHeaders.checknum = Convert.ToString(values[7]);
            aCheckHeaders.discounttotal = values[8] == null ? 0 : values[8] == "" ? 0 : Convert.ToDouble(values[8]);
            aCheckHeaders.servicechargetotal = values[9] == null ? 0 : values[9] == "" ? 0 : Convert.ToDouble(values[9]);
            aCheckHeaders.svcchargeexempttotal = values[10] == null ? 0 : values[10] == "" ? 0 : Convert.ToDouble(values[10]);
            aCheckHeaders.taxtotal = values[11] == null ? 0 : values[11] == "" ? 0 : Convert.ToDouble(values[11]);
            aCheckHeaders.tax1total = values[12] == null ? 0 : values[12] == "" ? 0 : Convert.ToDouble(values[12]);
            aCheckHeaders.nettaxtotal = values[13] == null ? 0 : values[13] == "" ? 0 : Convert.ToDouble(values[13]);
            aCheckHeaders.subtotal = values[14] == null ? 0 : values[14] == "" ? 0 : Convert.ToDouble(values[14]);
            aCheckHeaders.checktotal = values[15] == null ? 0 : values[15] == "" ? 0 : Convert.ToDouble(values[15]);
            aCheckHeaders.amountdue = values[16] == null ? 0 : values[16] == "" ? 0 : Convert.ToDouble(values[16]);
            aCheckHeaders.cashFlagTF = values[17] == "" ? false : Convert.ToBoolean(values[17]);
            aCheckHeaders.returntotal = values[18] == null ? 0 : values[18] == "" ? 0 : Convert.ToDouble(values[18]);
            aCheckHeaders.ETL_ExtractTimeStamp = Convert.ToDateTime(values[19]);



            return aCheckHeaders;
        }
    }


    //class CheckHeadersClass
    //{
    //    int guestchecklineitemid;
    //    int guestcheckid;
    //    int organizationid;
    //    int locationid;
    //    int revenuecenterid;
    //    DateTime businessdate;
    //    DateTime opendatetime;
    //    DateTime closedatetime;
    //    int checknum;
    //    double discounttotal;
    //    double servicechargetotal;
    //    double svcchargeexempttotal;
    //    double taxtotal;
    //    double tax1total;
    //    double nettaxtotal;
    //    double subtotal;
    //    double checktotal;
    //    double amountdue;
    //    bool cashFlagTF;
    //    double returntotal;
    //    DateTime ETL_ExtractTimeStamp;



    //    public static CheckHeadersClass FromCsv(string csvLine)
    //    {

    //        string[] values = csvLine.Split(',');
    //        CheckHeadersClass aCheckHeaders = new CheckHeadersClass();



    //        aCheckHeaders.guestchecklineitemid = values[0] == null ? 0 : values[0] == "" ? 0 : Convert.ToInt32(values[0]);
    //        aCheckHeaders.guestcheckid = values[1] == null ? 0 : values[1] == "" ? 0 : Convert.ToInt32(values[1]);
    //        aCheckHeaders.organizationid = values[2] == null ? 0 : values[2] == "" ? 0 : Convert.ToInt32(values[2]);
    //        aCheckHeaders.locationid = values[3] == null ? 0 : values[3] == "" ? 0 : Convert.ToInt32(values[3]);
    //        aCheckHeaders.revenuecenterid = values[4] == null ? 0 : values[4] == "" ? 0 : Convert.ToInt32(values[4]);
    //        aCheckHeaders.businessdate = Convert.ToDateTime(values[5]);
    //        aCheckHeaders.opendatetime = Convert.ToDateTime(values[6]);
    //        aCheckHeaders.closedatetime = Convert.ToDateTime(values[7]);
    //        aCheckHeaders.discounttotal = values[8] == null ? 0 : values[8] == "" ? 0 : Convert.ToDouble(values[8]);
    //        aCheckHeaders.servicechargetotal = values[9] == null ? 0 : values[9] == "" ? 0 : Convert.ToDouble(values[9]);
    //        aCheckHeaders.svcchargeexempttotal = values[10] == null ? 0 : values[10] == "" ? 0 : Convert.ToDouble(values[10]);
    //        aCheckHeaders.taxtotal = values[11] == null ? 0 : values[11] == "" ? 0 : Convert.ToDouble(values[11]);
    //        aCheckHeaders.tax1total = values[12] == null ? 0 : values[12] == "" ? 0 : Convert.ToDouble(values[12]);
    //        aCheckHeaders.nettaxtotal = values[13] == null ? 0 : values[13] == "" ? 0 : Convert.ToDouble(values[13]);
    //        aCheckHeaders.subtotal = values[14] == null ? 0 : values[14] == "" ? 0 : Convert.ToDouble(values[14]);
    //        aCheckHeaders.checktotal = values[15] == null ? 0 : values[15] == "" ? 0 : Convert.ToDouble(values[15]);
    //        aCheckHeaders.amountdue = values[16] == null ? 0 : values[16] == "" ? 0 : Convert.ToDouble(values[16]);
    //        aCheckHeaders.cashFlagTF = values[17] == "" ? false : Convert.ToBoolean(values[17]);
    //        aCheckHeaders.returntotal = values[18] == null ? 0 : values[18] == "" ? 0 : Convert.ToDouble(values[18]);
    //        aCheckHeaders.ETL_ExtractTimeStamp = Convert.ToDateTime(values[19]);
    //        return aCheckHeaders;
    //    }
    //}
}
