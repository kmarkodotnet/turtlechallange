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
    public class StateHelper
    {
        internal static bool IsInMine(List<Coordinate> mines, Position position)
        {
            return mines.Any(m => m.X == position.X && m.Y == position.Y);
        }
        
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
