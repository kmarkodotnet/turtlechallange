using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.Test.TestHelpers
{
    internal class GameInputReaderParseError : IGameInputReader
    {

        public string[] GetTableConfig()
        {
            return new string[1] { "1 2" };
        }

        public string[] GetMovesConfig()
        {
            return new string[0] { };
        }
    }
}
