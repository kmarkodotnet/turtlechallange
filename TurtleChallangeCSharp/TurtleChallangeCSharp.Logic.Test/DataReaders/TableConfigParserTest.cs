using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallangeCSharp.Logger;
using TurtleChallangeCSharp.Logic.DataReaders;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic.Test.DataReaders
{
    [TestClass]
    public class TableConfigParserTest
    {
        TableConfigParser parser = new TableConfigParser(new BusinessLog());

        [TestMethod]
        public void TableExampleSuccess()
        {
            parser.Source = new string[4]
            {
                "5 4",
                "1,1 1,3 3,3",
                "4 2",
                "0 1 N"
            };

            var tc = parser.ParseConfig();
            Assert.IsTrue(tc.SizeX == 5 &&
                tc.SizeY == 4 &&
                tc.Exit.X == 4 &&
                tc.Exit.Y == 2 &&
                tc.StartPosition.X == 0 &&
                tc.StartPosition.Y == 1 &&
                tc.StartPosition.Direction == Model.Enums.Directions.N &&
                tc.Mines.Count == 3 &&
                tc.Mines[0].X == 1 &&
                tc.Mines[0].Y == 1 &&
                tc.Mines[1].X == 1 &&
                tc.Mines[1].Y == 3 &&
                tc.Mines[2].X == 3 &&
                tc.Mines[2].Y == 3);
        }

        [TestMethod]
        public void BadConfigFail()
        {
            parser.Source = new string[3] { "5 4", "1,1 1,3 3,3", "4 2" };
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());

            parser.Source = new string[4] { "5 4 1", "1,1 1,3 3,3", "4 2", "0 1 N" };
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());

            parser.Source = new string[4] { "5 4", "1,,1 1,3 3,3", "4 2", "0 1 N" };
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());

            parser.Source = new string[4] { "5 4", "1,1 1,3 3,3 1", "4 2", "0 1 N" };
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());
            
            parser.Source = new string[4] { "5 4", "1,1 1,3 3,3", "4 2 2", "0 1" };
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());

            parser.Source = new string[4] { "5 4", "1,1 1,3 3,3", "4 2", "0 1 NN" };
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());

            parser.Source = new string[5] { "5 4", "1,1 1,3 3,3", "4 2", "0 1 N", "" };
            Assert.ThrowsException<ParseException>(() => parser.ParseConfig());
        }
    }
}
