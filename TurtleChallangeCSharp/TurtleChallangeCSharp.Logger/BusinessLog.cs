using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logger.Interface;

namespace TurtleChallangeCSharp.Logger
{
    public class BusinessLog : ILogger
    {
        public void BusinessFail(int eventId, string eventName, object businessData = null)
        {
            LoggerFramework(DateTime.Now, eventId, eventName, businessData);
        }

        public void BusinessSuccess(int eventId, string eventName, object businessData = null)
        {
            LoggerFramework(DateTime.Now, eventId, eventName, businessData);
        }
        
        public void PublishException(Exception exception, object data = null)
        {
            LoggerFramework(DateTime.Now, exception.Message, exception.StackTrace, data);
        }

        private void LoggerFramework(DateTime dateTime, int eventId, string eventName, object businessData) { }
        private void LoggerFramework(DateTime dateTime, string message, string startTrace) { }
        private void LoggerFramework(DateTime dateTime, string message, string startTrace, object data) { }
    }
}
