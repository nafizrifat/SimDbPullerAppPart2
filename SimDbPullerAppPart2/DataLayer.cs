using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using SimDbPullerAppPart2.Entities;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SimDbPullerAppPart2
{
    public class DataLayer
    {
        public DataLayer()
        {
        }
        const int ERROR_SHARING_VIOLATION = 32;
        const int ERROR_LOCK_VIOLATION = 33;

        private static bool IsFileLocked(Exception exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            LogWriter.LogWithMessage("File ERROR_SHARING_VIOLATION/ERROR_LOCK_VIOLATION");
            return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        }

        internal static bool CanReadFile(string filePath)
        {
            //Try-Catch so we dont crash the program and can check the exception
            try
            {
                //The "using" is important because FileStream implements IDisposable and
                //"using" will avoid a heap exhaustion situation when too many handles  
                //are left undisposed.
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    if (fileStream != null) fileStream.Close();  //This line is me being overly cautious, fileStream will never be null unless an exception occurs... and I know the "using" does it but its helpful to be explicit - especially when we encounter errors - at least for me anyway!
                }
            }
            catch (IOException ex)
            {
                //THE FUNKY MAGIC - TO SEE IF THIS FILE REALLY IS LOCKED!!!
                if (IsFileLocked(ex))
                {
                    // do something, eg File.Copy or present the user with a MsgBox - I do not recommend Killing the process that is locking the file
                    return false;
                }
            }
            finally
            { }
            return true;
        }
    
    
    internal static void ImportExportCheckDetails(DateTime todaysDate)
        {
            try
            {
                LogWriter.LogWithMessage("ImportExportCheckDetails_begin=" + DateTime.Now);
                string CheckDetailsPath = ConfigurationManager.AppSettings["CheckDetailsPath"];
                if (!CanReadFile(CheckDetailsPath))
                {
                    LogWriter.LogWithMessage("Problem With The File: " + CheckDetailsPath);
                    return;
                }
                Stopwatch stopWatch = Stopwatch.StartNew();
                if (!System.IO.File.Exists(CheckDetailsPath))
                {
                    LogWriter.LogWithMessage("ImportExportCheckDetails_File not found=" + CheckDetailsPath);
                    return;
                }


                //List<CheckDetailsClass> chieldValues = File.ReadAllLines(CheckDetailsPath)
                //                            .Skip(1)
                //                            .Select(v => CheckDetailsClass.FromCsv(v)).ToList();

               
                DataTable dtNewTemp = GetNewDataTableCheckDetails();
                using (var reader = new StreamReader(CheckDetailsPath))
                {
                    {

                        var firstIgnoredColumn = reader.ReadLine();
                        //while (!reader.EndOfStream && reader.ReadLine() != null)
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                       //     var values = line.Split(';');
                            var values = line.Split(',');
                            if (values.Any())
                            {
                                DataTable dt = new DataTable();

                              

                                object[] arrRow = new object[40];
                                arrRow[0] = values[0] == null ? 0 : values[0] == "" ? 0 : Convert.ToInt32(values[0]);
                                arrRow[1] = values[1] == null ? 0 : values[1] == "" ? 0 : Convert.ToInt32(values[1]);
                                arrRow[2] = values[2] == null ? 0 : values[2] == "" ? 0 : Convert.ToInt32(values[2]);
                                arrRow[3] = values[3] == null ? 0 : values[3] == "" ? 0 : Convert.ToInt32(values[3]);
                                arrRow[4] = values[4] == null ? 0 : values[4] == "" ? 0 : Convert.ToInt32(values[4]);
                                arrRow[5] = values[5] == null ? 0 : values[5] == "" ? 0 : Convert.ToInt32(values[5]);
                                arrRow[6] = Convert.ToDateTime(values[6]);
                                arrRow[7] = Convert.ToDateTime(values[7]);
                                arrRow[8]= values[8] == null ? 0 : values[8] == "" ? 0 : Convert.ToInt32(values[8]);
                                arrRow[9] = values[9] == null ? 0 : values[9] == "" ? 0 : Convert.ToInt32(values[9]);
                                arrRow[10] = values[10] == null ? 0 : values[10] == "" ? 0 : Convert.ToInt32(values[10]);
                                arrRow[11] = Convert.ToString(values[11]);
                                arrRow[12] = values[12] == null ? 0 : values[12] == "" ? 0 : Convert.ToInt32(values[12]);
                                arrRow[13] = Convert.ToString(values[13]);
                                arrRow[14]= values[14] == null ? 0 : values[14] == "" ? 0 : Convert.ToInt32(values[14]);
                                arrRow[15] = values[15] == null ? 0 : values[15] == "" ? 0 : Convert.ToInt32(values[15]);
                                arrRow[16] = values[16] == null ? 0 : values[16] == "" ? 0 : Convert.ToDouble(values[16]);
                                arrRow[17]= Convert.ToString(values[17]);
                                arrRow[18] = values[18] == null ? 0 : values[18] == "" ? 0 : Convert.ToInt32(values[18]);
                                arrRow[19] = Convert.ToString(values[19]);
                                arrRow[20] = Convert.ToString(values[20]);
                                arrRow[21] = values[21] == null ? 0 : values[21] == "" ? 0 : Convert.ToInt32(values[21]);
                                arrRow[22] = values[22] == null ? 0 : values[22] == "" ? 0 : Convert.ToDouble(values[22]);
                                arrRow[23] = Convert.ToString(values[23]);
                                arrRow[24] = values[24] == null ? 0 : values[24] == "" ? 0 : Convert.ToInt32(values[24]);
                                arrRow[25] = Convert.ToString(values[25]);
                                arrRow[26] = values[26] == null ? 0 : values[26] == "" ? 0 : Convert.ToInt32(values[26]);
                                arrRow[27] = Convert.ToString(values[27]);
                                arrRow[28]= values[28] == null ? 0 : values[28] == "" ? 0 : Convert.ToInt32(values[28]);
                                arrRow[29] = values[29] == null ? 0 : values[29] == "" ? 0 : Convert.ToDouble(values[29]);
                                arrRow[30] = values[30] == null ? 0 : values[30] == "" ? 0 : Convert.ToDouble(values[30]);
                                arrRow[31] = values[31] == null ? 0 : values[31] == "" ? 0 : Convert.ToDouble(values[31]);
                                arrRow[32] = values[32] == null ? 0 : values[32] == "" ? 0 : Convert.ToDouble(values[32]);
                                arrRow[33] = Convert.ToString(values[33]);
                                arrRow[34] = values[34] == null ? 0 : values[34] == "" ? 0 : Convert.ToInt32(values[34]);
                                arrRow[35]= values[35] == "" ? false : Convert.ToBoolean(values[35]);
                                arrRow[36]= values[36] == "" ? false : Convert.ToBoolean(values[36]);
                                arrRow[37] = Convert.ToString(values[37]);
                                arrRow[38]= Convert.ToString(values[38]);
                                arrRow[39] = Convert.ToDateTime(values[39]);

                                dtNewTemp.Rows.Add(arrRow);
                            }



                        }
                    }
                }
                stopWatch.Stop();
                var message = String.Format(@"Fetched {2} data time taken {0}, CheckDetailsPath data from {1}", stopWatch.Elapsed, CheckDetailsPath, dtNewTemp.Rows.Count);
                LogWriter.LogWithMessage(message);
                //                string finalQueryCheckDetails = String.Empty;

                //                foreach (var aData in chieldValues)
                //                {
                //                    finalQueryCheckDetails += String.Format(@"INSERT INTO [Landinig].[CheckDetails]
                //           ([guestchecklineitemid]
                //           ,[guestcheckid]
                //           ,[organizationid]
                //           ,[locationid]
                //           ,[revenuecenterid]
                //           ,[ordertypeid]
                //           ,[businessdate]
                //           ,[transdatetime]
                //           ,[daypartid]
                //           ,[fixedperiod]
                //           ,[uwsid]
                //           ,[checkEmpName]
                //           ,[checkEmpNumber]
                //           ,[transactionType]
                //           ,[linenum]
                //           ,[linecount]
                //           ,[linetotal]
                //           ,[itemName]
                //           ,[itemNumber]
                //           ,[familyGroupName]
                //           ,[majorGroupName]
                //           ,[pricelevel]
                //           ,[costtotal]
                //           ,[discountName]
                //           ,[discountNumber]
                //           ,[serviceChargeName]
                //           ,[serviceChargeNumber]
                //           ,[taxexemptref]
                //           ,[activetaxes]
                //           ,[reportincltaxtotal]
                //           ,[tax1total]
                //           ,[tax2total]
                //           ,[tax3total]
                //           ,[tenderName]
                //           ,[tenderNumber]
                //           ,[voidFlagTF]
                //           ,[returnFlagTF]
                //           ,[reasonName]
                //           ,[reasonCode]
                //           ,[ETL_ExtractTimeStamp])
                //     VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}',
                //'{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}')", aData.guestchecklineitemid, aData.guestcheckid,
                //      aData.organizationid, aData.locationid, aData.revenuecenterid, aData.ordertypeid, aData.businessdate, aData.transdatetime, aData.daypartid, aData.fixedperiod
                //       , aData.uwsid, aData.checkEmpName, aData.checkEmpNumber, aData.transactionType, aData.linenum, aData.linecount, aData.linetotal, aData.itemName,
                //      aData.itemNumber, aData.familyGroupName, aData.majorGroupName, aData.pricelevel, aData.costtotal, aData.discountName, aData.discountNumber, aData.serviceChargeName, aData.serviceChargeNumber
                //      , aData.taxexemptref, aData.activetaxes, aData.reportincltaxtotal, aData.tax1total, aData.tax2total, aData.tax3total
                //      , aData.tenderName, aData.tenderNumber, aData.voidFlagTF, aData.returnFlagTF, aData.reasonName, aData.reasonCode, aData.ETL_ExtractTimeStamp);
                //                }
                //               var data= MargeDataToDatabase(finalQueryCheckDetails);
                var data = WriteCheckDetailsToDatabase(dtNewTemp);
                if (data)
                {
                    DateTime dateTime = DateTime.Now;
                    string path = @"Archive\";
                    if (!System.IO.File.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                   
                    string fileName = dateTime.ToString("dd.MM.yyyy HH.mm.ss") + "_Local_CheckDetails.csv";
                    System.IO.File.Move(CheckDetailsPath, path+ fileName);

                    LogWriter.LogWithMessage(@"File moved successfully to " + path + fileName);
                }

            }
            catch (Exception ex)
            {
                LogWriter.LogWithMessage("EXCEPTION from  ImportExportCheckDetails: " + ex.Message);
            }
        }

       

        internal static void ImportExportCheckHeaders( DateTime todaysDate)
        {
            try
            {
                LogWriter.LogWithMessage("ImportExportCheckHeaders_begin=" + DateTime.Now);
                string CheckHeadersPath = ConfigurationManager.AppSettings["CheckHeadersPath"];
                if (!CanReadFile(CheckHeadersPath))
                {
                    LogWriter.LogWithMessage("Problem With The File: " + CheckHeadersPath);
                    return;
                }
                if (!System.IO.File.Exists(CheckHeadersPath))
                {
                    LogWriter.LogWithMessage("ImportExportCheckHeaders_File not found=" + CheckHeadersPath);
                    return;
                }

                DataTable dtNewTemp = GetNewDataTable();
                //experiment
                Stopwatch stopWatch = Stopwatch.StartNew();
                using (var reader = new StreamReader(CheckHeadersPath))
                {
                    {

                        var firstIgnoredColumn = reader.ReadLine();
                        //while (!reader.EndOfStream && reader.ReadLine() != null)
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(';');
                            var chieldValues = line.Split(',');
                            if (chieldValues.Any())
                            {
                                DataTable dt = new DataTable();

                                object[] arrRow = new object[20];
                                arrRow[0] = chieldValues[0] == null ? 0 : chieldValues[0] == "" ? 0 : Convert.ToInt32(chieldValues[0]);
                                arrRow[1] = chieldValues[1] == null ? 0 : chieldValues[1] == "" ? 0 : Convert.ToInt32(chieldValues[1]);
                                arrRow[2] = chieldValues[2] == null ? 0 : chieldValues[2] == "" ? 0 : Convert.ToInt32(chieldValues[2]);
                                arrRow[3] = chieldValues[3] == null ? 0 : chieldValues[3] == "" ? 0 : Convert.ToInt32(chieldValues[3]);
                                arrRow[4] = Convert.ToDateTime(chieldValues[4]);
                                arrRow[5] = Convert.ToDateTime(chieldValues[4]);

                                arrRow[6] = Convert.ToDateTime(chieldValues[4]);
                                arrRow[7] = Convert.ToString(chieldValues[7]);
                                arrRow[8] = chieldValues[8] == null ? 0 : chieldValues[8] == "" ? 0 : Convert.ToDouble(chieldValues[8]);
                                arrRow[9] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[10] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[11] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[12] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[13] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[14] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[15] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[16] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[17] = chieldValues[17] == "" ? false : Convert.ToBoolean(chieldValues[17]);
                                arrRow[18] = chieldValues[9] == null ? 0 : chieldValues[9] == "" ? 0 : Convert.ToDouble(chieldValues[9]);
                                arrRow[19] = Convert.ToDateTime(chieldValues[19]);

                                dtNewTemp.Rows.Add(arrRow);
                            }



                        }
                    }
                }
                stopWatch.Stop();
                var message = String.Format(@"Fetched {2} data time taken {0}, CheckHeadersPath data from {1}", stopWatch.Elapsed, CheckHeadersPath, dtNewTemp.Rows.Count);
                LogWriter.LogWithMessage(message);

                var data= WriteCheckHeadersToDatabase(dtNewTemp);
                if (data)
                {
                    DateTime dateTime = DateTime.Now;
                  
                    string path = @"Archive\";
                    if (!System.IO.File.Exists(path))
                    {
                        Directory.CreateDirectory(path);                       
                    }
                    string fileName = dateTime.ToString("dd.MM.yyyy HH.mm.ss") + "_Local_CheckHeaders.csv";
                    System.IO.File.Move(CheckHeadersPath, path + fileName);
                    LogWriter.LogWithMessage(@"File moved successfully to "+ path + fileName );
                }
                //Alternative approch, relatively slower
                //Stopwatch stopWatch2 = Stopwatch.StartNew();
                //List<CheckHeadersClass> chieldValues1 = File.ReadAllLines(CheckHeadersPath)
                //                            .Skip(1)
                //                            .Select(v => CheckHeadersClass.FromCsv(v))
                //                            .ToList();
                //stopWatch2.Stop();
                //var message2 = String.Format(@"\nFetching data from Experiment, Total time e on {0}", stopWatch2.Elapsed);
                //Console.WriteLine(message);
                //var process2Count = chieldValues1.Count();
                //  string finalQueryCheckHeaders = String.Empty;
                //           foreach (var aData in chieldValues)
                //           {
                //               finalQueryCheckHeaders += String.Format(@"INSERT INTO [Landinig].[CheckHeaders]
                //      ([guestcheckid]
                //      ,[organizationid]
                //      ,[locationid]
                //      ,[revenuecenterid]
                //      ,[businessdate]
                //      ,[opendatetime]
                //      ,[closedatetime]
                //      ,[checknum]
                //      ,[discounttotal]
                //      ,[servicechargetotal]
                //      ,[svcchargeexempttotal]
                //      ,[taxtotal]
                //      ,[tax1total]
                //      ,[nettaxtotal]
                //      ,[subtotal]
                //      ,[checktotal]
                //      ,[amountdue]
                //      ,[cashFlagTF]
                //      ,[returntotal]
                //      ,[ETL_ExtractTimeStamp])
                //VALUES
                //      ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
                //      aData.guestcheckid, aData.organizationid, aData.locationid, aData.revenuecenterid, aData.businessdate, aData.opendatetime, aData.closedatetime, aData.checknum, aData.discounttotal,
                //      aData.servicechargetotal, aData.svcchargeexempttotal, aData.taxtotal, aData.tax1total, aData.nettaxtotal, aData.subtotal, aData.checktotal, aData.amountdue, aData.cashFlagTF, aData.returntotal, aData.ETL_ExtractTimeStamp);

                //           }

                //   MargeDataToDatabase(finalQueryCheckHeaders);


            }
            catch (Exception ex)
            {
                LogWriter.LogWithMessage("EXCEPTION from  ImportExportCheckHeaders : " + ex.Message);
            }
        }



        internal static void ImportExportRevenueCenter( DateTime todaysDate)
        {
            try
            {
                LogWriter.LogWithMessage("ImportExportRevenueCenter_begin=" + DateTime.Now);
                string CheckRevenueCenter = ConfigurationManager.AppSettings["RevenueCenterPath"];
                if (!CanReadFile(CheckRevenueCenter))
                {
                    LogWriter.LogWithMessage("Problem With The File: " + CheckRevenueCenter);
                    return;
                }
                if (!System.IO.File.Exists(CheckRevenueCenter))
                {
                    LogWriter.LogWithMessage("ImportExportRevenueCenter_File not found=" + CheckRevenueCenter);
                    return;
                }

                Stopwatch stopWatch = Stopwatch.StartNew();
                List<RevenueCenterClass> chieldValues = File.ReadAllLines(CheckRevenueCenter)
                                            .Skip(1)
                                            .Select(v => RevenueCenterClass.FromCsv(v))
                                            .ToList();

                string finalQueryRevenueCenter = "Delete  from [Landinig].[RevenueCenter]";


                stopWatch.Stop();
                var message = String.Format(@"Fetched {2} data time taken {0}, CheckDetailsPath data from {1}", stopWatch.Elapsed, CheckRevenueCenter, chieldValues.Count);
                LogWriter.LogWithMessage(message);


                foreach (var aData in chieldValues)
                {
                    finalQueryRevenueCenter += String.Format(@"
                        INSERT INTO [Landinig].[RevenueCenter]
                       ([organizationID]
                       ,[locationID]
                       ,[name])
                        VALUES
                       ({0},{1},'{2}')", aData.organizationID, aData.locationID, aData.name);
                }


                var data = MargeDataToDatabase(finalQueryRevenueCenter);

               
                if (data)
                {
                    DateTime dateTime = DateTime.Now;
                    string path = @"Archive\";
                    if (!System.IO.File.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = dateTime.ToString("dd.MM.yyyy HH.mm.ss") + "_Local_RevenueCenter.csv";
                    System.IO.File.Move(CheckRevenueCenter, path + fileName);
                    LogWriter.LogWithMessage(@"File moved successfully from: to " + path + fileName);

                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWithMessage("EXCEPTION from  ImportExportRevenueCenter: " + ex.Message);
            }
        }



        // using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDiningDb"].ToString())


        private static bool MargeDataToDatabase(string query)
        {


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionDiningDb"].ToString()))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCmdUpdate = new SqlCommand();

                    sqlCmdUpdate.CommandText = query;
                    sqlCmdUpdate.Connection = con;
                    sqlCmdUpdate.CommandTimeout = 0;
                    sqlCmdUpdate.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    LogWriter.LogWithMessage("EXCEPTION from  MargeDataToDatabase: " + ex.Message);
                    return false;
                }
            }
        }
        private static bool WriteCheckHeadersToDatabase(DataTable dtNewTemp)
        {

            using (SqlBulkCopy bCopy = new SqlBulkCopy((ConfigurationManager.ConnectionStrings["ConnectionDiningDb"].ToString())))
            {
                try
                {
                    bCopy.DestinationTableName = "[Landinig].[CheckHeaders]";

                    SqlBulkCopyColumnMapping guestcheckid = new SqlBulkCopyColumnMapping("guestcheckid", "guestcheckid");
                    bCopy.ColumnMappings.Add(guestcheckid);

                    SqlBulkCopyColumnMapping organizationid = new SqlBulkCopyColumnMapping("organizationid", "organizationid");
                    bCopy.ColumnMappings.Add(organizationid);

                    SqlBulkCopyColumnMapping locationid = new SqlBulkCopyColumnMapping("locationid", "locationid");
                    bCopy.ColumnMappings.Add(locationid);


                    SqlBulkCopyColumnMapping revenuecenterid = new SqlBulkCopyColumnMapping("revenuecenterid", "revenuecenterid");
                    bCopy.ColumnMappings.Add(revenuecenterid);

                    SqlBulkCopyColumnMapping businessdate = new SqlBulkCopyColumnMapping("businessdate", "businessdate");
                    bCopy.ColumnMappings.Add(businessdate);

                    SqlBulkCopyColumnMapping opendatetime = new SqlBulkCopyColumnMapping("opendatetime", "opendatetime");
                    bCopy.ColumnMappings.Add(opendatetime);

                    SqlBulkCopyColumnMapping closedatetime = new SqlBulkCopyColumnMapping("closedatetime", "closedatetime");
                    bCopy.ColumnMappings.Add(closedatetime);

                    SqlBulkCopyColumnMapping checknum = new SqlBulkCopyColumnMapping("checknum", "checknum");
                    bCopy.ColumnMappings.Add(checknum);

                    SqlBulkCopyColumnMapping discounttotal = new SqlBulkCopyColumnMapping("discounttotal", "discounttotal");
                    bCopy.ColumnMappings.Add(discounttotal);

                    SqlBulkCopyColumnMapping servicechargetotal = new SqlBulkCopyColumnMapping("servicechargetotal", "servicechargetotal");
                    bCopy.ColumnMappings.Add(servicechargetotal);

                    SqlBulkCopyColumnMapping svcchargeexempttotal = new SqlBulkCopyColumnMapping("svcchargeexempttotal", "svcchargeexempttotal");
                    bCopy.ColumnMappings.Add(svcchargeexempttotal);

                    SqlBulkCopyColumnMapping taxtotal = new SqlBulkCopyColumnMapping("taxtotal", "taxtotal");
                    bCopy.ColumnMappings.Add(taxtotal);

                    SqlBulkCopyColumnMapping tax1total = new SqlBulkCopyColumnMapping("tax1total", "tax1total");
                    bCopy.ColumnMappings.Add(tax1total);

                    SqlBulkCopyColumnMapping nettaxtotal = new SqlBulkCopyColumnMapping("nettaxtotal", "nettaxtotal");
                    bCopy.ColumnMappings.Add(nettaxtotal);

                    SqlBulkCopyColumnMapping subtotal = new SqlBulkCopyColumnMapping("subtotal", "subtotal");
                    bCopy.ColumnMappings.Add(subtotal);

                    SqlBulkCopyColumnMapping checktotal = new SqlBulkCopyColumnMapping("checktotal", "checktotal");
                    bCopy.ColumnMappings.Add(checktotal);

                    SqlBulkCopyColumnMapping amountdue = new SqlBulkCopyColumnMapping("amountdue", "amountdue");
                    bCopy.ColumnMappings.Add(amountdue);

                    SqlBulkCopyColumnMapping cashFlagTF = new SqlBulkCopyColumnMapping("cashFlagTF", "cashFlagTF");
                    bCopy.ColumnMappings.Add(cashFlagTF);

                    SqlBulkCopyColumnMapping returntotal = new SqlBulkCopyColumnMapping("returntotal", "returntotal");
                    bCopy.ColumnMappings.Add(returntotal);

                    SqlBulkCopyColumnMapping ETL_ExtractTimeStamp = new SqlBulkCopyColumnMapping("ETL_ExtractTimeStamp", "ETL_ExtractTimeStamp");
                    bCopy.ColumnMappings.Add(ETL_ExtractTimeStamp);


                    bCopy.BulkCopyTimeout = 0;
                    bCopy.WriteToServer(dtNewTemp);
                    return true;
                }
                catch (Exception ex)
                {
                    LogWriter.LogWithMessage("EXCEPTION from  Bulk Copy CheckHeaders: " + ex.Message);
                    return false;
                }
            }

        }
        private static bool WriteCheckDetailsToDatabase(DataTable dtNewTemp)
        {
            using (SqlBulkCopy bCopy = new SqlBulkCopy((ConfigurationManager.ConnectionStrings["ConnectionDiningDb"].ToString())))
            {
                try
                {
                    bCopy.DestinationTableName = "[Landinig].[CheckDetails]";

                    SqlBulkCopyColumnMapping guestchecklineitemid = new SqlBulkCopyColumnMapping("guestchecklineitemid", "guestchecklineitemid");
                    bCopy.ColumnMappings.Add(guestchecklineitemid);

                    SqlBulkCopyColumnMapping guestcheckid = new SqlBulkCopyColumnMapping("guestcheckid", "guestcheckid");
                    bCopy.ColumnMappings.Add(guestcheckid);

                    SqlBulkCopyColumnMapping organizationid = new SqlBulkCopyColumnMapping("organizationid", "organizationid");
                    bCopy.ColumnMappings.Add(organizationid);

                    SqlBulkCopyColumnMapping locationid = new SqlBulkCopyColumnMapping("locationid", "locationid");
                    bCopy.ColumnMappings.Add(locationid);

                    SqlBulkCopyColumnMapping revenuecenterid = new SqlBulkCopyColumnMapping("revenuecenterid", "revenuecenterid");
                    bCopy.ColumnMappings.Add(revenuecenterid);

                    SqlBulkCopyColumnMapping ordertypeid = new SqlBulkCopyColumnMapping("ordertypeid", "ordertypeid");
                    bCopy.ColumnMappings.Add(ordertypeid);

                    SqlBulkCopyColumnMapping businessdate = new SqlBulkCopyColumnMapping("businessdate", "businessdate");
                    bCopy.ColumnMappings.Add(businessdate);

                    SqlBulkCopyColumnMapping transdatetime = new SqlBulkCopyColumnMapping("transdatetime", "transdatetime");
                    bCopy.ColumnMappings.Add(transdatetime);

                    SqlBulkCopyColumnMapping daypartid = new SqlBulkCopyColumnMapping("daypartid", "daypartid");
                    bCopy.ColumnMappings.Add(daypartid);

                    SqlBulkCopyColumnMapping fixedperiod = new SqlBulkCopyColumnMapping("fixedperiod", "fixedperiod");
                    bCopy.ColumnMappings.Add(fixedperiod);

                    SqlBulkCopyColumnMapping uwsid = new SqlBulkCopyColumnMapping("uwsid", "uwsid");
                    bCopy.ColumnMappings.Add(uwsid);

                    SqlBulkCopyColumnMapping checkEmpName = new SqlBulkCopyColumnMapping("checkEmpName", "checkEmpName");
                    bCopy.ColumnMappings.Add(checkEmpName);

                    SqlBulkCopyColumnMapping checkEmpNumber = new SqlBulkCopyColumnMapping("checkEmpNumber", "checkEmpNumber");
                    bCopy.ColumnMappings.Add(checkEmpNumber);

                    SqlBulkCopyColumnMapping transactionType = new SqlBulkCopyColumnMapping("transactionType", "transactionType");
                    bCopy.ColumnMappings.Add(transactionType);

                    SqlBulkCopyColumnMapping linenum = new SqlBulkCopyColumnMapping("linenum", "linenum");
                    bCopy.ColumnMappings.Add(linenum);

                    SqlBulkCopyColumnMapping linecount = new SqlBulkCopyColumnMapping("linecount", "linecount");
                    bCopy.ColumnMappings.Add(linecount);

                    SqlBulkCopyColumnMapping linetotal = new SqlBulkCopyColumnMapping("linetotal", "linetotal");
                    bCopy.ColumnMappings.Add(linetotal);

                    SqlBulkCopyColumnMapping itemName = new SqlBulkCopyColumnMapping("itemName", "itemName");
                    bCopy.ColumnMappings.Add(itemName);

                    SqlBulkCopyColumnMapping itemNumber = new SqlBulkCopyColumnMapping("itemNumber", "itemNumber");
                    bCopy.ColumnMappings.Add(itemNumber);

                    SqlBulkCopyColumnMapping familyGroupName = new SqlBulkCopyColumnMapping("familyGroupName", "familyGroupName");
                    bCopy.ColumnMappings.Add(familyGroupName);

                    SqlBulkCopyColumnMapping majorGroupName = new SqlBulkCopyColumnMapping("majorGroupName", "majorGroupName");
                    bCopy.ColumnMappings.Add(majorGroupName);

                    SqlBulkCopyColumnMapping pricelevel = new SqlBulkCopyColumnMapping("pricelevel", "pricelevel");
                    bCopy.ColumnMappings.Add(pricelevel);

                    SqlBulkCopyColumnMapping costtotal = new SqlBulkCopyColumnMapping("costtotal", "costtotal");
                    bCopy.ColumnMappings.Add(costtotal);

                    SqlBulkCopyColumnMapping discountName = new SqlBulkCopyColumnMapping("discountName", "discountName");
                    bCopy.ColumnMappings.Add(discountName);

                    SqlBulkCopyColumnMapping discountNumber = new SqlBulkCopyColumnMapping("discountNumber", "discountNumber");
                    bCopy.ColumnMappings.Add(discountNumber);

                    SqlBulkCopyColumnMapping serviceChargeName = new SqlBulkCopyColumnMapping("serviceChargeName", "serviceChargeName");
                    bCopy.ColumnMappings.Add(serviceChargeName);

                    SqlBulkCopyColumnMapping serviceChargeNumber = new SqlBulkCopyColumnMapping("serviceChargeNumber", "serviceChargeNumber");
                    bCopy.ColumnMappings.Add(serviceChargeNumber);

                    SqlBulkCopyColumnMapping taxexemptref = new SqlBulkCopyColumnMapping("taxexemptref", "taxexemptref");
                    bCopy.ColumnMappings.Add(taxexemptref);

                    SqlBulkCopyColumnMapping activetaxes = new SqlBulkCopyColumnMapping("activetaxes", "activetaxes");
                    bCopy.ColumnMappings.Add(activetaxes);

                    SqlBulkCopyColumnMapping reportincltaxtotal = new SqlBulkCopyColumnMapping("reportincltaxtotal", "reportincltaxtotal");
                    bCopy.ColumnMappings.Add(reportincltaxtotal);

                    SqlBulkCopyColumnMapping tax1total = new SqlBulkCopyColumnMapping("tax1total", "tax1total");
                    bCopy.ColumnMappings.Add(tax1total);

                    SqlBulkCopyColumnMapping tax2total = new SqlBulkCopyColumnMapping("tax2total", "tax2total");
                    bCopy.ColumnMappings.Add(tax2total);

                    SqlBulkCopyColumnMapping tax3total = new SqlBulkCopyColumnMapping("tax3total", "tax3total");
                    bCopy.ColumnMappings.Add(tax3total);

                    SqlBulkCopyColumnMapping tenderName = new SqlBulkCopyColumnMapping("tenderName", "tenderName");
                    bCopy.ColumnMappings.Add(tenderName);

                    SqlBulkCopyColumnMapping tenderNumber = new SqlBulkCopyColumnMapping("tenderNumber", "tenderNumber");
                    bCopy.ColumnMappings.Add(tenderNumber);

                    SqlBulkCopyColumnMapping voidFlagTF = new SqlBulkCopyColumnMapping("voidFlagTF", "voidFlagTF");
                    bCopy.ColumnMappings.Add(voidFlagTF);

                    SqlBulkCopyColumnMapping returnFlagTF = new SqlBulkCopyColumnMapping("returnFlagTF", "returnFlagTF");
                    bCopy.ColumnMappings.Add(returnFlagTF);

                    SqlBulkCopyColumnMapping reasonName = new SqlBulkCopyColumnMapping("reasonName", "reasonName");
                    bCopy.ColumnMappings.Add(reasonName);

                    SqlBulkCopyColumnMapping reasonCode = new SqlBulkCopyColumnMapping("reasonCode", "reasonCode");
                    bCopy.ColumnMappings.Add(reasonCode);

                    SqlBulkCopyColumnMapping ETL_ExtractTimeStamp = new SqlBulkCopyColumnMapping("ETL_ExtractTimeStamp", "ETL_ExtractTimeStamp");
                    bCopy.ColumnMappings.Add(ETL_ExtractTimeStamp);



                    bCopy.BulkCopyTimeout = 0;
                    bCopy.WriteToServer(dtNewTemp);
                    return true;
                }
                catch (Exception ex)
                {
                    LogWriter.LogWithMessage("EXCEPTION from  Bulk Copy CheckHeaders: " + ex.Message);
                    return false;
                }
            }
        }
        private static DataTable GetNewDataTableCheckDetails()
        {
            DataTable dtNewTemp = new DataTable();
            dtNewTemp.Columns.Add("guestchecklineitemid", typeof(int));
            dtNewTemp.Columns.Add("guestcheckid", typeof(int));

            dtNewTemp.Columns.Add("organizationid", typeof(int));
            dtNewTemp.Columns.Add("locationid", typeof(int));
            dtNewTemp.Columns.Add("revenuecenterid", typeof(int));
            dtNewTemp.Columns.Add("ordertypeid", typeof(int));


            dtNewTemp.Columns.Add("businessdate", typeof(DateTime));//6

            dtNewTemp.Columns.Add("transdatetime", typeof(DateTime));
            dtNewTemp.Columns.Add("daypartid", typeof(int)); //7
            dtNewTemp.Columns.Add("fixedperiod", typeof(int)); //8
            dtNewTemp.Columns.Add("uwsid", typeof(int)); //9
            dtNewTemp.Columns.Add("checkEmpName", typeof(string)); //10
            dtNewTemp.Columns.Add("checkEmpNumber", typeof(int)); //11
            dtNewTemp.Columns.Add("transactionType", typeof(string)); //12
            dtNewTemp.Columns.Add("linenum", typeof(int)); //13
            dtNewTemp.Columns.Add("linecount", typeof(int)); //14
            dtNewTemp.Columns.Add("linetotal", typeof(double)); //15
            dtNewTemp.Columns.Add("itemName", typeof(string)); //16
            dtNewTemp.Columns.Add("itemNumber", typeof(int)); //17            
            dtNewTemp.Columns.Add("familyGroupName", typeof(string)); //18
            dtNewTemp.Columns.Add("majorGroupName", typeof(string)); //18
            dtNewTemp.Columns.Add("pricelevel", typeof(int)); //18
            dtNewTemp.Columns.Add("costtotal", typeof(double)); //18
            dtNewTemp.Columns.Add("discountName", typeof(string)); //18
            dtNewTemp.Columns.Add("discountNumber", typeof(int)); //18
            dtNewTemp.Columns.Add("serviceChargeName", typeof(string)); //18
            dtNewTemp.Columns.Add("serviceChargeNumber", typeof(int)); //18
            dtNewTemp.Columns.Add("taxexemptref", typeof(string)); //18
            dtNewTemp.Columns.Add("activetaxes", typeof(int)); //18
            dtNewTemp.Columns.Add("reportincltaxtotal", typeof(double)); //18
            dtNewTemp.Columns.Add("tax1total", typeof(double)); //18
            dtNewTemp.Columns.Add("tax2total", typeof(double)); //18
            dtNewTemp.Columns.Add("tax3total", typeof(double)); //18
            dtNewTemp.Columns.Add("tenderName", typeof(string)); //18
            dtNewTemp.Columns.Add("tenderNumber", typeof(int)); //18
            dtNewTemp.Columns.Add("voidFlagTF", typeof(bool)); //18
            dtNewTemp.Columns.Add("returnFlagTF", typeof(bool)); //18
            dtNewTemp.Columns.Add("reasonName", typeof(string)); //18
            dtNewTemp.Columns.Add("reasonCode", typeof(string)); //18
            dtNewTemp.Columns.Add("ETL_ExtractTimeStamp", typeof(DateTime)); //18

            return dtNewTemp;
            
        }
        private static DataTable GetNewDataTable()
        {
            DataTable dtNewTemp = new DataTable();
            dtNewTemp.Columns.Add("guestcheckid", typeof(int));
            dtNewTemp.Columns.Add("organizationid", typeof(int));

            dtNewTemp.Columns.Add("locationid", typeof(int));
            dtNewTemp.Columns.Add("revenuecenterid", typeof(int));
            dtNewTemp.Columns.Add("businessdate", typeof(DateTime));
            dtNewTemp.Columns.Add("opendatetime", typeof(DateTime));


            dtNewTemp.Columns.Add("closedatetime", typeof(DateTime));//6

            dtNewTemp.Columns.Add("checknum", typeof(string));
            dtNewTemp.Columns.Add("discounttotal", typeof(double)); //7
            dtNewTemp.Columns.Add("servicechargetotal", typeof(double)); //8
            dtNewTemp.Columns.Add("svcchargeexempttotal", typeof(double)); //9
            dtNewTemp.Columns.Add("taxtotal", typeof(double)); //10
            dtNewTemp.Columns.Add("tax1total", typeof(double)); //11
            dtNewTemp.Columns.Add("nettaxtotal", typeof(double)); //12
            dtNewTemp.Columns.Add("subtotal", typeof(double)); //13
            dtNewTemp.Columns.Add("checktotal", typeof(double)); //14
            dtNewTemp.Columns.Add("amountdue", typeof(double)); //15
            dtNewTemp.Columns.Add("cashFlagTF", typeof(bool)); //16
            dtNewTemp.Columns.Add("returntotal", typeof(double)); //17
            dtNewTemp.Columns.Add("ETL_ExtractTimeStamp", typeof(DateTime)); //18

            return dtNewTemp;
        }

    }
}
