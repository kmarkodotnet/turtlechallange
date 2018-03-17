using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Model.Entities
{
    /// <summary>
    /// Full state configuration of the game
    /// </summary>
    public class StateConfiguration: IValidation
    {
        /// <summary>
        /// Actual position iof the turtle
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Table configuration
        /// </summary>
        public TableConfig TableConfig { get; set; }

        /// <summary>
        /// The number of moves made by turtle
        /// </summary>
        public int ActualMove { get; set; }

        /// <summary>
        /// All moves
        /// </summary>
        public Moves[] Moves { get; set; }
        

        /// <summary>
        /// Validation of the actual state
        /// </summary>
        public void LightValidate()
        {
            Position.Valiadte();
            if (Position.X >= TableConfig.SizeX || Position.Y >= TableConfig.SizeY)
            {
                throw new InvalidPositionException("Coordinate values cannot be higher than table size");
            }
            if (ActualMove < 0 || ActualMove > Moves.Length)
            {
                throw new BusinessException("Turtle is in invalid state");
            }
        }

        /// <summary>
        /// Full validation of the state
        /// </summary>
        public void Validate()
        {
            TableConfig.Validate();
            LightValidate();
        }
    }
}
