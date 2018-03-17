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
            SomeLogger(DateTime.Now, eventId, eventName, businessData);
        }

        public void BusinessSuccess(int eventId, string eventName, object businessData = null)
        {
            SomeLogger(DateTime.Now, eventId, eventName, businessData);
        }

        public void PublishException(Exception exception)
        {
            SomeLogger(DateTime.Now, exception.Message, exception.StackTrace);
        }

        public void PublishException(Exception exception, object data)
        {
            SomeLogger(DateTime.Now, exception.Message, exception.StackTrace, data);
        }

        private void SomeLogger(DateTime dateTime, int eventId, string eventName, object businessData) { }
        private void SomeLogger(DateTime dateTime, string message, string startTrace) { }
        private void SomeLogger(DateTime dateTime, string message, string startTrace, object data) { }
    }
}
