using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class LoggerHelper
    {

        public LoggerHelper()
        {
            log4net.Config.XmlConfigurator.Configure();

        }


        public static log4net.ILog Log { get; set; }
        public ILog log = log4net.LogManager.GetLogger(typeof(LoggerHelper));

        public string name = ConfigurationManager.AppSettings["DataBaseToConnect"];

        public void LogError(string msg)
        {
            log.Error(msg);
        }

        public void LogWarn(string msg)
        {
            log.Warn(msg);
        }
        public void LogInfo(string msg)
        {
            log.Info(msg);
        }
    }
}
