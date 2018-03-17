using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Logger.Interface
{
    public interface ILogger
    {
        void BusinessSuccess(int eventId, string eventName, object businessData = null);
        void BusinessFail(int eventId, string eventName, object businessData = null);
        void PublishException(Exception exception);
        void PublishException(Exception exception, object data);
    }
}
