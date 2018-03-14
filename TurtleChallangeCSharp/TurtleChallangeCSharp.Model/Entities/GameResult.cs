using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class GameResult
    {
        public virtual string ResultString { get; set; }
    }

    public class GameResults : List<GameResult> { }
}
