using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Entities
{
    /// <summary>
    /// Result 
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Result as a string
        /// </summary>
        public string ResultString { get; set; }
    }

    /// <summary>
    /// Successfull game result without error
    /// </summary>
    public class GameResult : Result { }

    /// <summary>
    /// Unsuccessfull game result with error
    /// </summary>
    public class ErrorResult : Result { }

    /// <summary>
    /// Game all results
    /// </summary>
    public class GameResults : List<Result> { }
}
