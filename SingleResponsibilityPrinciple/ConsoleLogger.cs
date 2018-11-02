using System;
using System.IO;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            LogToFile("WARN", message);
            Console.WriteLine(string.Concat("WARN: ", message), args);
        }

        public void LogInfo(string message, params object[] args)
        {
            LogToFile("INFO", message);
            Console.WriteLine(string.Concat("INFO: ", message), args);
        }

        public void LogToFile(string message, string messageType)
        {
            using (StreamWriter logger = File.AppendText("log.xml"))
            {
                logger.WriteLine("<log><type>" + messageType + "</type><message>" + message + "</message></log>");
            }
        }
    }
}
