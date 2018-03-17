using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Model.Entities
{
    /// <summary>
    /// Position of the turtle
    /// </summary>
    public class Position : Coordinate, IValidation
    {
        /// <summary>
        /// Direction in the position
        /// </summary>
        public Directions Direction { get; set; }

        /// <summary>
        /// Entity validation
        /// </summary>
        public void Valiadte()
        {
            base.Validate();
        }

        /// <summary>
        /// Position equality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var c = obj as Position;
            if (c != null)
            {
                return c.X == X && c.Y == Y && c.Direction == Direction;
            }
            return false;
        }
    }
}
