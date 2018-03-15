using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class Result
    {

    }

    public class GameResult : Result
    {
        public string ResultString { get; set; }
    }

    public class ErrorResult : Result
    {
        public string ErrorMessage { get; set; }
    }

    public class GameResults : List<Result> { }
}
