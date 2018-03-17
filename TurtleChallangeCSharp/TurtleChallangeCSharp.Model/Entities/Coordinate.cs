using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class Coordinate : IValidation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Validate()
        {
            if (X < 0 || Y < 0)
            {
                throw new InvalidPositionException("Coordinate values cannot be less than zero");
            }
        }

        public override bool Equals(object obj)
        {
            var c = obj as Coordinate;
            if (c != null)
            {
                return c.X == X && c.Y == Y;
            }
            return false;
        }
    }
}
