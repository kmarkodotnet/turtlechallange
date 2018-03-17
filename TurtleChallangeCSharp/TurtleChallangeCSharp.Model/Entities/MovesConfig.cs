using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;

namespace TurtleChallangeCSharp.Model.Entities
{
    /// <summary>
    /// Moves configuration
    /// </summary>
    public class MovesConfig : List<Enums.Moves>
    {
    }

    /// <summary>
    /// All moves in game
    /// </summary>
    public class MovesConfigs : List<MovesConfig> { }
}
