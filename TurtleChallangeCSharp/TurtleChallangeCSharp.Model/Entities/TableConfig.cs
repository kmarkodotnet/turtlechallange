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
    /// Configuration of the table
    /// </summary>
    public class TableConfig: IValidation
    {
        /// <summary>
        /// Table size X
        /// </summary>
        public int SizeX { get; set; }
        /// <summary>
        /// Table size Y
        /// </summary>
        public int SizeY { get; set; }

        /// <summary>
        /// Start position of the turtle
        /// </summary>
        public Position StartPosition { get; set; }

        /// <summary>
        /// Exit point on the table
        /// </summary>
        public Coordinate Exit { get; set; }

        /// <summary>
        /// Mines on the table
        /// </summary>
        public List<Coordinate> Mines { get; set; }

        public TableConfig()
        {
            Mines = new List<Coordinate>();
        }

        /// <summary>
        /// Entity validation
        /// </summary>
        public void Validate()
        {
            if (StartPosition == null || Exit == null || Mines == null || SizeX  < 1 || SizeY < 1)
            {
                throw new BusinessException("Table configuration is invalid");
            }

            StartPosition.Valiadte();
            Exit.Validate();
            Mines.ForEach(m => m.Validate());

            if (StartPosition.X >= SizeX || StartPosition.Y >= SizeY || Mines.Any(m => m.X >= SizeX || m.Y >= SizeY) || Exit.X >= SizeX || Exit.Y >= SizeY)
            {
                throw new InvalidPositionException("Coordinate values cannot be higher than table size");
            }
        }
    }
}
