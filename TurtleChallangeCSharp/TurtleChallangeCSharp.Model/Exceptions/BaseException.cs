using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Exceptions
{
    public class BaseException : Exception
    {
        public string Reason { get; set; }
        public new Exception InnerException { get; set; }
    }
}
