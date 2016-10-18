using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra.VMI.Report.Logging
{
    public class FileLogger
    {
        private static object _lockObject = new object();

        public static void WriteLog(string logContent, string logName)
        {
            lock (_lockObject)
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\log\\" + DateTime.Now.ToString("yyyyMMdd") + "\\";
                if (!Directory.Exists(filepath))
                    Directory.CreateDirectory(filepath);

                string logFile = filepath + logName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                try
                {
                    using (StreamWriter sw = File.AppendText(logFile))
                    {
                        sw.WriteLine("=====================" + DateTime.Now.ToString() + "==================\r\n");
                        sw.WriteLine(logContent + "\r");
                    }
                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = File.AppendText(logFile))
                    {
                        sw.WriteLine("=====================" + DateTime.Now.ToString() + "==================\r\n");
                        sw.WriteLine(ex.Message + "\r");
                    }
                }
            }
        }

        public static void WriteLog(Exception ex, string logName)
        {
            if (ex.InnerException != null)
                WriteLog(ex.InnerException.Message, logName);
            else
                WriteLog(ex.Message, logName);
        }

        /// <summary>
        /// 日志保存在指定的子目录中
        /// </summary>
        /// <param name="partner"></param>
        /// <param name="msg"></param>
        /// <param name="logName"></param>
        public static void WriteLog(string partner, string msg, string logName)
        {
            lock (_lockObject)
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\log\\" + partner + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\";
                if (!Directory.Exists(filepath))
                    Directory.CreateDirectory(filepath);

                string logFile = filepath + logName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                try
                {
                    using (StreamWriter sw = File.AppendText(logFile))
                    {
                        sw.WriteLine("=====================" + DateTime.Now.ToString() + "==================\r\n");
                        sw.WriteLine(msg + "\r");
                    }
                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = File.AppendText(logFile))
                    {
                        sw.WriteLine("=====================" + DateTime.Now.ToString() + "==================\r\n");
                        sw.WriteLine(ex.Message + "\r");
                    }
                }
            }
        }

        /// <summary>
        /// 日志保存在指定的子目录中
        /// </summary>
        /// <param name="partner"></param>
        /// <param name="msg"></param>
        /// <param name="logName"></param>
        public static void WriteLog(string partner, Exception ex, string logName)
        {
            if (ex.InnerException != null)
                WriteLog(partner, ex.InnerException.Message, logName);
            else
                WriteLog(partner, ex.Message, logName);
        }
    }
}
