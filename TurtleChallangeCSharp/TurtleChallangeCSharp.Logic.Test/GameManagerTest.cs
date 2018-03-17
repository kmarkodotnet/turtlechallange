using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallangeCSharp.Logic.DataReaders;
using TurtleChallangeCSharp.Logic.StateMachine;
using TurtleChallangeCSharp.Logic.Test.TestHelpers;
using TurtleChallangeCSharp.Model.Entities;

namespace TurtleChallangeCSharp.Logic.Test
{
    [TestClass]
    public class GameManagerTest
    {
        [TestMethod]
        public void OutOfMemoryErrorTest()
        {
            var gameManager = new GameManager(new GameInputReaderOutOfMemory(), new MovesConfigParser(), new TableConfigParser(), new TurtleStateMachine());
            var g = gameManager.RunGame();
            Assert.IsTrue(g.Count == 1);
            var error = g[0] as ErrorResult;
            Assert.IsTrue(error != null && error.ResultString == "Application is out of memory");
        }

        [TestMethod]
        public void BusinessErrorTest()
        {
            var gameManager = new GameManager(new GameInputReader("",""), new MovesConfigParser(), new TableConfigParser(), new TurtleStateMachine());
            var g = gameManager.RunGame();
            Assert.IsTrue(g.Count == 1);
            var error = g[0] as ErrorResult;
            Assert.IsTrue(error != null && error.ResultString == "Unable to load file: ");
        }

        [TestMethod]
        public void ParseErrorTest()
        {
            var gameManager = new GameManager(new GameInputReaderParseError(), new MovesConfigParser(), new TableConfigParser(), new TurtleStateMachine());
            var g = gameManager.RunGame();
            Assert.IsTrue(g.Count == 1);
            var error = g[0] as ErrorResult;
            Assert.IsTrue(error != null && error.ResultString == "Table configuration is empty or the parameters are incorrect");
        }

        [TestMethod]
        public void ExceptionErrorTest()
        {
            var gameManager = new GameManager(new GameInputReaderException(), new MovesConfigParser(), new TableConfigParser(), new TurtleStateMachine());
            var g = gameManager.RunGame();
            Assert.IsTrue(g.Count == 1);
            var error = g[0] as ErrorResult;
            Assert.IsTrue(error != null && error.ResultString == "An error occured");
        }

        [TestMethod]
        public void GameExampleTest()
        {
            var gameManager = new GameManager(new GameInputReaderGameExample(), new MovesConfigParser(), new TableConfigParser(), new TurtleStateMachine());
            var g = gameManager.RunGame();
            Assert.IsTrue(g.Count == 4);
            Assert.IsTrue(g[0] is GameResult && g[0].ResultString.Contains("Success"));
            Assert.IsTrue(g[1] is GameResult && g[1].ResultString.Contains("Mine"));
            Assert.IsTrue(g[2] is GameResult && g[2].ResultString.Contains("Success"));
            Assert.IsTrue(g[3] is GameResult && g[3].ResultString.Contains("Still"));
        }
    }
}
