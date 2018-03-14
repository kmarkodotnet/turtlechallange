using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class Position : Coordinate, IValidation
    {
        public Directions Direction { get; set; }

        public void Valiadte()
        {

        }
    }
}
