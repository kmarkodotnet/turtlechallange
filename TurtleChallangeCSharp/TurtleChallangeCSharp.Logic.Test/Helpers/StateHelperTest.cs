using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallangeCSharp.Logic.Helpers;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic.Test.Helpers
{
    [TestClass]
    public class StateHelperTest
    {
        [TestMethod]
        public void IsInMineTest()
        {
            var mines = new List<Coordinate>() { new Coordinate { X = 1, Y = 1 }, new Coordinate { X = 0, Y = 1 }, new Coordinate { X = 1, Y = 0 } };
            var pos = new Position { X = 0, Y = 0 };
            Assert.IsFalse(StateHelper.IsInMine(mines, pos));
            mines.Add(new Coordinate { X = 0, Y = 0 });
            Assert.IsTrue(StateHelper.IsInMine(mines, pos));
        }

        [TestMethod]
        public void TurnTest()
        {
            var actualMove = Moves.M;
            var actualPosition = new Position { X = 0, Y = 0, Direction = Directions.N };
            Assert.ThrowsException<BusinessException>(() => StateHelper.Turn(actualMove, actualPosition));

            actualMove = Moves.R;
            Assert.IsTrue(StateHelper.Turn(actualMove, actualPosition).Direction == Directions.E);

            actualMove = Moves.L;
            Assert.IsTrue(StateHelper.Turn(actualMove, StateHelper.Turn(actualMove, StateHelper.Turn(actualMove, StateHelper.Turn(actualMove, actualPosition)))).Direction == Directions.N);
        }

        [TestMethod]
        public void GetStateTest()
        {
            var mines = new List<Coordinate>() { new Coordinate { X = 1, Y = 1 }, new Coordinate { X = 0, Y = 1 }, new Coordinate { X = 1, Y = 0 } };
            var exit = new Coordinate { X = 0, Y = 0 };
            var pos = new Position { X = 0, Y = 0 };
            Assert.IsTrue(StateHelper.GetState(pos, mines, exit) == State.Success);

            pos = new Position { X = 0, Y = 1 };
            Assert.IsTrue(StateHelper.GetState(pos, mines, exit) == State.MineHit);

            pos = new Position { X = 2, Y = 2 };
            Assert.IsTrue(StateHelper.GetState(pos, mines, exit) == State.StillInDander);
        }

        [TestMethod]
        public void MoveInDirectionTest()
        {
            var pos = new Position { X = 0, Y = 0, Direction = Directions.E };
            Assert.IsTrue(StateHelper.MoveInDirection(pos).X == pos.X + 1);

            pos = new Position { X = 0, Y = 0, Direction = Directions.W };
            Assert.IsTrue(StateHelper.MoveInDirection(pos).X == pos.X - 1);

            pos = new Position { X = 0, Y = 0, Direction = Directions.N };
            Assert.IsTrue(StateHelper.MoveInDirection(pos).Y == pos.Y - 1);

            pos = new Position { X = 0, Y = 0, Direction = Directions.S };
            Assert.IsTrue(StateHelper.MoveInDirection(pos).Y == pos.Y + 1);
        }

        [TestMethod]
        public void GetNewPositionTest()
        {
            var actualMove = Moves.M;
            var actualPosition = new Position { X = 0, Y = 0, Direction = Directions.N };
            
            var newPos1 = StateHelper.GetNewPosition(actualMove, actualPosition);
            var newPos2 = StateHelper.MoveInDirection(actualPosition);
            Assert.AreEqual(newPos1,newPos2);

            actualMove = Moves.L;
            actualPosition = new Position { X = 0, Y = 0, Direction = Directions.N };
            newPos1 = StateHelper.GetNewPosition(actualMove, actualPosition);
            newPos2 = StateHelper.MoveInDirection(actualPosition);
            Assert.AreNotEqual(newPos1, newPos2);

            newPos1 = StateHelper.GetNewPosition(actualMove, actualPosition);
            newPos2 = StateHelper.Turn(actualMove, actualPosition);
            Assert.AreEqual(newPos1, newPos2);
        }
    }
}
