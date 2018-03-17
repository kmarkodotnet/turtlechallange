using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Exceptions
{
    public class BusinessException : BaseException
    {
        public BusinessException()
        {

        }

        public BusinessException(string message) : base(message)
        {

        }

        public BusinessException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
