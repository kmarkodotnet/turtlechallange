using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class MovesConfig
    {
        public MovesConfig()
        {
            Moves = new List<Enums.Moves>();
        }
        public List<Moves> Moves { get; set; }
    }

    public class MovesConfigs : List<MovesConfig> { }
}
