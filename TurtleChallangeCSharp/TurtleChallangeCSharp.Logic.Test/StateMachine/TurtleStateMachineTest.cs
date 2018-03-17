using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallangeCSharp.Logger;
using TurtleChallangeCSharp.Logic.StateMachine;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic.Test.StateMachine
{
    [TestClass]
    public class TurtleStateMachineTest
    {
        [TestMethod]
        public void InitializeErrorTest()
        {
            var tsm = new TurtleStateMachine(new BusinessLog());
            Assert.ThrowsException<BusinessException>(() => tsm.Initialize(new Model.Entities.TableConfig { }, new Model.Entities.MovesConfig { }));

            Assert.ThrowsException<BusinessException>(() => tsm.Initialize(
                new Model.Entities.TableConfig
                {
                    SizeX = 0,
                    SizeY = 0,
                    Exit = new Model.Entities.Coordinate { Y = 0, X = 0 },
                    StartPosition = new Model.Entities.Position { X = -1, Y = -1 }
                },
                new Model.Entities.MovesConfig { }));

            Assert.ThrowsException<InvalidPositionException>(() => tsm.Initialize(
                new Model.Entities.TableConfig
                {
                    SizeX = 1,
                    SizeY = 1,
                    Exit = new Model.Entities.Coordinate { Y = 0, X = 0 },
                    StartPosition = new Model.Entities.Position { X = -1, Y = -1 }
                },
                new Model.Entities.MovesConfig { }));

            Assert.ThrowsException<InvalidPositionException>(() => tsm.Initialize(
                new Model.Entities.TableConfig
                {
                    SizeX = 1,
                    SizeY = 1,
                    Exit = new Model.Entities.Coordinate { Y = 0, X = 0 },
                    StartPosition = new Model.Entities.Position { X = 1, Y = 1 }
                },
                new Model.Entities.MovesConfig { }));

            Assert.ThrowsException<InvalidPositionException>(() => tsm.Initialize(
                new Model.Entities.TableConfig
                {
                    SizeX = 2,
                    SizeY = 2,
                    Exit = new Model.Entities.Coordinate { Y = 0, X = 0 },
                    StartPosition = new Model.Entities.Position { X = 2, Y = 2 }
                },
                new Model.Entities.MovesConfig { }));

            Assert.ThrowsException<InvalidPositionException>(() => tsm.Initialize(
                new Model.Entities.TableConfig
                {
                    SizeX = 2,
                    SizeY = 2,
                    StartPosition = new Model.Entities.Position { X = 1, Y = 1 },
                    Exit = new Model.Entities.Coordinate { X = 2, Y = 2 }
                },
                new Model.Entities.MovesConfig { }));

            Assert.ThrowsException<InvalidPositionException>(() => tsm.Initialize(
                new Model.Entities.TableConfig
                {
                    SizeX = 2,
                    SizeY = 2,
                    StartPosition = new Model.Entities.Position { X = 1, Y = 1 },
                    Exit = new Model.Entities.Coordinate { X = 1, Y = 1 },
                    Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                    {
                        new Model.Entities.Coordinate { X = -1, Y = -1 }
                    }
                },
                new Model.Entities.MovesConfig { }));

            Assert.ThrowsException<InvalidPositionException>(() => tsm.Initialize(
                new Model.Entities.TableConfig
                {
                    SizeX = 2,
                    SizeY = 2,
                    StartPosition = new Model.Entities.Position { X = 1, Y = 1 },
                    Exit = new Model.Entities.Coordinate { X = 1, Y = 1 },
                    Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                    {
                        new Model.Entities.Coordinate { X = 2, Y = 2 }
                    }
                },
                new Model.Entities.MovesConfig { }));
        }
        
        [TestMethod]
        public void PlayTest()
        {
            var tsm = new TurtleStateMachine(new BusinessLog());
            tsm.Initialize(
                   new Model.Entities.TableConfig
                   {
                       SizeX = 2,
                       SizeY = 2,
                       StartPosition = new Model.Entities.Position { X = 1, Y = 1, Direction = Model.Enums.Directions.E },
                       Exit = new Model.Entities.Coordinate { X = 1, Y = 0 },
                       Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                        {
                            new Model.Entities.Coordinate { X = 0, Y = 0 }
                        }
                   },
                   new Model.Entities.MovesConfig {  });
            Assert.AreEqual(tsm.Play(), Model.Enums.State.StillInDander);

            tsm.Initialize(
                   new Model.Entities.TableConfig
                   {
                       SizeX = 2,
                       SizeY = 2,
                       StartPosition = new Model.Entities.Position { X = 1, Y = 1, Direction = Model.Enums.Directions.E },
                       Exit = new Model.Entities.Coordinate { X = 1, Y = 0 },
                       Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                        {
                            new Model.Entities.Coordinate { X = 1, Y = 1 }
                        }
                   },
                   new Model.Entities.MovesConfig { });
            Assert.AreEqual(tsm.Play(), Model.Enums.State.MineHit);

            tsm.Initialize(
                   new Model.Entities.TableConfig
                   {
                       SizeX = 2,
                       SizeY = 2,
                       StartPosition = new Model.Entities.Position { X = 1, Y = 1, Direction = Model.Enums.Directions.E },
                       Exit = new Model.Entities.Coordinate { X = 1, Y = 0 },
                       Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                        {
                            new Model.Entities.Coordinate { X = 0, Y = 0 }
                        }
                   },
                   new Model.Entities.MovesConfig {Model.Enums.Moves.L });
            Assert.AreEqual(tsm.Play(), Model.Enums.State.StillInDander);

            tsm.Initialize(
                   new Model.Entities.TableConfig
                   {
                       SizeX = 2,
                       SizeY = 2,
                       StartPosition = new Model.Entities.Position { X = 1, Y = 1, Direction = Model.Enums.Directions.E },
                       Exit = new Model.Entities.Coordinate { X = 1, Y = 0 },
                       Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                        {
                            new Model.Entities.Coordinate { X = 0, Y = 0 }
                        }
                   },
                   new Model.Entities.MovesConfig {  Model.Enums.Moves.L, Model.Enums.Moves.M  });
            Assert.AreEqual(tsm.Play(), Model.Enums.State.Success);

            tsm.Initialize(
                   new Model.Entities.TableConfig
                   {
                       SizeX = 2,
                       SizeY = 2,
                       StartPosition = new Model.Entities.Position { X = 1, Y = 1, Direction = Model.Enums.Directions.E },
                       Exit = new Model.Entities.Coordinate { X = 1, Y = 0 },
                       Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                        {
                            new Model.Entities.Coordinate { X = 0, Y = 0 }
                        }
                   },
                   new Model.Entities.MovesConfig { Model.Enums.Moves.L, Model.Enums.Moves.M, Model.Enums.Moves.L, Model.Enums.Moves.M} );
            Assert.AreEqual(tsm.Play(), Model.Enums.State.Success);

            tsm.Initialize(
                   new Model.Entities.TableConfig
                   {
                       SizeX = 2,
                       SizeY = 2,
                       StartPosition = new Model.Entities.Position { X = 1, Y = 1, Direction = Model.Enums.Directions.E },
                       Exit = new Model.Entities.Coordinate { X = 0, Y = 0 },
                       Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                        {
                            new Model.Entities.Coordinate { X = 0, Y = 1 }
                        }
                   },
                   new Model.Entities.MovesConfig {  Model.Enums.Moves.L, Model.Enums.Moves.M, Model.Enums.Moves.L, Model.Enums.Moves.M });
            Assert.AreEqual(tsm.Play(), Model.Enums.State.Success);

            tsm.Initialize(
                   new Model.Entities.TableConfig
                   {
                       SizeX = 2,
                       SizeY = 2,
                       StartPosition = new Model.Entities.Position { X = 1, Y = 1, Direction = Model.Enums.Directions.E },
                       Exit = new Model.Entities.Coordinate { X = 0, Y = 0 },
                       Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                        {
                            new Model.Entities.Coordinate { X = 0, Y = 1 }
                        }
                   },
                   new Model.Entities.MovesConfig {  Model.Enums.Moves.R, Model.Enums.Moves.R, Model.Enums.Moves.M, Model.Enums.Moves.R, Model.Enums.Moves.M } );
            Assert.AreEqual(tsm.Play(), Model.Enums.State.MineHit);
        }

        [TestMethod]
        public void PlayErrorTest()
        {
            var tsm = new TurtleStateMachine(new BusinessLog());

            tsm.Initialize(
                   new Model.Entities.TableConfig
                   {
                       SizeX = 2,
                       SizeY = 2,
                       StartPosition = new Model.Entities.Position { X = 1, Y = 1, Direction = Model.Enums.Directions.E },
                       Exit = new Model.Entities.Coordinate { X = 0, Y = 0 },
                       Mines = new System.Collections.Generic.List<Model.Entities.Coordinate>
                        {
                            new Model.Entities.Coordinate { X = 0, Y = 1 }
                        }
                   },
                   new Model.Entities.MovesConfig {  Model.Enums.Moves.M} );
            Assert.AreEqual(tsm.Play(), Model.Enums.State.LeftTable);
        }
    }
}
