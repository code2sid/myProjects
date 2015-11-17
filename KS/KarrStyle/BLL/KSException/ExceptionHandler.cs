using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace KarrStyle.BLL.KSException
{
    public static class ExceptionHandler
    {
        #region Handle Exception (static)

        public static void HandleException(System.Exception e, string source, KarrStyleException.ExceptionLevel level= KarrStyleException.ExceptionLevel.None)
        {
            switch (level)
            {
                case KarrStyleException.ExceptionLevel.System:
                    WriteToLogFile(e, source, level);
                    WriteToEventLog(e, source, level);
                   KarrStyleLog.SendEmail(e, level.ToString() + " in " + source);
                    break;
                case KarrStyleException.ExceptionLevel.Critical:
                    WriteToLogFile(e, source, level);
                    WriteToEventLog(e, source, level);
                   KarrStyleLog.SendEmail(e, level.ToString() + " in " + source);
                    break;
                case KarrStyleException.ExceptionLevel.Error:
                    WriteToLogFile(e, source, level);
                    break;
                case KarrStyleException.ExceptionLevel.Information:
                    WriteToLogFile(e, source, level);
                    break;
                case KarrStyleException.ExceptionLevel.Warning:
                    WriteToLogFile(e, source, level);
                    break;
                default:
                    WriteToLogFile(e, source, level);
                    break;
            }
        }

        public static void HandleException(KarrStyleException e, string source)
        {
            HandleException(e, source, e.Level);
        }

        public static void HandleException(string userFriendlyMsg, string source, KarrStyleException.ExceptionLevel level = KarrStyleException.ExceptionLevel.Warning)
        {
            KarrStyleException e = null;

            string sTrace = null;
            StackTrace st;
            StackFrame sf;
            MethodBase mb;

            try
            {
                //Get the calling method name
                st = new StackTrace();

                for (int frameCount = 0; frameCount < st.FrameCount; frameCount++)
                {
                    sf = st.GetFrame(frameCount);
                    mb = sf.GetMethod();
                    sTrace = sTrace + "\r\n" + string.Format("{0}.{1}", mb.DeclaringType.FullName, mb.Name);
                }
            }
            catch
            {
                KarrStyleLog.WriteToEventViewer("There was an error reading the stack trace.\r\nThe real error is\r\n" +
                                            userFriendlyMsg, EventLogEntryType.Error, source);
            }
            finally
            {
                mb = null;
                sf = null;
                st = null;
            }

            e = new KarrStyleException(userFriendlyMsg, userFriendlyMsg + "\r\n" + sTrace, level);
            HandleException(e, source);

            e = null;
        }
        #endregion

        #region Private methods to do actual write

        private static void WriteToLogFile(System.Exception e, string source, KarrStyleException.ExceptionLevel level)
        {
            KarrStyleLog.WriteToFile("Exception Level: " + level + " in " + source + "\r\n" + e.Message + "\r\n" + e.StackTrace);
        }

        private static void WriteToEventLog(System.Exception e, string source, KarrStyleException.ExceptionLevel level)
        {
            KarrStyleLog.WriteToEventViewer("Exception Level: " + level + " in " + source + "\r\n" + e.Message + "\r\n" + e.StackTrace, EventLogEntryType.Error, source);
        }
        #endregion
    }
}
