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
    public class TurtleState: IValidation
    {
        public Position Position { get; set; }

        public TableConfig TableConfig { get; set; }

        public int ActualMove { get; set; }
        public Moves[] Moves { get; set; }

        public State State { get; set; }

        public void Validate()
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

        public void FullValidate()
        {
            TableConfig.Validate();
            Validate();
        }
    }
}
