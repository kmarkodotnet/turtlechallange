using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Entities
{
    /// <summary>
    /// Basic result class of the game
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
    /// All results of the game 
    /// </summary>
    public class GameResults : List<Result> { }
}
