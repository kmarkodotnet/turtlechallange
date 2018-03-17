using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic.Helpers
{
    /// <summary>
    /// State functions
    /// </summary>
    public class StateHelper
    {
        /// <summary>
        /// Is the turtle in a mine?
        /// </summary>
        /// <param name="mines">Mines</param>
        /// <param name="position">Turtle position</param>
        /// <returns></returns>
        internal static bool IsInMine(List<Coordinate> mines, Position position)
        {
            return mines.Any(m => m.X == position.X && m.Y == position.Y);
        }
        
        /// <summary>
        /// Calcualtes the new position of the turtle after a move
        /// </summary>
        /// <param name="actualMove">The next move</param>
        /// <param name="actualPosition">The actual position of the turtle</param>
        /// <returns></returns>
        internal static Position GetNewPosition(Moves actualMove, Position actualPosition)
        {
            if (actualMove == Moves.M)
            {
                return MoveInDirection(actualPosition);
            }
            else
            {
                return Turn(actualMove, actualPosition);
            }
        }

        /// <summary>
        /// Makes a turn move on the turtle
        /// </summary>
        /// <param name="actualMove">The direction of the turl</param>
        /// <param name="actualPosition">The actual position of the turtle</param>
        /// <returns></returns>
        internal static Position Turn(Moves actualMove, Position actualPosition)
        {
            if (actualMove == Moves.M)
            {
                throw new BusinessException(string.Format("Invalid operation: '{0}' is not a turn", actualMove));
            }
            var newPosition = new Position { X = actualPosition.X, Y = actualPosition.Y };
            var op = actualMove == Moves.L ? -1 : 1;
            var x = ((int)actualPosition.Direction) + op;
            var newDir = (Math.Abs(x * 4) + x) % 4;
            newPosition.Direction = (Directions)newDir;
            return newPosition;
        }

        /// <summary>
        /// Calculates if the turtle is finishing the game in a state
        /// </summary>
        /// <param name="state">State of the turtle</param>
        /// <returns></returns>
        internal static bool FinishState(State state)
        {
            switch (state)
            {
                case State.Success:
                case State.MineHit:
                case State.Error:
                case State.LeftTable:
                    return true;
                    break;
                case State.StillInDander:
                    return false;
                    break;
                default:
                    throw new BusinessException("Impossible state");
                    break;
            }
        }

        /// <summary>
        /// Calculates the state of the turtle
        /// </summary>
        /// <param name="position">The actual position of the turtle</param>
        /// <param name="mines">The mines list</param>
        /// <param name="exit">The exit point</param>
        /// <returns></returns>
        internal static State GetState(Position position, List<Coordinate> mines, Coordinate exit)
        {
            if (IsInMine(mines, position))
            {
                return State.MineHit;
            }
            else if (position.X == exit.X && position.Y == exit.Y)
            {
                return State.Success;
            }
            else
            {
                return State.StillInDander;
            }
        }

        /// <summary>
        /// Moves the turtle in its position
        /// </summary>
        /// <param name="actualPosition">The actual position of the turtle</param>
        /// <returns></returns>
        internal static Position MoveInDirection(Position actualPosition)
        {
            var newPosition = new Position { Direction = actualPosition.Direction, X = actualPosition.X, Y = actualPosition.Y };

            switch (actualPosition.Direction)
            {
                case Directions.N:
                    newPosition.Y--;
                    break;
                case Directions.S:
                    newPosition.Y++;
                    break;
                case Directions.E:
                    newPosition.X++;
                    break;
                case Directions.W:
                    newPosition.X--;
                    break;
                default:
                    throw new BusinessException("Impossible move");
                    break;
            }
            return newPosition;
        }
    }
}
