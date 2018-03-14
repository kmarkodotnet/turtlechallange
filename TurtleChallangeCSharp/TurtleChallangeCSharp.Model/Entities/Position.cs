using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class Position : Coordinate
    {
        public Directions Direction { get; set; }
    }
}
