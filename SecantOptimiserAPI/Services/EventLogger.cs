using System.Text;

namespace SecantOptimiserAPI.Services
{
    public class EventLogger
    {
        internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e != null)
            {
                Exception exp = (Exception)e.ExceptionObject;
                WriteLog(exp);
            }
        }



        internal static void CurrentDomain_FirstChanceException(object? sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            WriteLog(e.Exception);
        }



        internal static void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            foreach (var exp in e.Exception.InnerExceptions)
            {
                WriteLog(exp);
            }
        }

        static void WriteLog(Exception exp)
        {
            try
            {
                StringBuilder builder1 = new StringBuilder();
                if (exp != null)
                {
                    builder1.AppendLine(exp.Message);
                    Exception? innerExp = exp.InnerException;
                    while (innerExp != null)
                    {
                        builder1.AppendLine(innerExp.Message);
                        innerExp = innerExp.InnerException;
                    }
                    using (System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog("Application"))
                    {
                        eventLog.Source = "Application";
                        eventLog.WriteEntry(builder1.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            catch { }
        }
    }
}
