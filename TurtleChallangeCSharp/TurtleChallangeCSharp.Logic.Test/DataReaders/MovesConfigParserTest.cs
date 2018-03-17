using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallangeCSharp.Logic.DataReaders;
using TurtleChallangeCSharp.Logic.Test.TestHelpers;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic.Test.DataReaders
{
    [TestClass]
    public class MovesConfigParserTest
    {
        MovesConfigParser parser = new MovesConfigParser();

        [TestMethod]
        public void MovesExampleSuccess()
        {
            var source = new string[2] { "R M L M M", "R M M M" };
            
            parser.Source = source;

            var mc = parser.ParseConfig();
            Assert.IsTrue(mc.Count == 2 && mc[0].Moves.Count == 5 && mc[1].Moves.Count == 4);
            var m = mc[0].Moves;
            Assert.IsTrue(m[0] == Model.Enums.Moves.R);
            Assert.IsTrue(m[1] == Model.Enums.Moves.M);
            Assert.IsTrue(m[2] == Model.Enums.Moves.L);
            Assert.IsTrue(m[3] == Model.Enums.Moves.M);
            Assert.IsTrue(m[4] == Model.Enums.Moves.M);
            m = mc[1].Moves;
            Assert.IsTrue(m[0] == Model.Enums.Moves.R);
            Assert.IsTrue(m[1] == Model.Enums.Moves.M);
            Assert.IsTrue(m[2] == Model.Enums.Moves.M);
            Assert.IsTrue(m[3] == Model.Enums.Moves.M);
        }

        [TestMethod]
        public void LongLineSuccess()
        {
            var randomData = new RandomData();
            var ms = randomData.GetMoves(10000000);
            var msSource = string.Join(" ", ms);

            parser.Source = new string[1] { msSource };
            var mc = parser.ParseConfig();

            Assert.IsTrue(mc.Count == 1 && mc[0].Moves.Count == ms.Count);

            for (int i = 0; i < mc[0].Moves.Count; i++)
            {
                Assert.AreEqual(mc[0].Moves[i], ms[i]);
            }
        }
        [TestMethod]
        public void LotRowSuccess()
        {
            var maxLineLength = 10;
            var randomData = new RandomData();

            var rowsCount = 1000000;
            var msr = new MovesConfigs();
            parser.Source = new string[rowsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                var ms = randomData.GetMoves(maxLineLength);
                msr.Add(new MovesConfig { Moves = ms });

                var msSource = string.Join(" ", ms);
                parser.Source[i] = msSource;
            }
            
            var mc = parser.ParseConfig();

            Assert.IsTrue(mc.Count == rowsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < mc[i].Moves.Count; j++)
                {
                    Assert.AreEqual(mc[i].Moves[j], msr[i].Moves[j]);
                }
            }   
        }

        [TestMethod]
        public void BadMoveFail()
        {
            var source = new string[2] { "R M F L M M", "R M M M" };
            parser.Source = source;
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());
        }

        [TestMethod]
        public void BadMoveFail2()
        {
            var source = new string[1] { " " };
            parser.Source = source;
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());
        }


        [TestMethod]
        public void BadMoveFail3()
        {
            var source = new string[1] { "RM" };
            parser.Source = source;
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());
        }

        [TestMethod]
        public void EmptyMoveSuccess1()
        {
            var source = new string[1] { "" };
            var mc = parser.ParseConfig();
            Assert.IsTrue(mc.Count == 0);
        }

        [TestMethod]
        public void EmptyMoveSuccess2()
        {
            var source = new string[0];
            var mc = parser.ParseConfig();
            Assert.IsTrue(mc.Count == 0);
        }

        [TestMethod]
        public void SimpleSuccess()
        {
            var source = new string[1] { "R"};

            parser.Source = source;

            var mc = parser.ParseConfig();
            Assert.IsTrue(mc.Count == 1 && mc[0].Moves.Count == 1 && mc[0].Moves[0] == Model.Enums.Moves.R);
        }
    }
}
