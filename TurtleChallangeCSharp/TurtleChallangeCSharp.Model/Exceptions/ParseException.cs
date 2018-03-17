using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Exceptions
{
    public class ParseException : BaseException
    {
        public object ParseData { get; set; }

        public ParseException()
        {

        }

        public ParseException(string message) : base(message)
        {
            
        }

        public ParseException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
