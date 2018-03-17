using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallangeCSharp.Logic.Helpers;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic.Test.Helpers
{
    [TestClass]
    public class ParserHelperTest
    {
        [TestMethod]
        public void TryParseMoveTest()
        {
            Assert.AreEqual(ParserHelper.TryParseMove("R"),Model.Enums.Moves.R);
            Assert.AreEqual(ParserHelper.TryParseMove("L"), Model.Enums.Moves.L);
            Assert.AreEqual(ParserHelper.TryParseMove("M"), Model.Enums.Moves.M);

            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseMove(""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseMove("r"));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseMove("l"));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseMove("m"));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseMove("RM"));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseMove("R, M"));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseMove("rm"));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseMove("1"));
        }

        [TestMethod]
        public void TryParseDirectionsTest()
        {
            Assert.AreEqual(ParserHelper.TryParseDirections("N",""), Model.Enums.Directions.N);
            Assert.AreEqual(ParserHelper.TryParseDirections("S",""), Model.Enums.Directions.S);
            Assert.AreEqual(ParserHelper.TryParseDirections("E",""), Model.Enums.Directions.E);
            Assert.AreEqual(ParserHelper.TryParseDirections("W",""), Model.Enums.Directions.W);

            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("w", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("s", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("e", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("n", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("ne", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("n,e", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("NE", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParseDirections("0", ""));
        }

        [TestMethod]
        public void TryParseTest()
        {
            Assert.AreEqual(ParserHelper.TryParse("1",""), 1);
            Assert.AreEqual(ParserHelper.TryParse("0", ""), 0);
            Assert.AreEqual(ParserHelper.TryParse("-1", ""), -1);
            Assert.AreEqual(ParserHelper.TryParse(" 1", ""), 1);
            Assert.AreEqual(ParserHelper.TryParse("1 ", ""), 1);
            Assert.AreEqual(ParserHelper.TryParse(int.MaxValue.ToString(), ""), int.MaxValue);
            Assert.AreEqual(ParserHelper.TryParse(int.MinValue.ToString(), ""), int.MinValue);

            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParse("2147483648", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParse("-2147483649", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParse("1 1", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParse("A", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParse("a", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParse("", ""));
            Assert.ThrowsException<ParseException>(() => ParserHelper.TryParse("-", ""));
        }

        enum testEnum
        {
            A,
            AB,
            a
        }
        [TestMethod]
        public void GetEnumElementsTest()
        {
            var testEnum = ParserHelper.GetEnumElements<testEnum>();
            Assert.IsTrue(testEnum.Contains("A") && testEnum.Contains("AB") && testEnum.Contains("a"));
            Assert.IsFalse(testEnum.Contains("ab"));
        }
    }
}
