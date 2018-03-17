using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Exceptions
{
    /// <summary>
    /// Occurs when the turtle is in an invalid position like it goes outside of the table
    /// </summary>
    public class InvalidPositionException : BusinessException
    {
        public InvalidPositionException(string reason) : base(reason)
        {
        }
    }
}
