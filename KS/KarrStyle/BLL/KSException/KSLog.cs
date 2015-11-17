using System;
using System.Text;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace KarrStyle.BLL.KSException
{
    public static class KarrStyleLog
    {
        #region Write Log Public methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="componentName"></param>
        /// <param name="logDetail"></param>
        public static void WriteToFile(string logDetail, string source = "")
        {
            StreamWriter strWriter = null;
            String filePath = string.Empty;
            string username = string.Empty;

            try
            {
                //FilePath can be blank if the calling application does not have access to
                //configuration file, in that case we will write to event log
                filePath = CleanAndFormat.CleanText(ConfigurationManager.AppSettings["NYRR.LogFilesFolder"]);

                if (filePath.Length > 0)
                {
                    filePath = filePath + "\\Log" + System.DateTime.Today.ToString("yyyy-MM-dd") +
                                        ".txt";

                    //There is a filePath so check if it exists
                    if (!File.Exists(filePath))
                    {
                        strWriter = File.CreateText(filePath);
                    }
                    else
                    {
                        strWriter = File.AppendText(filePath);
                    }
                    strWriter.WriteLine(DateTime.Now.ToString() + "-->" + logDetail);
                }
                else
                {
                    //This means that the calling application does not have access to the web.config
                    WriteToEventViewer("There was an error writing to the log file.\r\nThe real error is\r\n" +
                                            logDetail, EventLogEntryType.Error, source);
                }
            }
            catch (Exception ex){
                WriteToEventViewer("There was an error writing to the log file.\r\n" + ex.Message +
                                    "\r\n\r\n" + ex.StackTrace + "\r\n\r\nThe real error is\r\n" +
                                    logDetail, EventLogEntryType.Error, source);
            }
            finally
            {
                if (strWriter != null)
                {
                    strWriter.Flush();
                    strWriter.Close();
                }
            }
        }

        public static void WriteToEventViewer(string sMessage, EventLogEntryType nLogEntryType, string sSource = "NYRR Online Site")
        {
            EventLog nyrrEventLog = null;

            try
            {
                nyrrEventLog = new EventLog();

                nyrrEventLog.Source = sSource;
                nyrrEventLog.WriteEntry(sMessage, nLogEntryType);
            }
            catch { }
            finally
            {
                nyrrEventLog = null;
            }
        }

        public static void LogTrace(string logDetail)
        {
            if (CleanAndFormat.CleanText(ConfigurationManager.AppSettings["EnableTrace"]).ToUpper() == "TRUE")
            {
                WriteToFile(logDetail);
            }
        }

        public static void SendEmail(System.Exception e, string subject = "Critical Error in NYRR Online Site")
        {
            Email emailObject = null;

            string from = string.Empty;
            string to = string.Empty;
            string body = string.Empty;

            try
            {
                to = CleanAndFormat.CleanText(ConfigurationManager.AppSettings["MightyMilers.NotificationAlert.ToAddress"]);
                body = e.Message + e.StackTrace;
               // body = e.Message ;
                

                emailObject = new Email();

                emailObject.SendMail(to, "", subject, body, false);
            }
            catch (Exception ex)
            {
                WriteToEventViewer("Error sending email " + ex.Message + "\r\n\r\n" + "The real error is \r\n\r\n" + body, EventLogEntryType.Error);
            }
            finally
            {
                emailObject = null;
            }
        }
        #endregion
    }
}
