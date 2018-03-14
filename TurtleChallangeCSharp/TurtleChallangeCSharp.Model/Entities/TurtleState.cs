using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class TurtleState
    {
        public Coordinate Position { get; set; }

        public TableConfig TableConfig { get; set; }

        public int ActualMove { get; set; }
        public MovesConfig MovesConfig { get; set; }
    }
}
