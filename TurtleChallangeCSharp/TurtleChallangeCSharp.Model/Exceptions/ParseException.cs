using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Exceptions
{
    /// <summary>
    /// Exception when there are pasing problems
    /// </summary>
    public class ParseException : Exception
    {
        /// <summary>
        /// The problematic data regarding to the excpetion
        /// </summary>
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
