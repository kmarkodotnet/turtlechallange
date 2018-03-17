using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Logger.Interface
{
    /// <summary>
    /// The logger for the application
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a successfull application operation
        /// </summary>
        /// <param name="eventId">The id of the event or operation</param>
        /// <param name="eventName">The name of the event or operation</param>
        /// <param name="businessData">Business data to save in the log</param>
        void BusinessSuccess(int eventId, string eventName, object businessData = null);

        /// <summary>
        /// Logs an unsuccessfull application operation
        /// </summary>
        /// <param name="eventId">The id of the event or operation</param>
        /// <param name="eventName">The name of the event or operation</param>
        /// <param name="businessData">Business data to save in the log</param>
        void BusinessFail(int eventId, string eventName, object businessData = null);

        /// <summary>
        /// Logs an exception if the operation
        /// </summary>
        /// <param name="exception">The excaption that occured</param>
        /// <param name="data">The additional data for the exception</param>
        void PublishException(Exception exception, object data = null);
    }
}
