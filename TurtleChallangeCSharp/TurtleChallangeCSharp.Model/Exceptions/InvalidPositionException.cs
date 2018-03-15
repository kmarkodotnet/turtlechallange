using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Exceptions
{
    public class InvalidPositionException : BusinessException
    {
        public InvalidPositionException(string reason) : base(reason)
        {
        }
    }
}
