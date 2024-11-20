using NLog;
using PersonalFinance.Service.Interfaces.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Services.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {

        }
        public void LogDebug(string message)
        {
            logger.Debug("DEBUG--" + message);
        }

        public void LogError(string message)
        {
            logger.Error("ERROR--" + message);
        }

        public void LogInfo(string message)
        {
            logger.Info("INFO--" + message);
        }

        public void LogWarn(string message)
        {
            logger.Warn("WARNING--" + message);
        }
    }
}
